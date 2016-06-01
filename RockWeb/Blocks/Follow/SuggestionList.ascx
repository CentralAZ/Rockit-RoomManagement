<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuggestionList.ascx.cs" Inherits="RockWeb.Blocks.Follow.SuggestionList" %>

<asp:UpdatePanel ID="pnlSuggestionListUpdatePanel" runat="server">
    <ContentTemplate>

        <Rock:ModalAlert ID="mdGridWarning" runat="server" />

        <div class="panel panel-block">
            <div class="panel-heading">
                <h1 class="panel-title"><i class="fa fa-flag-o"></i> Suggestion List</h1>
            </div>
            <div class="panel-body">

                <div class="grid grid-panel">
                    <Rock:Grid ID="rGridSuggestion" runat="server"  RowItemText="Suggestion" OnRowSelected="rGridSuggestion_Edit" TooltipField="Description" AllowSorting="false">
                        <Columns>
                            <Rock:ReorderField />
                            <Rock:RockBoundField DataField="Name" HeaderText="Name" />
                            <asp:TemplateField HeaderText="Suggestion Type">
                                <ItemTemplate><%# GetComponentName( Eval( "EntityType") )%></ItemTemplate>
                            </asp:TemplateField>
                            <Rock:BoolField DataField="IsActive" HeaderText="Active" />
                            <Rock:DeleteField OnClick="rGridSuggestion_Delete" />
                        </Columns>
                    </Rock:Grid>
                </div>

            </div>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>
