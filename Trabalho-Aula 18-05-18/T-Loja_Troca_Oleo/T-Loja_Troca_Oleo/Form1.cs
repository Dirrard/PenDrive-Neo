using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Loja_Troca_Oleo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTela_Login_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.Email = txtEmail.Text;
            obj.Senha = txtSenha.Text;
            try
            {
                var usuario = UsuarioDAO.Logar(obj);
                if (!usuario.Senha.Equals(txtSenha.Text))
                {
                    txtSenha.Clear();
                    MessageBox.Show("Senha invalida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenha.Focus();

                }
                else
                {
                    MessageBox.Show("Logado Com Sucesso");
                }

            }
            catch (Exception er)
            {
                MessageBox.Show("Erro: " + er.Message);
            }
        }
    }
}
