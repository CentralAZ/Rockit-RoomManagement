<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarChartDashboardWidget.ascx.cs" Inherits="RockWeb.Blocks.Reporting.Dashboard.BarChartDashboardWidget" %>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlDashboardTitle" runat="server" CssClass="dashboard-title">
            <asp:Literal runat="server" ID="lDashboardTitle" />
        </asp:Panel>
        <asp:Panel ID="pnlDashboardSubtitle" runat="server" CssClass="dashboard-subtitle">
            <asp:Literal runat="server" ID="lDashboardSubtitle" />
        </asp:Panel>
        <Rock:NotificationBox ID="nbMetricWarning" runat="server" NotificationBoxType="Warning" Text="Please select a metric in the block settings." />
        <Rock:BarChart ID="bcChart" runat="server" />

    </ContentTemplate>
</asp:UpdatePanel>
