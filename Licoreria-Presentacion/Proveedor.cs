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
    public partial class Proveedor : Form
    {
        private Producto padre;
        CNProveedor objetoCN = new CNProveedor();
        private string idProveedor = null;
        private bool Editar = false;
        public Proveedor(Producto parametro)
        {
            InitializeComponent();
            padre = parametro;
        }
        public Proveedor()
        {
            InitializeComponent();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            MostrarProveedor();
            txtIngrese.Enabled = false;
        }
        #region Eventos
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Checked == true)
            {
                txtNombre.Enabled = false;
                txtRUC.Enabled = false;
                txtTelefono.Enabled = false;
                txtIngrese.Enabled = true;

            }
            if (cbBuscar.Checked == false)
            {
                txtNombre.Enabled = true;
                txtRUC.Enabled = true;
                txtTelefono.Enabled = true;
                txtIngrese.Enabled = false;
                MostrarProveedor();
            }
        }
                         
        private void txtIngrese_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Checked == true)
            {
                BuscarProveedor();
            }
            else { MostrarProveedor(); }
        }
        private void dtgProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            padre.txtProv.Text = dtgProveedor.CurrentRow.Cells["ID"].Value.ToString();
            this.Close();
        }
        #endregion

        #region Metodos
        private void MostrarProveedor()
        {
            CNProveedor objeto = new CNProveedor();
            dtgProveedor.DataSource = objeto.MostrarC();
        }
        private void limpiarForm()
        {
            txtNombre.Clear();
            txtRUC.Clear();
            txtTelefono.Clear();
            txtIngrese.Clear();
        }

        private void BuscarProveedor()
        {
            CNProveedor objeto = new CNProveedor();
            dtgProveedor.DataSource = objeto.BuscarProv(txtIngrese.Text);
        }
        #endregion

        #region Botones
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.lblUsuarioVendedor.Text = lblUsuarioActual.Text;
            p.Show();
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    if (txtNombre.Text == "" || txtRUC.Text == "" || txtTelefono.Text == "")
                    {
                        MessageBox.Show("No es posible ingresar un proveedor vacio.", "Aviso");
                    }
                    else
                    {
                        objetoCN.InsertarProv(txtRUC.Text, txtNombre.Text, txtTelefono.Text);
                        //MessageBox.Show("Se insertó correctamente");
                        MostrarProveedor();
                        limpiarForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: ", "Aviso" + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea editar el proveedor?", "Aviso", btn, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        objetoCN.EditarProv(txtRUC.Text, txtNombre.Text, txtTelefono.Text, Int32.Parse(idProveedor));
                        //MessageBox.Show("Se editó correctamente", "Aviso");
                        MostrarProveedor();
                        limpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar los datos por: " + ex);
                    }
                }
                else if (res == DialogResult.Cancel) { }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgProveedor.SelectedRows.Count > 0)
            {
                Editar = true;
                txtRUC.Text = dtgProveedor.CurrentRow.Cells["RUC"].Value.ToString();
                txtNombre.Text = dtgProveedor.CurrentRow.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dtgProveedor.CurrentRow.Cells["Telefono"].Value.ToString();
                idProveedor = dtgProveedor.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor", "Aviso");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgProveedor.SelectedRows.Count > 0)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea eliminar el proveedor?", "Eliminar", btn, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    idProveedor = dtgProveedor.CurrentRow.Cells["ID"].Value.ToString();
                    objetoCN.EliminarProv(Int32.Parse(idProveedor));
                    //MessageBox.Show("Eliminado correctamente");
                    MostrarProveedor();
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha eliminado el proveedor seleccionado", "Aviso");
                    MostrarProveedor();
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor");
        }
        #endregion
        
        #region Validaciones
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                string msj = "El RUC deben ser solo numeros";
                string tlt = "Datos incorrectos";
                MessageBoxButtons btn = MessageBoxButtons.OK;
                DialogResult dr = MessageBox.Show(msj, tlt, btn, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
