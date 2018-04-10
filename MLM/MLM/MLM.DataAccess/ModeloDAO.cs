using MLM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MLM.DataAccess
{
    public class ModeloDAO
    {
        public void Inserir(Modelo obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"INSERT INTO MODELO(NOME, DESCRICAO, PRECO) VALUES (@NOME,@DESCRICAO,@PRECO);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar).Value = obj.Descricao;
                    cmd.Parameters.Add("@PRECO", SqlDbType.VarChar).Value = obj.Preco;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public List<Modelo> BuscarTodos()
        {
            var lst = new List<Modelo>();

            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM MODELO;";

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
                        var modelo = new Modelo()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                            Descricao = row["descricao"].ToString(),
                            Preco = Convert.ToDecimal(row["preco"]),
                        };

                        lst.Add(modelo);
                    }
                }
            }

            return lst;
        }
    }
}

