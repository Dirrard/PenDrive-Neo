using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DropDownListMVC.Models;

namespace DropDownListMVC.DataAccess
{
    public class EstadoDAO
    {
        public void Inserir(Estado obj)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=DropDownListMVC;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"INSERT INTO estado(nome,sigla,descricao)
                                 VALUES (@nome,@sigla,@descricao);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@sigla", SqlDbType.VarChar).Value = obj.Sigla;
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = obj.Descricao;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
        }

        public List<Estado> BuscarTodos()
        {
            var lst = new List<Estado>();

            using (SqlConnection conn =
                 new SqlConnection(@"Initial Catalog=DropDownListMVC;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT * FROM estado;";

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
                        var estado = new Estado()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                            Sigla = row["sigla"].ToString(),
                            Descricao = row["descricao"].ToString(),
                        };
                        lst.Add(estado);
                    }
                }
            }
            return lst;
        }
    }


}
