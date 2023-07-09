using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Licoreria_Negocio;

namespace Licoreria_Presentacion
{
    public partial class Usuarios : Form
    {
        CNVendedor objetoCN = new CNVendedor();
        private string idVendedor = null;
        private bool Editar = false;
        public Usuarios()
        {
            InitializeComponent();
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            MostrarVendedor();
        }

        //Metodos
        private void MostrarVendedor()
        {
            CNVendedor objeto = new CNVendedor();
            dataGridView1.DataSource = objeto.MostrarV();
        }
        private void limpiarForm()
        {
            txtNombreUsuario.Clear();

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    if (txtNombreUsuario.Text == "")
                    {
                        MessageBox.Show("No es posible guardar un vendedor vacio","Aviso");
                    }
                    else
                    {
                        objetoCN.InsertarVend(txtNombreUsuario.Text);
                        MessageBox.Show("Se insertó correctamente");
                        MostrarVendedor();
                        limpiarForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarVend(txtNombreUsuario.Text, Int32.Parse(idVendedor));
                    MessageBox.Show("Se editó correctamente","Notificación");
                    MostrarVendedor();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombreUsuario.Text = dataGridView1.CurrentRow.Cells["Nombre Vendedor"].Value.ToString();
                idVendedor = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor","Aviso");
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea eliminar el vendedor?", "Eliminar", btn, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    idVendedor = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                    string nombre = dataGridView1.CurrentRow.Cells["Nombre Vendedor"].Value.ToString();
                    if (lblUsuarioActual.Text == nombre)
                    {
                        MessageBox.Show("No es posible elimiar el vendedor actual","Error");
                    }
                    else 
                    {
                        objetoCN.EliminarVend(Int32.Parse(idVendedor));
                        //MessageBox.Show("Eliminado correctamente");
                        MostrarVendedor();
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha eliminado el vendedor seleccionado", "Aviso");
                    MostrarVendedor();
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor","Aviso");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.lblUsuarioVendedor.Text = lblUsuarioActual.Text;
            p.Show();
            this.Close();
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                string msj = "El nombre deben ser solo letras";
                string tlt = "Datos incorrectos";
                MessageBoxButtons btn = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show(msj, tlt, btn);
                e.Handled = true;
                return;

            }
        }
    }
}
