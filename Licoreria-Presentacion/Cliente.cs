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
    public partial class Cliente : Form
    {
        private Venta padre;

        CNCliente objetoCN = new CNCliente();
        private string idCliente = null;
        private bool Editar = false;
        public Cliente(Venta parametro)
        {
            InitializeComponent();
            padre = parametro;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void txtIngrese_TextChanged(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea editar el cliente?", "Editar", btn, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                if (dtgCliente.SelectedRows.Count > 0)
                {
                    Editar = true;
                    txtCedula.Text = dtgCliente.CurrentRow.Cells["Cedula"].Value.ToString();
                    txtNombre.Text = dtgCliente.CurrentRow.Cells["Nombre Cliente"].Value.ToString();
                    txtDireccion.Text = dtgCliente.CurrentRow.Cells["Direccion"].Value.ToString();
                    txtTelefono.Text = dtgCliente.CurrentRow.Cells["Telefono"].Value.ToString();
                    idCliente = dtgCliente.CurrentRow.Cells["ID"].Value.ToString();
                }
                else
                    MessageBox.Show("Seleccione una fila por favor", "Aviso");
            }
            else if (res == DialogResult.Cancel) { }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                if (txtCedula.Text == "" || txtDireccion.Text == "" || txtNombre.Text == "" || txtTelefono.Text == "")
                {
                    MessageBox.Show("No es posible agregar un cliente\ncon campos vacios", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    try
                    {
                        if (txtCedula.MaskCompleted && txtTelefono.MaskCompleted) {
                            objetoCN.InsertarC(txtCedula.Text, txtNombre.Text, txtTelefono.Text, txtDireccion.Text);
                            //MessageBox.Show("Se insertó correctamente", "Aviso");
                            MostrarClientes();
                            limpiarForm();
                        }
                        else
                        {
                            MessageBox.Show("Complete los datos de acuerdo al formato.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo insertar los datos por: " + ex);
                    }
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarC(txtCedula.Text, txtNombre.Text, txtTelefono.Text, txtDireccion.Text, Int32.Parse(idCliente));
                    //MessageBox.Show("Se editó correctamente", "Aviso");
                    MostrarClientes();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgCliente.SelectedRows.Count > 0)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea eliminar el cliente?", "Eliminar", btn, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    idCliente = dtgCliente.CurrentRow.Cells["ID"].Value.ToString();

                    objetoCN.EliminarC(idCliente);
                    //MessageBox.Show("Eliminado correctamente", "Aviso");
                    MostrarClientes();
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha eliminado el cliente seleccionado", "Aviso");
                    MostrarClientes();
                }                
            }
            else
                MessageBox.Show("Seleccione una fila por favor", "Aviso");
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            padre.txtCedula.Text = dtgCliente.CurrentRow.Cells["Cedula"].Value.ToString();
            padre.txtNombreCliente.Text = dtgCliente.CurrentRow.Cells["Nombre Cliente"].Value.ToString();
            padre.txtDireccionCliente.Text = dtgCliente.CurrentRow.Cells["Direccion"].Value.ToString();
            this.Close();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodos
        private void MostrarClientes()
        {
            CNCliente objeto = new CNCliente();
            dtgCliente.DataSource = objeto.MostrarC();
        }


        private void limpiarForm()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtDireccion.Text = "";
            txtTelefono.Clear();
        }
        private void BuscarClientes()
        {
            CNCliente objeto = new CNCliente();
            dtgCliente.DataSource = objeto.BuscarC(txtIngrese.Text);
        }

        #endregion
    }

}
