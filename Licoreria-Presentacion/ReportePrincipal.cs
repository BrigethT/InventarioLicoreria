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
    public partial class ReportePrincipal : Form
    {
        public ReportePrincipal()
        {
            InitializeComponent();
        }

        private void btnPMC_Click(object sender, EventArgs e)
        {
            ProductosMasConsumidos pmc = new ProductosMasConsumidos();
            pmc.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Principal p = new Principal();
            p.Show();
            this.Close();
        }

        private void btnExistenciasP_Click(object sender, EventArgs e)
        {
            ExistenciasProductos ep = new ExistenciasProductos();
            ep.ShowDialog();
        }

        private void btnDeudores_Click(object sender, EventArgs e)
        {
            DeudoresActuales da = new DeudoresActuales();
            da.ShowDialog();
        }
    }
}
