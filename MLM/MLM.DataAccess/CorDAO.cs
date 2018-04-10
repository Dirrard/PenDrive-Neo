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
    public class CorDAO
    {
        public void Inserir(Cor obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"INSERT INTO COR (NOME) VALUES (@NOME);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = obj.Nome;
           

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public List<Cor> BuscarTodos()
        {
            var lst = new List<Cor>();

            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM COR;";

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
                        var cor = new Cor()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                        
                        };

                        lst.Add(cor);
                    }
                }
            }

            return lst;
        }
    }
}
