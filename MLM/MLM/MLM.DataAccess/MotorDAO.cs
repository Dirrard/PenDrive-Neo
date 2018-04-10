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
    public class MotorDAO
    {
        public void Inserir(Motor obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"INSERT INTO MOTOR(TRASMISSAO,NOME, POTENCIA, PRECO) VALUES (@TRASMISSAO,@NOME, @POTENCIA, @PRECO);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@TRANSMISSAO", SqlDbType.VarChar).Value = obj.Transmissao;
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@POTENCIA", SqlDbType.VarChar).Value = obj.Potencia;
                    cmd.Parameters.Add("@PRECO", SqlDbType.VarChar).Value = obj.Preco;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public List<Motor> BuscarTodos()
        {
            var lst = new List<Motor>();

            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM MOTOR;";

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
                        var motor = new Motor()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Transmissao = row["transmissao"].ToString(),
                            Nome = row["nome"].ToString(),
                            Potencia = Convert.ToInt32(row["potencia"]),
                            Preco = Convert.ToDecimal(row["preco"]),
                        };

                        lst.Add(motor);
                    }
                }
            }

            return lst;
        }
    }
}
