using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
namespace T_Loja_Troca_Oleo
{
  public  class ClienteDAO
    {
        public List<Cliente> CarregarCliente()
        {
            using (SqlConnection conn = new
        SqlConnection(Properties.Settings.Default.conn))
            {
                string srtSQL = "select * from Clientes";
                DataTable dt = new DataTable();
                conn.Open();
                using (SqlCommand cmdo = new SqlCommand())
                {
                    cmdo.CommandType = CommandType.Text;
                    cmdo.Connection = conn;
                    cmdo.CommandText = srtSQL;
                    SqlDataReader dataReader;
                    dataReader = cmdo.ExecuteReader();
                    dt.Load(dataReader);
                    if (!(dt != null && dt.Rows.Count > 0))
                        return null;
                    List<Cliente> listaCliente = new List<Cliente>();
                    foreach (DataRow linha in dt.Rows)
                    {
                        Cliente C = new Cliente();
                        C.Nome = Convert.ToString(linha["Nome"]);
                        C.Email = Convert.ToString(linha["Email"]);
                        C.Veiculo = Convert.ToString(linha["Veiculo"]);
                        C.Placa = Convert.ToString(linha["Placa"]);
                        C.Codigo = Convert.ToInt32(linha["Codigo"]);
                        listaCliente.Add(C);
                    }
                    conn.Close();
                    return listaCliente;
                }
            }
        }
    }

}
}
