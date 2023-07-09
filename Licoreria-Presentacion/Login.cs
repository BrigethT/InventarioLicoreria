using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Licoreria_Entidades;
using Licoreria_Negocio;

namespace Licoreria_Presentacion
{
    public partial class Login : Form
    {
        EListaVendedor lista = new EListaVendedor();
        CNVendedor vendedor1 = new CNVendedor();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            label2.ForeColor = Color.Yellow;
            cbxUsuario.DataSource = vendedor1.ObtenerVendedores();
            cbxUsuario.SelectedItem = -1;
            labelAviso.Visible = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();


            lista.setListac(vendedor1.ObtenerVendedores());
            if (cbxUsuario.SelectedItem == null)
            {
                if (cbxUsuario.Text != "")
                {
                    labelAviso.Visible = true;
                    labelAviso.Text = "!Usuario Incorrecto¡ Ingrese Nuevamente.";
                    //MessageBox.Show("Usuario Incorrecto Ingrese Nuevamente");
                    
                }
                else if (cbxUsuario.Text == "")
                {
                    labelAviso.Visible = false;
                    cbxUsuario.Text = "Usuario por defecto";
                    p.lblUsuarioVendedor.Text = cbxUsuario.Text;
                    EVendedor vendordefecto = new EVendedor("User");
                    MessageBox.Show("Ingreso por Usuario por defecto Exitoso");
                    p.Show();
                    this.Hide();
                }
            }
            else if (lista.devolver2(cbxUsuario.SelectedItem.ToString()) == true)
            {
                labelAviso.Visible = false;
                //MessageBox.Show("Usuario Exitoso");
                p.lblUsuarioVendedor.Text = cbxUsuario.Text;
                p.Show();
                this.Hide();
            }
             
        }

    }
}
