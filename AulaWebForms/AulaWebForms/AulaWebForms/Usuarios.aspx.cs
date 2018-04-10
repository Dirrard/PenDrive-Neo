using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AulaWebForms
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            CarregarGridView();
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        private void CarregarGridView()
        {
            using (SqlConnection conn =
                new SqlConnection(@"Initial Catalog=SENAI;
                        Data Source=localhost;
                        Integrated Security=SSPI;"))
            {
                string strSQL = @"SELECT * FROM usuario";

                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = strSQL;
                    var dataReader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(dataReader);
                    conn.Close();

                    var lstUsuarios = new List<Usuario>();
                    foreach (DataRow row in dt.Rows)
                    {
                        lstUsuarios.Add(new Usuario()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nome = row["nome"].ToString(),
                            Login = row["login"].ToString(),
                            Senha = row["senha"].ToString(),
                            Cidade = row["cidade"].ToString(),
                            Estado = row["estado"].ToString(),
                            Sexo = row["sexo"].ToString(),
                            Administrador = Convert.ToBoolean(row["administrador"]),
                            Descricao = row["descricao"].ToString()
                        });
                    }

                    grdUsuarios.DataSource = lstUsuarios;
                    grdUsuarios.DataBind();
                }
            }
        }
    }
}