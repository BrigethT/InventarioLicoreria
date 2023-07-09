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
using System.Data.SqlClient;
using System.Collections;

namespace Licoreria_Presentacion
{
    public partial class Producto : Form
    {
        //Atributos
        CNProducto objetoCN = new CNProducto();
        private string idProducto = null;
        private bool Editar = false;

        public Producto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        #region Eventos
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (chbBuscar.Checked == true)
            {
                BuscarProducto();
            }
        }

        
        private void chbBuscar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbBuscar.Checked == true)
            {
                txtStock.Enabled = false;
                txtPrecioCompra.Enabled = false;
                txtPrecioVenta.Enabled = false;
                txtProv.Enabled = false;
            }
            if (chbBuscar.Checked == false)
            {
                txtStock.Enabled = true;
                txtPrecioCompra.Enabled = true;
                txtPrecioVenta.Enabled = true;
                txtProv.Enabled = true;
                MostrarProductos();
            }
        }

        #endregion

        #region Botones
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto();
            chbBuscar.Checked = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea eliminar el producto?", "Eliminar", btn, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    objetoCN.EliminarP(idProducto);
                    //MessageBox.Show("Eliminado correctamente","Aviso");
                    MostrarProductos();
                }
                else if (res == DialogResult.Cancel)
                {
                    MessageBox.Show("No se ha eliminado el producto seleccionado", "Aviso");
                    MostrarProductos();
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor","Aviso");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                if (txtNombre.Text == "" || txtStock.Text == "" || txtPrecioCompra.Text == "   ," || txtPrecioVenta.Text == "   ,")
                {
                    MessageBox.Show("No es posible insertar un producto\ncon atributos vacios.", "Aviso");
                }
                else
                {
                    try
                    {
                        objetoCN.InsertarP(txtNombre.Text, int.Parse(txtStock.Text), decimal.Parse(txtPrecioCompra.Text), decimal.Parse(txtPrecioVenta.Text), int.Parse(txtProv.Text));
                        //MessageBox.Show("Se insertó correctamente","Aviso");
                        MostrarProductos();
                        limpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ingrese los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            //EDITAR
            if (Editar == true)
            {                
                try
                {
                    objetoCN.EditarP(txtNombre.Text, int.Parse(txtStock.Text), decimal.Parse(txtPrecioCompra.Text), decimal.Parse(txtPrecioVenta.Text), int.Parse(txtProv.Text), Int32.Parse(idProducto));
                    //MessageBox.Show("Se edito correctamente","Aviso");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea editar el producto?", "Editar", btn, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    Editar = true;
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                    txtProv.Text = dataGridView1.CurrentRow.Cells["ID Proveedor"].Value.ToString();
                    //txtPrecioCompra.Text = dataGridView1.CurrentRow.Cells["Precio Compra"].Value.ToString();
                    //txtPrecioVenta.Text = dataGridView1.CurrentRow.Cells["Precio Venta"].Value.ToString();
                    idProducto = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                }
                else if (res == DialogResult.Cancel) { }                
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
        private void btnProv_Click(object sender, EventArgs e)
        {
            Proveedor p = new Proveedor(this);
            p.ShowDialog();
        }
        #endregion

        #region Metodos
        private void MostrarProductos()
        {
            CNProducto objeto = new CNProducto();
            dataGridView1.DataSource = objeto.MostrarP();
            AvisoProductoPorTerminarse();

        }

        private void limpiarForm()
        {
            txtNombre.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtStock.Clear();
            txtProv.Text = "";
        }
        private void BuscarProducto()
        {
            CNProducto objeto = new CNProducto();
            dataGridView1.DataSource = objeto.BuscarP(txtNombre.Text);
        }

        private void AvisoProductoPorTerminarse()
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string nombre;
                nombre = dataGridView1.Rows[i].Cells["Nombre"].Value.ToString();
                if (Int32.Parse(dataGridView1.Rows[i].Cells["Stock"].Value.ToString()) <= 10)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    lblAviso.Text = "Se han marcado en rojo los productos por terminarse.";
                    //MessageBox.Show("Se esta acabando el producto: " + nombre, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region Validaciones
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar >= 33 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            //{
            //    string msj = "El nombre  del producto deben ser solo letras";
            //    string tlt = "Datos incorrectos";
            //    MessageBoxButtons btn = MessageBoxButtons.OK;
            //    DialogResult dr = MessageBox.Show(msj, tlt, btn);
            //    e.Handled = true;
            //    return;

            //}
        }
        #endregion


    }
}