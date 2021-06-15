using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialPav
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void altaDeEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaEquipo ventana = new AltaEquipo();
            ventana.ShowDialog();
        }

        private void reporte1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportViewerJugadores reporte = new ReportViewerJugadores();
            reporte.ShowDialog();
        }
    }
}
