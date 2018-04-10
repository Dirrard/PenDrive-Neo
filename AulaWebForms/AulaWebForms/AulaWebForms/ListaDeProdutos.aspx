<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListaDeProdutos.aspx.cs" Inherits="AulaWebForms.ListaDeProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <form runat="server" class="form-horizontal">
                <div class="form-group">
                    <div class="col-lg-12">
                        <h1>Produtos</h1>
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
                        <asp:GridView ID="grdProdutos" runat="server"
                            AutoGenerateColumns="false"
                            Width="100%" CssClass="Grid"
                            AlternatingRowStyle-CssClass="alt"
                            PagerStyle-CssClass="pgr">
                            <Columns>
                                <asp:TemplateField HeaderText="Nome">
                                    <HeaderStyle Width="25%" />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblNome" runat="server"
                                            Text='<%# Bind("Nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo de Produto">
                                    <HeaderStyle Width="25%" />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipoDeProduto" runat="server"
                                            Text='<%# Bind("TipoDeProduto.Nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preço">
                                    <HeaderStyle Width="15%" />
                                    <ItemStyle Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPreco" runat="server"
                                            Text='<%# Bind("Preco") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descrição">
                                    <HeaderStyle Width="35%" />
                                    <ItemStyle Width="35%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescricao" runat="server"
                                            Text='<%# Bind("Descricao") %>'></asp:Label>
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
