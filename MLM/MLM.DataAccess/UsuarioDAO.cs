using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using MLM.Models;

namespace MLM.DataAccess
{
    public class UsuarioDAO
    {
        public void Inserir(Usuario obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM; Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"INSERT INTO USUARIO (NOME, EMAIL, SENHA, PERMISSAO) VALUES (@NOME, @EMAIL, @SENHA, @PERMISSAO);";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = obj.Nome;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = obj.Email;
                    cmd.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = obj.Senha;
                    cmd.Parameters.Add("@PERMISSAO", SqlDbType.Bit).Value = obj.Permissao;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public void Inserir_Carro(Usuario obj)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"UPDATE USUARIO 
                SET ID_MODELO = '@ID_MODELO' ,
                ID_MOTOR='@ID_MOTOR',
                ID_INTERIOR='@ID_INTERIOR',
                ID_COR = '@ID_COR' 
                WHERE ID = '" + obj.Id + "' ;";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@ID_MODELO", SqlDbType.VarChar).Value = obj.Modelo.Id;
                    cmd.Parameters.Add("@ID_MOTOR", SqlDbType.VarChar).Value = obj.Motor.Id;
                    cmd.Parameters.Add("@ID_INTERIOR", SqlDbType.VarChar).Value = obj.Interior.Id;
                    cmd.Parameters.Add("@ID_COR", SqlDbType.VarChar).Value = obj.Cor.Id;


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public Usuario Mostrar(int Id)
        {


            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM;Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT 
                                    u.nome, 
                                    m.nome as nome_modelo ,
                                    m.preco as preco_modelo, 
                                    mo.nome as nome_motor,
                                    mo.preco as preco_motor,
                                    c.nome as nome_cor,
                                    i.radio as radio_interior,
                                    i.ac as ac_interior,
                                    i.volante as v_interior,
                                    i.banco as banco_interior,
                                    i.preco as preco_interior 
                                FROM usuario u 
                                INNER JOIN modelo m ON (m.id = u.id_modelo) 
                                INNER JOIN  motor mo ON (mo.id = u.id_motor)
                                INNER JOIN  cor c ON (c.id = u.id_cor)
                                INNER JOIN  interior i ON (i.id = u.id_interior) 
                                where u.id = '" + Id + "' ;";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        Usuario u = new Usuario();
                        u.Modelo = new Modelo() { Nome = Convert.ToString(row["nome_modelo"]) };
                        u.Nome = Convert.ToString(row["nome"]);
                        u.Motor = new Motor() { Nome = Convert.ToString(row["nome_motor"]) };
                        u.Interior = new Interior();
                        u.Interior.Radio = Convert.ToString(row["radio_interior"]);
                        u.Interior.Volante = Convert.ToString(row["v_interior"]);
                        u.Interior.Ac = Convert.ToString(row["ac_interior"]);
                        u.Interior.Banco = Convert.ToString(row["banco_interior"]);
                        u.Cor = new Cor() { Nome = Convert.ToString(row["nome_cor"]) };

                        decimal V = Convert.ToDecimal(row["preco_modelo"]);
                        decimal A = Convert.ToDecimal(row["preco_motor"]);
                        decimal L = Convert.ToDecimal(row["preco_interior"]);
                        u.Valor = (V + A + L);

                        return u;
                    }
                    return null;
                }
            }
        }

        public Usuario Logar_U(Usuario u)
        {
            using (SqlConnection conn = new SqlConnection(@"Initial Catalog=MLM; Data Source = localhost; Integrated Security=SSPI"))
            {
                string strSQL = @"SELECT * FROM USUARIO WHERE EMAIL = '" + u.Email + "' AND SENHA= '" + u.Senha + "'";

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
                        var usuario = new Usuario()
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Email = row["EMAIL"].ToString(),
                            Senha = row["SENHA"].ToString()

                        };

                        return usuario;
                    }
                }
            }
            return null;
        }
    }
}
