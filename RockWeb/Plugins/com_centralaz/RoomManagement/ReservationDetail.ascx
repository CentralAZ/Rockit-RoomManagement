<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReservationDetail.ascx.cs" Inherits="RockWeb.Plugins.com_centralaz.RoomManagement.ReservationDetail" %>
<%@ Register TagPrefix="CentralAZ" Assembly="com.centralaz.RoomManagement" Namespace="com.centralaz.RoomManagement.Web.UI.Controls" %>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlView" runat="server" CssClass="panel panel-block">

            <div class="panel-heading">
                <h1 class="panel-title">
                    <asp:Literal ID="lPanelTitle" runat="server" /></h1>
            </div>
            <div class="panel-body">
                <Rock:NotificationBox ID="nbErrorWarning" runat="server" NotificationBoxType="Danger" />
                <div class="row">
                    <div class="col-md-6">
                        <Rock:RockTextBox ID="rtbName" runat="server" Label="Event Name" Required="true" />
                        <Rock:RockDropDownList ID="ddlCampus" runat="server" Label="Campus" Required="false" />
                        <Rock:RockDropDownList ID="ddlMinistry" runat="server" Label="Ministry" Required="false" />
                        <Rock:RockTextBox ID="rtbNote" runat="server" Label="Notes" TextMode="MultiLine" />
                        <div class="row">
                            <div class="col-md-6">
                                <Rock:NumberBox ID="nbAttending" runat="server" NumberType="Integer" MinimumValue="0" Label="Number Attending" Required="false" />
                            </div>
                            <div class="col-md-6">
                                <Rock:RockCheckBox ID="cbIsApproved" runat="server" Label="Approved" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6">
                                <Rock:ScheduleBuilder ID="sbSchedule" runat="server" Label="Times" Required="true" />
                            </div>
                            <div class="col-md-6">
                                <Rock:NumberBox ID="nbSetupTime" runat="server" NumberType="Integer" MinimumValue="0" Label="Setup Time" Required="false" />
                                <Rock:NumberBox ID="nbCleanupTime" runat="server" NumberType="Integer" MinimumValue="0" Label="Cleanup Time" Required="false" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <Rock:LocationItemPicker ID="lpLocation" runat="server" Label="Locations" Required="false" AllowMultiSelect="true" OnSelectItem="lpLocation_SelectItem" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <CentralAZ:ScheduledResourcePicker ID="srpResource" runat="server" Label="Resources" Required="false" AllowMultiSelect="true" OnSelectItem="rpResource_SelectItem" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="actions">
                    <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_OnClick" />
                    <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-link" OnClick="btnCancel_OnClick" />
                </div>
            </div>

        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
