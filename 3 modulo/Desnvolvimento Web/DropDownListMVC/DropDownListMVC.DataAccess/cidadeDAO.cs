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
    public class cidadeDAO
    {
        public void Inserir(Cidade obj)
        {
            {
                using (SqlConnection conn =
                    new SqlConnection(@"Initial Catalog=DropDownListMVC;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
                {
                    string strSQL = @"INSERT INTO estado(nome,id_estado,descricao)
                                 VALUES (@nome,@id_estado,@descricao);";

                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        cmd.Connection = conn;

                        cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = obj.Nome;
                        cmd.Parameters.Add("@sigla", SqlDbType.VarChar).Value = obj.Estado.Id;
                        cmd.Parameters.Add("@descricao", SqlDbType.VarChar).Value = obj.Descricao;

                        conn.Open();

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
            }


        }

        public List<Cidade> BuscarTodos()
        {
            var lst = new List<Cidade>();

            using (SqlConnection conn =
                 new SqlConnection(@"Initial Catalog=DropDownListMVC;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT 
                                    c.*,
                                    e.nome as nome_estado
                                 FROM cidade c 
                                INNER JOIN estado e ON (e.id = c.id_estado);";

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
                        var cidade = new Cidade()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                            Estado = new Estado()
                            {
                                Id = Convert.ToInt32(row["id_estado"]),
                                Nome = row["nome_estado"].ToString(),

                            },
                            Descricao = row["descricao"].ToString(),
                        };
                        lst.Add(cidade);
                    }
                }
            }
            return lst;
        }
    }
}
