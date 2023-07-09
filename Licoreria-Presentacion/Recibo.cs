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
    public partial class Recibo : Form
    {
        Bitmap bmp;
        public Recibo()
        {
            InitializeComponent();
        }


        private void Recibo_Load(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("LICORERIA EL BODEGÓN DORADO", new Font("Arial",20,FontStyle.Bold), Brushes.Black, new Point(180,10));
            e.Graphics.DrawString("Comprobante de venta",new Font("Arial",16,FontStyle.Bold),Brushes.Black,new Point(290, 40));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Bold),Brushes.Black,new Point(0,60));
            e.Graphics.DrawString("Datos Cliente", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(40, 80));
            e.Graphics.DrawString("Cedula:", new Font("Arial", 14), Brushes.Black, new Point(40, 100));
            e.Graphics.DrawString(lblCedula.Text, new Font("Arial", 14), Brushes.Black, new Point(110, 100));
            e.Graphics.DrawString("Nombre:",new Font("Arial", 14), Brushes.Black, new Point(40, 120));
            e.Graphics.DrawString(lblNombre.Text, new Font("Arial", 14), Brushes.Black, new Point(120, 120));
            e.Graphics.DrawString("Direccion:", new Font("Arial", 14), Brushes.Black, new Point(40, 140));
            e.Graphics.DrawString(lblDireccion.Text, new Font("Arial", 14), Brushes.Black, new Point(130, 140));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(0, 160));
            e.Graphics.DrawString("Resumen de Compra", new Font("Arial", 14,FontStyle.Bold), Brushes.Black, new Point(40, 180));
            int aux = 200;
            foreach (String s in lstProductos.Items) {
             e.Graphics.DrawString(s, new Font("Arial", 14), Brushes.Black, new Point(40, aux));
                aux = aux + 20;
            }
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(0, aux));
            aux = aux + 20;
            e.Graphics.DrawString("TOTAL: ", new Font("Arial", 14,FontStyle.Bold), Brushes.Black, new Point(40, aux));
            e.Graphics.DrawString(txtTotal.Text, new Font("Arial", 14), Brushes.Black, new Point(120, aux));
            aux = aux + 20;
            e.Graphics.DrawString("Forma de Pago: ", new Font("Arial", 14), Brushes.Black, new Point(40, aux));
            e.Graphics.DrawString(lblPago.Text, new Font("Arial", 14), Brushes.Black, new Point(200, aux));
            aux = aux + 20;
            e.Graphics.DrawString("Recibo generado por: ", new Font("Arial", 14), Brushes.Black, new Point(40, aux));
            e.Graphics.DrawString(lblNombreVendedor.Text, new Font("Arial", 14), Brushes.Black, new Point(230, aux));
            aux = aux + 20;
            e.Graphics.DrawString("Observaciones: ", new Font("Arial", 14), Brushes.Black, new Point(40, aux));
            e.Graphics.DrawString(lblObs.Text, new Font("Arial", 14), Brushes.Black, new Point(180, aux));


        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
}
