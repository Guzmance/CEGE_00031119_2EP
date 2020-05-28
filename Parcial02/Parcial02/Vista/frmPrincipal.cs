using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Parcial02.Modelo;

namespace Parcial02.Vista
{
    public partial class frmPrincipal : Form
    {
        private static Usuario usuario;

        public frmPrincipal(Usuario pusuario)
        {
            InitializeComponent();
            usuario = pusuario;
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            label1.Text =
                "Bienvenido " + usuario.fullname + " [" + (usuario.usertype ? "Administrador" : "Usuario") + "]";

            if (usuario.usertype)
            {
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;
                tabControl1.TabPages[0].Parent= null;

                actualizarControles();
            }
            else
            {

                   tabControl1.TabPages[5].Parent = null;
                   tabControl1.TabPages[5].Parent = null;
                   tabControl1.TabPages[5].Parent = null;
                   tabControl1.TabPages[5].Parent = null;
                

                actualizarControles();
            }
        }

        private void actualizarControles()
        {

            List<Usuario> usu = UsuarioDAO.getLista();
            List<Address> addr = AddressDAO.addresslist();
            List<Order> ord = OrderDAO.orderlist();
            List<Enterprise> ent = EnterpriseDAO.businesslist();
            List<Product> prod = ProductDAO.productlist();
            List<Address> propaddress = AddressDAO.idaddresslist(usuario.iduser);
            List<Order> proporder = OrderDAO.iduserorder(usuario.iduser);
           
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = propaddress;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = proporder;

            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "idaddress";
            comboBox1.DataSource = addr;


            comboBox2.DataSource = null;
            comboBox2.DisplayMember = "idaddress";
            comboBox2.DataSource = addr;



            comboBox3.DataSource = null;
            comboBox3.DisplayMember = "idproduct";
            comboBox3.DataSource = prod;

            comboBox4.DataSource = null;
            comboBox4.DisplayMember = "idorder";
            comboBox4.DataSource = ord;
            

            
            comboBox5.DataSource = null;
            comboBox5.DisplayMember ="idbusiness";
            comboBox5.DataSource = ent;

            comboBox6.DataSource = null;
            comboBox6.DisplayMember = "idbusiness";
            comboBox6.DataSource = ent;

            comboBox7.DataSource = null;
            comboBox7.DisplayMember = "idproduct";
            comboBox7.DataSource = prod;
            
            comboBox8.DataSource = null;
            comboBox8.DisplayMember = "idaddress";
            comboBox8.DataSource = addr;

            comboBox9.DataSource = null;
            comboBox9.DisplayMember = "iduser";
            comboBox9.DataSource = usu;


        }



        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Seguro que desea salir, " + usuario.fullname + "?",
                    "CEGE APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel =
                        e.Cancel = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha sucedido un error, favor intente dentro de un minuto.",
                    "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

    private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
    {
    Application.Exit();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (textBox1.Text.Length >= 5)
            {
                AddressDAO.crearaddress(usuario.iduser,textBox1.Text);
        
                MessageBox.Show("¡Dirección Agregada Exitosamente!",
                    "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
                textBox1.Clear();
                actualizarControles();
            }
            else
                MessageBox.Show("Favor digite una dirección mas detallada (longitud minima, 10 caracteres)",
                    "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        catch (Exception)
        {
            MessageBox.Show("La dirección no se encuentra disponible",
                "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
    try
    {

     
        actualizarControles();
        
        
        MessageBox.Show("Datos obtenidos Exitosamente");
    }
    catch (Exception)
    {
        MessageBox.Show("Ha ocurrido un problema");
    }

    }

    private void button3_Click(object sender, EventArgs e)
    {
    AddressDAO.actualizaraddress(comboBox1.Text, textBox2.Text);

    MessageBox.Show("¡Dirección actualizada exitosamente!",
    "CEGE-APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

    actualizarControles();
    }

    private void button14_Click(object sender, EventArgs e)
    {
    if (MessageBox.Show("¿Seguro que desea eliminar la dirección " + comboBox8.Text + "?",
    "CEGE APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        AddressDAO.eliminar(comboBox8.Text);

        MessageBox.Show("¡Dirección eliminada exitosamente!",
            "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

        actualizarControles();
    }
    }





    private void button4_Click(object sender, EventArgs e)
    {
     
    OrderDAO.addorder(DateTime.Now, comboBox3.Text, comboBox2.Text);

    MessageBox.Show("¡Orden Realizada exitosamente!",
    "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

    actualizarControles();

    }


    private void button5_Click(object sender, EventArgs e)
    {
    if (MessageBox.Show("¿Seguro que desea eliminar el pedido " + comboBox4.Text + "?",
    "CEGE APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        OrderDAO.eliminar(comboBox4.Text);

        MessageBox.Show("¡Pedido eliminado exitosamente!",
            "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

        actualizarControles();
    }
    }

    private void button6_Click(object sender, EventArgs e)
    {

    try
    {
       
     actualizarControles();

        MessageBox.Show("Datos obtenidos Exitosamente");
    }
    catch (Exception)
    {
        MessageBox.Show("Ha ocurrido un problema");
    }




    }
    private void button7_Click(object sender, EventArgs e)
    {
    UsuarioDAO.crearNuevo(textBox4.Text);

    MessageBox.Show("¡Usuario Creado exitosamente!",
    "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
    textBox4.Clear();
    actualizarControles();

    }

    private void button8_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("¿Seguro que desea eliminar el usuario " + comboBox9.Text + "?",
            "CEGE APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            UsuarioDAO.eliminar(comboBox9.Text);

            MessageBox.Show("¡Usuario eliminado exitosamente!",
                "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

            actualizarControles();
        }
    }
    private void button9_Click(object sender, EventArgs e)
    {
    try
    {
        if (textBox5.Text.Length > 0 && textBox6.Text.Length > 0)
        {
            EnterpriseDAO.addbusiness(textBox5.Text, textBox6.Text);

            MessageBox.Show("¡Empresa agregad exitosamente!",
                "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox5.Clear();
            textBox6.Clear();
            actualizarControles();

        }
        else
            MessageBox.Show("No deje espacios en blanco",
                "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    catch (Exception)
    {
        MessageBox.Show("El producto que ha digitado, no se encuentra disponible.",
            "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }


    }

    private void button10_Click(object sender, EventArgs e)
    {
    if (MessageBox.Show("¿Seguro que desea eliminar la empresa" + comboBox5.Text + "?",
    "CEGE APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        EnterpriseDAO.eliminar(comboBox5.Text);

        MessageBox.Show("¡Empresa eliminada exitosamente!",
            "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

        actualizarControles();
    }
    }


    private void button11_Click(object sender, EventArgs e)
    {
    ProductDAO.addproduct(comboBox6.Text, textBox7.Text);

    MessageBox.Show("¡Producto Agregado exitosamente!",
    "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

    actualizarControles();
    }


    private void button12_Click(object sender, EventArgs e)
    {
    if (MessageBox.Show("¿Seguro que desea eliminar el producto " + comboBox7.Text + "?",
    "CEGE APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        ProductDAO.deleteproduct(comboBox7.Text);

        MessageBox.Show("¡Producto eliminado exitosamente!",
            "CEGE APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

        actualizarControles();
    }
    }


    private void button13_Click(object sender, EventArgs e)
    {
        List<Order> ord = OrderDAO.orderlist();
        dataGridView4.DataSource = null;
        dataGridView4.DataSource = ord;
    }


    private void button15_Click(object sender, EventArgs e)
    {
        List<Usuario> usu = UsuarioDAO.getLista();
        dataGridView3.DataSource = null;
        dataGridView3.DataSource = usu;

    }

   
    }
}