
namespace ParcialPav
{
    partial class ReportViewerJugadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataSetParcial = new ParcialPav.DataSetParcial();
            this.JugadoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JugadoresTableAdapter = new ParcialPav.DataSetParcialTableAdapters.JugadoresTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetParcial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JugadoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataSetParcial
            // 
            this.DataSetParcial.DataSetName = "DataSetParcial";
            this.DataSetParcial.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // JugadoresBindingSource
            // 
            this.JugadoresBindingSource.DataMember = "Jugadores";
            this.JugadoresBindingSource.DataSource = this.DataSetParcial;
            // 
            // JugadoresTableAdapter
            // 
            this.JugadoresTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetEquipos";
            reportDataSource1.Value = this.JugadoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ParcialPav.Reporte.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // ReportViewerJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportViewerJugadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de jugadores";
            this.Load += new System.EventHandler(this.ReportViewerJugadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetParcial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JugadoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource JugadoresBindingSource;
        private DataSetParcial DataSetParcial;
        private DataSetParcialTableAdapters.JugadoresTableAdapter JugadoresTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}