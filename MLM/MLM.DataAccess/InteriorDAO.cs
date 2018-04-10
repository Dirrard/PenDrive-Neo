using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLM.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace MLM.DataAccess
{
   public class InteriorDAO
    {
        public void Inserir(Interior obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"INSERT INTO Interior(BANCO,RADIO,VOLANTE,PRECO,AC,NOME) VALUES (@BANCO,@RADIO,@VOLANTE,@PRECO,@AC,@NOME);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@BANCO", SqlDbType.VarChar).Value = obj.Banco;
                    cmd.Parameters.Add("@RADIO", SqlDbType.VarChar).Value = obj.Radio;
                    cmd.Parameters.Add("@VOLANTE", SqlDbType.VarChar).Value = obj.Volante;
                    cmd.Parameters.Add("@PRECO", SqlDbType.VarChar).Value = obj.Preco;
                    cmd.Parameters.Add("@AC", SqlDbType.VarChar).Value = obj.Ac;
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = obj.Nome;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public List<Interior> BuscarTodos()
        {
            var lst = new List<Interior>();

            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM INTERIOR;";

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
                        var interior = new Interior()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Banco= row["BANCO"].ToString(),
                             Ac= row["AC"].ToString(),
                             Radio= row["RADIO"].ToString(),
                            Volante = row["VOLANTE"].ToString(),
                            Preco = Convert.ToDecimal(row["preco"]),
                            Nome = row["NOME"].ToString()
                        };

                        lst.Add(interior);
                    }
                }
            }

            return lst;
        }
    }
}
