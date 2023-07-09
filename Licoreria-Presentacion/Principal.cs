using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licoreria_Presentacion
{
    public partial class Principal : Form
    {
        
        public Principal()
        {
            InitializeComponent();
            
        }

        private void btnPrincipalUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            u.lblUsuarioActual.Text = lblUsuarioVendedor.Text;
            u.Show();
            this.Hide();
        }

        private void btnPrincipalProductos_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.lblUsuarioActual.Text = lblUsuarioVendedor.Text;
            p.Show();
            this.Hide();
        }

        private void btnPrincipalVenta_Click(object sender, EventArgs e)
        {
            Venta v = new Venta();
            v.lbnombreUsuario.Text = lblUsuarioVendedor.Text;
            v.Show();
            this.Hide();
        }

        private void BtnPrincipalProveedores_Click(object sender, EventArgs e)
        {
            Proveedor p = new Proveedor();
            p.lblUsuarioActual.Text = lblUsuarioVendedor.Text;
            p.Show();
            this.Hide();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        //Regresar
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea salir?", "Salir", btn, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Login p = new Login();
                p.Show();
                this.Close();
            }
            else if (res == DialogResult.Cancel){ }
            
        }
    }
}
