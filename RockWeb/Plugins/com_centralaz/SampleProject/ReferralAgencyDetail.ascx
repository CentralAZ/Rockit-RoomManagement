<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReferralAgencyDetail.ascx.cs" Inherits="RockWeb.Plugins.com_centralaz.SampleProject.ReferralAgencyDetail" %>
<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlDetails" runat="server" CssClass="panel panel-block" Visible="false">

            <asp:HiddenField ID="hfReferralAgencyId" runat="server" />

            <div class="panel-heading">
                <h1 class="panel-title">
                    <i class="fa fa-check-square-o"></i>
                    <asp:Literal ID="lActionTitle" runat="server" />
                </h1>
            </div>

            <div class="panel-body">

                <asp:ValidationSummary ID="valSummaryTop" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-danger" />
                <Rock:NotificationBox ID="nbWarningMessage" runat="server" NotificationBoxType="Warning" />
                <Rock:NotificationBox ID="nbEditModeMessage" runat="server" NotificationBoxType="Info" />

                <div class="row">
                    <div class="col-md-6">
                        <Rock:DataTextBox ID="tbName" runat="server" SourceTypeName="com.centralaz.SampleProject.Model.ReferralAgency, com.centralaz.SampleProject" PropertyName="Name" />
                    </div>
                    <div class="col-md-6">
                    </div>
                </div>

                <Rock:DataTextBox ID="tbDescription" runat="server" SourceTypeName="com.centralaz.SampleProject.Model.ReferralAgency, com.centralaz.SampleProject" PropertyName="Description" TextMode="MultiLine" Rows="4" />

                <div class="row">
                    <div class="col-md-6">
                        <Rock:CampusPicker ID="cpCampus" runat="server" Label="Campus" />
                        <Rock:DataDropDownList ID="ddlAgencyType" runat="server" SourceTypeName="com.centralaz.SampleProject.Model.ReferralAgency, com.centralaz.SampleProject" PropertyName="AgencyTypeValue" Label="Agency Type" />
                    </div>
                    <div class="col-md-6">
                        <Rock:DataTextBox ID="tbContactName" runat="server" SourceTypeName="com.centralaz.SampleProject.Model.ReferralAgency, com.centralaz.SampleProject" PropertyName="ContactName" />
                        <Rock:DataTextBox ID="tbPhoneNumber" runat="server" SourceTypeName="com.centralaz.SampleProject.Model.ReferralAgency, com.centralaz.SampleProject" PropertyName="PhoneNumber" />
                        <Rock:DataTextBox ID="tbWebsite" runat="server" SourceTypeName="com.centralaz.SampleProject.Model.ReferralAgency, com.centralaz.SampleProject" PropertyName="Website" />
                    </div>
                </div>

                <div class="actions">
                    <asp:LinkButton ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-link" CausesValidation="false" OnClick="btnCancel_Click" />
                </div>

            </div>

        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
