using System;
using System.Windows.Forms;
using Parcial02.Controlador;
using Parcial02.Modelo;

namespace Parcial02.Vista
{
    public partial class frmActualizarContraseña : Form
    {
        public frmActualizarContraseña()
        {
            InitializeComponent();
        }


        private void frmActualizarContraseña_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "password";
            comboBox1.DisplayMember = "iduser";
            comboBox1.DataSource = UsuarioDAO.getLista();
        }

        private void button1_Click_1(object sender, EventArgs e)
            {
                bool actualIgual = Encriptador.CompararMD5(textBox1.Text, comboBox1.SelectedValue.ToString());
                bool nuevaIgual = textBox2.Text.Equals(textBox3.Text);
                bool nuevaValida = textBox2.Text.Length > 0;

                if (actualIgual && nuevaIgual && nuevaValida)
                {
                    try
                    {
                        UsuarioDAO.actualizarContra(comboBox1.Text, Encriptador.CrearMD5(textBox2.Text));
                        MessageBox.Show("¡Contraseña actualizada exitosamente!",
                            "Actualizar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("¡Contraseña no actualizada! Favor intente mas tarde.",
                            "Actualizar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("¡¡Favor verifique que los datos sean correctos!",
                        "semana 09 ejercicio 01", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
