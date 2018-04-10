using Aula2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Aula2.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            //Criando uma lista vazia
            var lstUsuarios = new List<Usuario>();

            //Criando uma conexão com o banco de dados
            using (SqlConnection conn =
               new SqlConnection(@"Initial Catalog=mvc02;
                      Data Source=localhost;
                      Integrated Security=SSPI;"))

            {
                //Criando intrução sql para selecionar todos os registros na tabela de nomes     
                string strSQL = @"SELECT * FROM usuario";

                //Criando um comando sql que será executado na base de dados
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    //Abrindo conexão com o baco de dados
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    //Executando instrução sql
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    //Fechando conexão com o bd
                    conn.Close();

                    //Precorrendo todos os registros encontrados na base de dados e add a uma lista
                    foreach (DataRow row in dt.Rows)
                    {

                        var usuario = new Usuario()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                            Endereco = row["endereco"].ToString(),
                            Telefone = row["telefone"].ToString()
                        };
                        lstUsuarios.Add(usuario);
                    }
                }
            }

            //Retornado uma view chamada 'Index' com a lista de usuários carregados do bd
            return View(lstUsuarios);
        }


        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Salvar(Usuario obj)
        {
            using (SqlConnection conn =
              new SqlConnection(@"Initial Catalog= mvc02;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                //Criando instrução sql para inserir na tabela 
                string strSQL = @"INSERT INTO usuario (nome, endereco, telefone) VALUES (@nome, @endereco, @telefone)";

                //Criando um comando sql que será executado na base de dados
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    //Preenchendo os parâmetros da instrução sql
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@endereco", SqlDbType.VarChar).Value = obj.Endereco;
                    cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = obj.Telefone;

                    //Abrindo conexão com o banco de dados
                    conn.Open();
                    //Executando instrução sql
                    cmd.ExecuteNonQuery();
                    //Fechando conexão com o banco de dados
                    conn.Close();
                    return RedirectToAction("Index", "Usuario");
                }
            }
        }
    }
}