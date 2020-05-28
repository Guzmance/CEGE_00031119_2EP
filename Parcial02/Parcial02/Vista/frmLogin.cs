using System;
using System.Windows.Forms;
using Parcial02.Controlador;
using Parcial02.Modelo;

namespace Parcial02.Vista
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            PoblarControles();
        }
        
         private void PoblarControles()
                {
                    comboBox1.DataSource = null;
                    comboBox1.ValueMember = "password";
                    comboBox1.DisplayMember = "username";
                    comboBox1.DataSource =UsuarioDAO.getLista();
                }

         private void button2_Click(object sender, EventArgs e)
         {
             frmActualizarContraseña unaVentana = new frmActualizarContraseña();
             unaVentana.ShowDialog();
             PoblarControles();
         }


         private void button1_Click(object sender, EventArgs e)
         {
             if (Encriptador.CompararMD5(textBox1.Text, comboBox1.SelectedValue.ToString()))
             {
                 Usuario u = (Usuario) comboBox1.SelectedItem;

                 
                     MessageBox.Show("¡Bienvenido!", 
                         "Inicio-CEGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                     frmPrincipal ventana = new frmPrincipal(u);
                     ventana.Show();
                     this.Hide();
                
             
             }
             else
                 MessageBox.Show("¡Contraseña incorrecta!", "Inicio-CEGE",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }


         private void textBox1_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter) button1_Click(sender, e);
         }
    }
}