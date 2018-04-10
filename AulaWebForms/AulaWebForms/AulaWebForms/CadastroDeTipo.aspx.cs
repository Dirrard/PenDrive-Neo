using System;
using System.Data;
using System.Data.SqlClient;

namespace AulaWebForms
{
    public partial class CadastroDeTipo : System.Web.UI.Page
    {
        //Evento de carregamento da página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica se é a primeira vez que está carregando a página
            if (IsPostBack)
                return;
        }

        //Evento de clique do botão Salvar
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //Verificando se todos os campos obrigatórios estão preenchidos
            if (Validar())
            {
                //Chamando o método salvar
                Salvar();
                //Chamando o método limpar campos
                LimparCampos();
                //Redirecionando para a página de listagem de tipos de produtos
                Response.Redirect("~/ListaDeTipos.aspx");
            }
        }

        //Evento de clique do botão Cancelar
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Redirecionando para a página de listagem de tipos de produtos
            Response.Redirect("~/ListaDeTipos.aspx");
        }

        //Método para limpar os campos da tela
        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
        }

        //Método para validar os campos obrigatórios da página
        private bool Validar()
        {
            //Verificando se o campo está nulo ou vazio
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                return false;

            //Verificando se o campo está nulo ou vazio
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
                return false;

            return true;
        }

        //Método para salvar os valores preenchidos na tela no banco de dados
        private void Salvar()
        {
            //Criando o objeto tipo de produto e preenchendo suas propriedades com os valores informados na tela
            var obj = new TipoDeProduto();
            obj.Nome = txtNome.Text;
            obj.Descricao = txtDescricao.Text;

            //Criando uma conexão com o banco de dados
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=SENAI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                //Criando instrução sql para inserir na tabela de cidades
                string strSQL = @"INSERT INTO tipo_produto (nome, descricao) VALUES (@nome, @descricao)";

                //Criando um comando sql que será executado na base de dados
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    //Preenchendo os parâmetros da instrução sql
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = obj.Descricao;

                    //Abrindo conexão com o banco de dados
                    conn.Open();
                    //Executando instrução sql
                    cmd.ExecuteNonQuery();
                    //Fechando conexão com o banco de dados
                    conn.Close();
                }
            }
        }
    }
}