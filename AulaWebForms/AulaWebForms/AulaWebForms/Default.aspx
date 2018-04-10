<%@ Page Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="AulaWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h1>Cadastro de Usuário</h1>
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
                    <div class="col-md-8">
                        <asp:Label ID="lblLogin" runat="server"
                            CssClass="control-label">Login:</asp:Label>
                        <asp:TextBox ID="txtLogin" runat="server"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblSenha" runat="server"
                            CssClass="control-label">Senha:</asp:Label>
                        <asp:TextBox ID="txtSenha" runat="server"
                            CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:Label ID="lblEstado" runat="server"
                            CssClass="control-label">Estado:</asp:Label>
                        <asp:DropDownList ID="ddlEstado" runat="server"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-8">
                        <asp:Label ID="lblCidade" runat="server"
                            CssClass="control-label">Cidade:</asp:Label>
                        <asp:TextBox ID="txtCidade" runat="server"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4">
                        <asp:Label ID="lblSexo" runat="server"
                            CssClass="control-label">Sexo:</asp:Label>
                        <br />
                        <asp:RadioButton ID="rdoMasculino" runat="server" GroupName="sexo" />
                        Masculino
                        <asp:RadioButton ID="rdoFeminino" runat="server" GroupName="sexo" />
                        Feminino
                    </div>
                    <div class="col-md-4">
                        <br />
                        <asp:CheckBox ID="chkAdministrador" runat="server" />
                        <asp:Label ID="lblAdministrador" runat="server"
                            CssClass="control-label">É administrador?</asp:Label>
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
