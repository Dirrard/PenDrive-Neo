<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaDeEstados.aspx.cs"
    Inherits="AulaWebForms.ListaDeEstados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <form runat="server" class="form-horizontal">
                <div class="form-group">
                    <div class="col-lg-12">
                        <h1>Estados</h1>
                        <hr />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-12">
                        <asp:Button ID="btnCadastro"
                            runat="server" CssClass="btn btn-primary"
                            Text="Cadastrar" OnClick="btnCadastro_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-12">
                        <asp:GridView ID="grdEstados" runat="server"
                            AutoGenerateColumns="false"
                            Width="100%" CssClass="Grid"
                            AlternatingRowStyle-CssClass="alt"
                            PagerStyle-CssClass="pgr">
                            <Columns>
                                <asp:TemplateField HeaderText="Nome">
                                    <HeaderStyle Width="70%" />
                                    <ItemStyle Width="70%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNome" runat="server"
                                            Text='<%# Bind("Nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sigla">
                                    <HeaderStyle Width="30%" />
                                    <ItemStyle Width="30%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSigla" runat="server" 
                                            Text='<%# Bind("Sigla") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
