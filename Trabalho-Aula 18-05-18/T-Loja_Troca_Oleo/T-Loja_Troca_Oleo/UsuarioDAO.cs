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
   public static class UsuarioDAO
    {
        public static Usuario Logar(Usuario obj)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.conn)
            {
                string srtSQL = @"Select * from Usuario  where Email = @email and Senha = @Senha;";

                DataTable dt = new DataTable();
                conn.Open();
                using (SqlCommand cmdo = new SqlCommand())
                {
                    cmdo.CommandType = CommandType.Text;
                    cmdo.Connection = conn;
                    cmdo.CommandText = srtSQL;
                cmdo.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email;
                cmdo.Parameters.Add("@Senha", SqlDbType.VarChar).Value = obj.Senha;

                SqlDataReader dataReader;
                dataReader = cmdo.ExecuteReader();
                dt.Load(dataReader);

                if (!(dt != null && dt.Rows.Count > 0))
                    return null;

                var row = dt.Rows[0];
                var usuario = new Usuario()
                {
                    Email = row["email"].ToString(),
                    Senha= row["senha"].ToString()
                };
                conn.Close();
                return usuario;

            }
            
            }


        }
    }
}
