using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AulaWebForms
{
    public partial class ListaDeTipos : System.Web.UI.Page
    {
        //Evento de carregamento da página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica se é a primeira vez que está carregando a página
            if (IsPostBack)
                return;
            //Chamando método para carregar o GridView com os registros
            CarregarGridView();
        }

        //Evento de clique do botão Cadastro
        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            //Redirecionando para a página de cadastro de tipos de produto
            Response.Redirect("~/CadastroDeTipo.aspx");
        }

        //Método para carregar a GridView de tipos de produto
        private void CarregarGridView()
        {
            var lstTipos = new List<TipoDeProduto>();

            //Criando uma conexão com o banco de dados
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=SENAI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                //Criando instrução sql para selecionar todos os registros na tabela de tipos de produto
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

                    //DataSource é a fonte de dados que o GridView receberá
                    grdTipos.DataSource = lstTipos;
                    //DataBind é para atualizar (refresh) o componente na página
                    grdTipos.DataBind();
                }
            }
        }
    }
}