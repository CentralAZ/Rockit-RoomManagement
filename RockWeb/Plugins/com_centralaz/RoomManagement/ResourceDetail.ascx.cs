﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using Rock;
using Rock.Attribute;
using Rock.Constants;
using Rock.Data;
using Rock.Model;
using Rock.Security;
using Rock.Web;
using Rock.Web.Cache;
using Rock.Web.UI;

using com.centralaz.RoomManagement.Model;

namespace RockWeb.Plugins.com_centralaz.RoomManagement
{
    [DisplayName( "Resource Detail" )]
    [Category( "com_centralaz > Room Management" )]
    [Description( "Displays the details of the resource." )]

    public partial class ResourceDetail : RockBlock, IDetailBlock
    {
        #region Control Methods

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            // this event gets fired after block settings are updated. it's nice to repaint the screen if these settings would alter it
            this.BlockUpdated += ResourceDetail_BlockUpdated;
            this.AddConfigurationUpdateTrigger( upDetail );
        }

        protected void ResourceDetail_BlockUpdated( object sender, EventArgs e )
        {
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            ClearErrorMessage();

            if ( !Page.IsPostBack )
            {
                ShowDetail( PageParameter( "ResourceId" ).AsInteger() );
            }
        }

        /// <summary>
        /// Returns breadcrumbs specific to the block that should be added to navigation
        /// based on the current page reference.  This function is called during the page's
        /// oninit to load any initial breadcrumbs
        /// </summary>
        /// <param name="pageReference">The page reference.</param>
        /// <returns></returns>
        public override List<BreadCrumb> GetBreadCrumbs( PageReference pageReference )
        {
            var breadCrumbs = new List<BreadCrumb>();

            int? resourceId = PageParameter( pageReference, "ResourceId" ).AsIntegerOrNull();
            if ( resourceId != null )
            {
                Resource resource = new ResourceService( new RockContext() ).Get( resourceId.Value );
                if ( resource != null )
                {
                    breadCrumbs.Add( new BreadCrumb( resource.Name, pageReference ) );
                    lReadOnlyTitle.Text = resource.Name.FormatAsHtmlTitle();
                }
                else
                {
                    breadCrumbs.Add( new BreadCrumb( "New Resource", pageReference ) );
                    lReadOnlyTitle.Text = "New Resource";
                }
            }
            else
            {
                breadCrumbs.Add( new BreadCrumb( "New Resource", pageReference ) );
                lReadOnlyTitle.Text = "New Resource";
            }

            return breadCrumbs;
        }

        #endregion

        #region Edit Events

        protected void btnSave_Click( object sender, EventArgs e )
        {
            SaveResource();

            if ( Page.IsValid )
            {
                NavigateToParentPage();
            }
        }

        protected void btnSaveThenAdd_Click( object sender, EventArgs e )
        {
            SaveResource();

            if ( Page.IsValid )
            {
                ShowDetail( 0 );
            }
        }

        private void SaveResource()
        {
            if ( Page.IsValid )
            {
                var rockContext = new RockContext();

                ResourceService resourceService = new ResourceService( rockContext );
                Resource resource;

                int resourceId = int.Parse( hfResourceId.Value );

                // if adding a new resource 
                if ( resourceId.Equals( 0 ) )
                {
                    resource = new Resource { Id = 0 };
                }
                else
                {
                    // load existing resource
                    resource = resourceService.Get( resourceId );
                }

                resource.Name = tbName.Text;
                resource.CategoryId = cpCategory.SelectedValueAsInt() ?? 0;
                resource.CampusId = ddlCampus.SelectedValueAsInt();
                resource.Quantity = nbQuantity.Text.AsIntegerOrNull() ?? 1;
                resource.Note = tbNote.Text;

                if ( !Page.IsValid )
                {
                    return;
                }

                // using WrapTransaction because there are three Saves
                rockContext.WrapTransaction( () =>
                {
                    if ( resource.Id.Equals( 0 ) )
                    {
                        resourceService.Add( resource );
                    }

                    rockContext.SaveChanges();
                } );
            }
        }

        protected void btnCancel_Click( object sender, EventArgs e )
        {
            NavigateToParentPage();
        }

        #endregion

        #region Internal Methods

        public void ShowDetail( int resourceId )
        {
            var rockContext = new RockContext();
            Resource resource = null;

            ddlCampus.Items.Clear();
            ddlCampus.Items.Add( new ListItem( string.Empty, string.Empty ) );
            foreach ( var campus in CampusCache.All() )
            {
                ListItem li = new ListItem( campus.Name, campus.Id.ToString() );
                ddlCampus.Items.Add( li );
            }

            if ( !resourceId.Equals( 0 ) )
            {
                resource = new ResourceService( rockContext ).Get( resourceId );
            }
            else
            {
                resource = new Resource { Id = 0 };
            }

            if ( resource == null )
            {
                if ( resourceId > 0 )
                {
                    nbErrorMessage.NotificationBoxType = Rock.Web.UI.Controls.NotificationBoxType.Warning;
                    nbErrorMessage.Title = "Warning";
                    nbErrorMessage.Text = "Resource not found. Resource may have been deleted.";
                }
                else
                {
                    nbErrorMessage.NotificationBoxType = Rock.Web.UI.Controls.NotificationBoxType.Danger;
                    nbErrorMessage.Title = "Invalid Request";
                    nbErrorMessage.Text = "An incorrect querystring parameter was used.  A valid ResourceId parameter is required.";
                }

                pnlEditDetails.Visible = false;
                return;
            }

            pnlEditDetails.Visible = true;

            hfResourceId.Value = resource.Id.ToString();

            // render UI based on Authorized and IsSystem
            bool readOnly = false;

            if ( resource.Id.Equals( 0 ) )
            {
                btnSaveThenAdd.Visible = true;
            }
            else
            {
                btnSaveThenAdd.Visible = false;
            }

            btnSave.Visible = !readOnly;

            tbName.Text = resource.Name;
            cpCategory.SetValue( resource.CategoryId );
            ddlCampus.SelectedValue = resource.CampusId.ToString();
            nbQuantity.Text = resource.Quantity.ToString();
            tbNote.Text = resource.Note;
        }

        private void ClearErrorMessage()
        {
            nbErrorMessage.Title = string.Empty;
            nbErrorMessage.Text = string.Empty;
        }

        #endregion
    }
}