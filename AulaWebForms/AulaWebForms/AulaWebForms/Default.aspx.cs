using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace AulaWebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            CarregarEstados();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Salvar();
                LimparCampos();
                Response.Redirect("~/Usuarios.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }

        private void CarregarEstados()
        {
            var lstEstados = new List<Estado>();
            lstEstados.Add(new Estado() { Sigla = "", Nome = "-- [SELECIONE] --" });
            lstEstados.Add(new Estado() { Sigla = "AC", Nome = "Acre" });
            lstEstados.Add(new Estado() { Sigla = "AL", Nome = "Alagoas" });
            lstEstados.Add(new Estado() { Sigla = "AM", Nome = "Amazonas" });
            lstEstados.Add(new Estado() { Sigla = "AP", Nome = "Amapá" });
            lstEstados.Add(new Estado() { Sigla = "BA", Nome = "Bahia" });
            lstEstados.Add(new Estado() { Sigla = "CE", Nome = "Ceará" });
            lstEstados.Add(new Estado() { Sigla = "DF", Nome = "Distrito Federal" });
            lstEstados.Add(new Estado() { Sigla = "ES", Nome = "Espírito Santo" });
            lstEstados.Add(new Estado() { Sigla = "GO", Nome = "Goiás" });
            lstEstados.Add(new Estado() { Sigla = "MA", Nome = "Maranhão" });
            lstEstados.Add(new Estado() { Sigla = "MG", Nome = "Minas Gerais" });
            lstEstados.Add(new Estado() { Sigla = "MS", Nome = "Mato Grosso do Sul" });
            lstEstados.Add(new Estado() { Sigla = "MT", Nome = "Mato Grosso" });
            lstEstados.Add(new Estado() { Sigla = "PA", Nome = "Pará" });
            lstEstados.Add(new Estado() { Sigla = "PB", Nome = "Paraíba" });
            lstEstados.Add(new Estado() { Sigla = "PE", Nome = "Pernambuco" });
            lstEstados.Add(new Estado() { Sigla = "PI", Nome = "Piauí" });
            lstEstados.Add(new Estado() { Sigla = "PR", Nome = "Paraná" });
            lstEstados.Add(new Estado() { Sigla = "RJ", Nome = "Rio de Janeiro" });
            lstEstados.Add(new Estado() { Sigla = "RN", Nome = "Rio Grande do Norte" });
            lstEstados.Add(new Estado() { Sigla = "RO", Nome = "Rondônia" });
            lstEstados.Add(new Estado() { Sigla = "RR", Nome = "Roraima" });
            lstEstados.Add(new Estado() { Sigla = "RS", Nome = "Rio Grande do Sul" });
            lstEstados.Add(new Estado() { Sigla = "SC", Nome = "Santa Catarina" });
            lstEstados.Add(new Estado() { Sigla = "SE", Nome = "Sergipe" });
            lstEstados.Add(new Estado() { Sigla = "SP", Nome = "São Paulo" });
            lstEstados.Add(new Estado() { Sigla = "TO", Nome = "Tocantins" });

            ddlEstado.DataTextField = "Nome";
            ddlEstado.DataValueField = "Sigla";
            ddlEstado.DataSource = lstEstados.OrderBy(o => o.Nome).ToList();
            ddlEstado.DataBind();
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            ddlEstado.ClearSelection();
            txtCidade.Text = string.Empty;
            rdoMasculino.Checked = true;
            rdoFeminino.Checked = false;
            chkAdministrador.Checked = false;
            txtDescricao.Text = string.Empty;
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtLogin.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
                return false;

            return true;
        }

        private void Salvar()
        {
            var obj = new Usuario();
            obj.Nome = txtNome.Text;
            obj.Login = txtLogin.Text;
            obj.Senha = txtSenha.Text;
            obj.Estado = ddlEstado.SelectedValue;
            obj.Cidade = txtCidade.Text;
            obj.Sexo = rdoMasculino.Checked ? "M" : "F"; //ternário
            obj.Administrador = chkAdministrador.Checked;
            obj.Descricao = txtDescricao.Text;

            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=SENAI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO usuario (nome, [login], senha, 
                    estado, cidade, sexo, administrador, descricao) 
                    VALUES (@nome, @login, @senha, @estado, @cidade, 
                    @sexo, @administrador, @descricao)";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = obj.Login;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = obj.Senha;
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = obj.Estado;
                    cmd.Parameters.Add("@cidade", SqlDbType.VarChar).Value = obj.Cidade;
                    cmd.Parameters.Add("@sexo", SqlDbType.Char).Value = obj.Sexo;
                    cmd.Parameters.Add("@administrador", SqlDbType.Bit).Value = obj.Administrador;
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = obj.Descricao;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}