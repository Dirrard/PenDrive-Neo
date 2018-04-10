using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace AulaWebForms
{
    public partial class CadastroDeProduto : System.Web.UI.Page
    {
        //Evento de carregamento da página (quando a página está sendo inicializada)
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica se é a primeira vez que está carregando a página
            if (IsPostBack)
                return;
            //Chamando o método para carregar o DropDownList de tipos de produtos
            CarregarTipos();
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
                //Redirecionando para a página de listagem de produtos
                Response.Redirect("~/ListaDeProdutos.aspx");
            }
        }

        //Evento de clique do botão Cancelar
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Redirecionando para a página de listagem de produtos
            Response.Redirect("~/ListaDeProdutos.aspx");
        }

        //Método para carregar a DropDownList de tipos de produtos
        private void CarregarTipos()
        {
            var lstTipos = new List<TipoDeProduto>();

            //Criando uma conexão com o banco de dados
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=SENAI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                //Criando instrução sql para selecionar todos os registros na tabela de tipos de produtos
                string strSQL = @"SELECT * FROM tipo_produto";

                //Criando um comando sql que será executado na base de dados
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    //Abrindo conexão com o banco de dados
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    //Executando instrução sql
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    //Fechando conexão com o banco de dados
                    conn.Close();

                    //Percorrendo todos os registros encontrados na base de dados e adicionando em uma lista
                    foreach (DataRow row in dt.Rows)
                    {
                        var tipoDeProduto = new TipoDeProduto()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                            Descricao = row["descricao"].ToString()
                        };
                        lstTipos.Add(tipoDeProduto);
                    }
                }
            }

            //DataTextField é a propriedade do objeto que será mostrada na interface (página)
            ddlTipoDeProduto.DataTextField = "Nome";
            //DataValueField é a propriedade estará no atributo value do select no html
            ddlTipoDeProduto.DataValueField = "Id";
            //DataSource é a fonte de dados que o DropDownList receberá
            ddlTipoDeProduto.DataSource = lstTipos.OrderBy(o => o.Nome).ToList();
            //DataBind é para atualizar (refresh) o componente na página
            ddlTipoDeProduto.DataBind();
        }

        //Método para limpar os campos da tela
        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            ddlTipoDeProduto.ClearSelection();
            txtDescricao.Text = string.Empty;
        }

        //Método para validar os campos obrigatórios da página
        private bool Validar()
        {
            //Verificando se o campo está nulo ou vazio
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                return false;

            //Verificando se o campo está nulo ou vazio
            if (string.IsNullOrWhiteSpace(txtPreco.Text))
                return false;

            //Verificando se o campo está nulo ou vazio
            if (string.IsNullOrWhiteSpace(ddlTipoDeProduto.SelectedValue))
                return false;

            return true;
        }

        //Método para salvar os valores preenchidos na tela no banco de dados
        private void Salvar()
        {
            //Criando o objeto produto e preenchendo suas propriedades com os valores informados na tela
            var obj = new Produto();
            obj.Nome = txtNome.Text;
            obj.TipoDeProduto = new TipoDeProduto()
            {
                Id = Convert.ToInt32(ddlTipoDeProduto.SelectedValue)
            };
            obj.Preco = Convert.ToDecimal(txtPreco.Text);
            obj.Descricao = txtDescricao.Text;

            //Criando uma conexão com o banco de dados
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=SENAI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                //Criando instrução sql para inserir na tabela de cidades
                string strSQL = @"INSERT INTO produto (nome, id_tipo_produto, preco, descricao) 
                                  VALUES (@nome, @id_tipo_produto, @preco, @descricao)";

                //Criando um comando sql que será executado na base de dados
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    //Preenchendo os parâmetros da instrução sql
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@id_tipo_produto", SqlDbType.Int).Value = obj.TipoDeProduto.Id;
                    cmd.Parameters.Add("@preco", SqlDbType.Decimal).Value = obj.Preco;
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