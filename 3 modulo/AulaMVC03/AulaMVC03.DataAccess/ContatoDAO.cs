using AulaMVC03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AulaMVC03.DataAccess
{
    public class ContatoDAO
    {
        public void Inserir(Contato obj)
        {
            //Criando uma conexão com o banco de dados
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog = SENAI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                //Criando instrução sql para inserir na tabela de cidades
                string strSQL = @"INSERT INTO contato (nome, endereco, telefone, mensagem)
                                 VALUES (@nome, @endereco, @telefone, @mensagem);";

                //Criando um comando sql que será executato na base de dados
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;
                    //Preenchendo os parâmetros da instrução sql
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@endereco", SqlDbType.VarChar).Value = obj.Endereco;
                    cmd.Parameters.Add("@telefone", SqlDbType.VarChar).Value = obj.Telefone;
                    cmd.Parameters.Add("@mensagem", SqlDbType.VarChar).Value = obj.Mensagem;

                    //Abrindo conexão com o banco de dados 
                    conn.Open();
                    //Executando instrução sql
                    cmd.ExecuteNonQuery();
                    //Fechando conexão com banco de dados 
                    conn.Close();
                }
            }
        }

        public List<Contato> BuscarTodos()
        {
            var lstContatos = new List<Contato>();

            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=SENAI;
                Data Source=localhost; 
                Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT * FROM contato;";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;

                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);

                    conn.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        var usuario = new Contato()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                            Endereco = row["endereco"].ToString(),
                            Telefone = row["telefone"].ToString(),
                            Mensagem = row["mensagem"].ToString()
                        };

                        lstContatos.Add(usuario);
                    }
                }
            }

            return lstContatos;
        }
    }

}
