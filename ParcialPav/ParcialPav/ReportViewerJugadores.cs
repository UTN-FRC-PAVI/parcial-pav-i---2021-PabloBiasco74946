using Microsoft.Reporting.WinForms;
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
    public partial class ReportViewerJugadores : Form
    {
        public ReportViewerJugadores()
        {
            InitializeComponent();
        }

        private void ReportViewerJugadores_Load(object sender, EventArgs e)
        {
            this.JugadoresTableAdapter.Fill(this.DataSetParcial.Jugadores);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = AccesoADatos.Acceso.ObtenerListaDeJugadores();

            ReportDataSource ds = new ReportDataSource("DataSetEquipos", tabla);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.Refresh();
        }
    }
}
