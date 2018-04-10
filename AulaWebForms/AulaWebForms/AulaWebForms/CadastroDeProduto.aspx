<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CadastroDeProduto.aspx.cs" Inherits="AulaWebForms.CadastroDeProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1>Cadastro de Produto</h1>
            <hr />
            <form class="form-horizontal" runat="server">
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:Label ID="lblNome" runat="server"
                            CssClass="control-label">Nome:</asp:Label>
                        <asp:TextBox ID="txtNome" runat="server"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:Label ID="lblEstado" runat="server"
                            CssClass="control-label">Tipo de produto:</asp:Label>
                        <asp:DropDownList ID="ddlTipoDeProduto" runat="server"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:Label ID="lblPreco" runat="server"
                            CssClass="control-label">Preço:</asp:Label>
                        <asp:TextBox ID="txtPreco" runat="server"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12">
                        <asp:Label ID="lblDescricao" runat="server"
                            CssClass="control-label">Descrição:</asp:Label>
                        <asp:TextBox ID="txtDescricao" runat="server" Rows="5"
                            CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12 text-right">
                        <asp:Button ID="btnSalvar" runat="server"
                            Text="Salvar" CssClass="btn btn-primary"
                            OnClick="btnSalvar_Click" />
                        <asp:Button ID="btnCancelar" runat="server"
                            Text="Cancelar" CssClass="btn btn-primary"
                            OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
