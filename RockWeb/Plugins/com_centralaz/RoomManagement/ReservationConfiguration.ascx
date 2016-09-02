<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReservationConfiguration.ascx.cs" Inherits="RockWeb.Plugins.com_centralaz.RoomManagement.ReservationConfiguration" %>

<script type="text/javascript">
    function clearActiveDialog() {
        $('#<%=hfActiveDialog.ClientID %>').val('');
    }
</script>

<asp:UpdatePanel ID="upContent" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlDetails" CssClass="panel panel-block" runat="server" Visible="false">
            <div class="panel-heading">
                <h1 class="panel-title">Reservation Configuration</h1>
            </div>
            <div class="panel-body">
                <Rock:NotificationBox ID="nbEditModeMessage" runat="server" NotificationBoxType="Info" />
                <Rock:NotificationBox ID="nbRequired" runat="server" NotificationBoxType="Danger" Text="A default reservation status is required." Visible="false" />
                <asp:ValidationSummary ID="valDetail" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-danger" />

                <div id="pnlEditDetails" runat="server">
                    <Rock:PanelWidget ID="wpMinistries" runat="server" Title="Ministries">
                        <div class="grid">
                            <Rock:Grid ID="gMinistries" runat="server" AllowPaging="false" DisplayType="Light" RowItemText="Ministry" ShowConfirmDeleteDialog="false">
                                <Columns>
                                    <Rock:RockBoundField DataField="Name" HeaderText="Ministries" />
                                    <Rock:EditField OnClick="gMinistries_Edit" />
                                    <Rock:DeleteField OnClick="gMinistries_Delete" />
                                </Columns>
                            </Rock:Grid>
                        </div>
                    </Rock:PanelWidget>

                    <Rock:PanelWidget ID="wpStatuses" runat="server" Title="Statuses">
                        <div class="grid">
                            <Rock:Grid ID="gStatuses" runat="server" AllowPaging="false" DisplayType="Light" RowItemText="Status" ShowConfirmDeleteDialog="false">
                                <Columns>
                                    <Rock:RockBoundField DataField="Name" HeaderText="Name" />
                                    <Rock:RockBoundField DataField="Description" HeaderText="Description" />
                                    <Rock:SecurityField />
                                    <Rock:EditField OnClick="gStatuses_Edit" />
                                    <Rock:DeleteField OnClick="gStatuses_Delete" />
                                </Columns>
                            </Rock:Grid>
                        </div>
                    </Rock:PanelWidget>

                    <Rock:PanelWidget ID="wpWorkflowTrigger" runat="server" Title="Workflow Triggers">
                        <div class="grid">
                            <Rock:Grid ID="gWorkflowTriggers" runat="server" AllowPaging="false" DisplayType="Light" RowItemText="Workflow Trigger" ShowConfirmDeleteDialog="false">
                                <Columns>
                                    <Rock:RockBoundField DataField="WorkflowType" HeaderText="Workflow Type" />
                                    <Rock:RockBoundField DataField="Trigger" HeaderText="Trigger" />
                                    <Rock:EditField OnClick="gWorkflowTriggers_Edit" />
                                    <Rock:DeleteField OnClick="gWorkflowTriggers_Delete" />
                                </Columns>
                            </Rock:Grid>
                        </div>
                    </Rock:PanelWidget>

                    <div class="actions">
                        <asp:LinkButton ID="btnSave" runat="server" AccessKey="s" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        <asp:LinkButton ID="btnCancel" runat="server" AccessKey="c" Text="Cancel" CssClass="btn btn-link" CausesValidation="false" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <Rock:ModalAlert ID="modalAlert" runat="server" />

        <asp:HiddenField ID="hfActiveDialog" runat="server" />

        <Rock:ModalDialog ID="dlgMinistries" runat="server" ScrollbarEnabled="false" SaveButtonText="Add" OnSaveClick="btnAddMinistry_Click" Title="Add Ministry" ValidationGroup="Ministry">
            <Content>
                <asp:HiddenField ID="hfAddMinistryGuid" runat="server" />
                <Rock:DataTextBox ID="tbMinistryName" SourceTypeName="com.centralaz.RoomManagement.Model.ReservationMinistry, com.centralaz.RoomManagement" PropertyName="Name" Label="Ministry Name" runat="server" ValidationGroup="Ministry" />
            </Content>
        </Rock:ModalDialog>

        <Rock:ModalDialog ID="dlgStatuses" runat="server" ScrollbarEnabled="false" SaveButtonText="Add" OnSaveClick="btnAddStatus_Click" Title="Create Status" ValidationGroup="Status">
            <Content>
                <asp:HiddenField ID="hfAddStatusGuid" runat="server" />
                <div class="row">
                    <div class="col-md-6">
                        <Rock:DataTextBox ID="tbStatusName" SourceTypeName="com.centralaz.RoomManagement.Model.ReservationStatus, com.centralaz.RoomManagement" PropertyName="Name" Label="Name" runat="server" ValidationGroup="Status" />
                    </div>
                    <div class="col-md-6">
                        <Rock:RockCheckBox ID="cbIsActive" runat="server" Label="Is Active" ValidationGroup="Status" />
                    </div>
                </div>
                <Rock:DataTextBox ID="tbStatusDescription" SourceTypeName="com.centralaz.RoomManagement.Model.ReservationStatus, com.centralaz.RoomManagement" PropertyName="Description" Label="Description" runat="server" ValidationGroup="Status" TextMode="MultiLine" Rows="3" />
                <div class="row">
                    <div class="col-md-6">
                        <Rock:RockCheckBox ID="cbIsCritical" runat="server" Label="Is Critical" ValidationGroup="Status" Help="Requires immediate action." />
                    </div>
                    <div class="col-md-6">
                        <Rock:RockCheckBox ID="cbIsDefault" runat="server" Label="Is Default" ValidationGroup="Status" />
                    </div>
                </div>
            </Content>
        </Rock:ModalDialog>

        <Rock:ModalDialog ID="dlgWorkflowTrigger" runat="server" Title="Select Workflow" OnSaveClick="dlgWorkflowTrigger_SaveClick" OnCancelScript="clearActiveDialog();" ValidationGroup="WorkflowTrigger">
            <Content>

                <asp:HiddenField ID="hfAddWorkflowTriggerGuid" runat="server" />

                <asp:ValidationSummary ID="valWorkflowTriggerSummary" runat="server" HeaderText="Please Correct the Following" CssClass="alert alert-danger" ValidationGroup="WorkflowTrigger" />

                <div class="row">
                    <div class="col-md-6">
                        <Rock:RockDropDownList ID="ddlTriggerType" runat="server" Label="Launch Workflow When" DataTextField="Name" DataValueField="Id"
                            OnSelectedIndexChanged="ddlTriggerType_SelectedIndexChanged" AutoPostBack="true" Required="true" ValidationGroup="Workflow" />
                    </div>
                    <div class="col-md-6">
                        <Rock:RockDropDownList ID="ddlWorkflowType" runat="server" Label="Workflow Type" DataTextField="Name" DataValueField="Id"
                            Required="true" ValidationGroup="Workflow" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <Rock:RockDropDownList ID="ddlPrimaryQualifier" runat="server" Visible="false" ValidationGroup="Workflow" />
                        <Rock:RockDropDownList ID="ddlSecondaryQualifier" runat="server" Visible="false" ValidationGroup="Workflow" />
                    </div>
                    <div class="col-md-6">
                    </div>
                </div>

            </Content>
        </Rock:ModalDialog>
    </ContentTemplate>
</asp:UpdatePanel>
