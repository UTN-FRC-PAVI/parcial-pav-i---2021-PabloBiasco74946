using ParcialPav.AccesoADatos;
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
    public partial class AltaEquipo : Form
    {
        public AltaEquipo()
        {
            InitializeComponent();
        }

        private void AltaEquipo_Load(object sender, EventArgs e)
        {
            ObtenerUltimoIdEquipo();
            CargarFecha();
            CargarComboPosiciones();
            CargarComboCategorias();
        }

        private void CargarFecha()
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
        }


        private void CargarComboPosiciones()
        {

            try
            {

                cmbPosicion.DataSource = Acceso.ObtenerTabla("Posiciones");
                cmbPosicion.DisplayMember = "Nombre";
                cmbPosicion.ValueMember = "Id";
                cmbPosicion.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar combo de Posiciones.");

            }
        }


        private void ObtenerUltimoIdEquipo()
        {

            int id = Acceso.ObtenerUltimoIdEquipo();
            txtNroNuevoEquipo.Text = (id + 1).ToString();
        }

        private void CargarComboCategorias()
        {
            try
            {

                cmbCategorias.DataSource = Acceso.ObtenerTabla("Categorias");
                cmbCategorias.DisplayMember = "Nombre";
                cmbCategorias.ValueMember = "Id";
                cmbCategorias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar combo Categorías.");

            }
        }

        private void btnBuscarJugador_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tablaResultado = Acceso.ObtenerDatosJugador(txtNroJugador.Text.Trim());
                if (tablaResultado.Rows.Count > 0)
                {
                    txtNombreJugador.Text = tablaResultado.Rows[0][1].ToString();  
                }

                else
                {
                    MessageBox.Show("¡Error el Jugador no existe!");
                    txtNroJugador.Focus();
                    txtNroJugador.Text = "";
                    txtNombreJugador.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el Jugador!");
            }
        }


        private void CargarGrilla()
        {
            try
            {
                grdEquipo.Rows.Add(txtNroJugador.Text, txtNombreJugador.Text, cmbPosicion.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar la grilla!.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNroJugador.Text.Trim() != "")
            {
                CargarGrilla();
            }

            else
            {
                MessageBox.Show("Por favor, complete el campo del número de jugador");
                txtNroJugador.Focus();
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)

        { 
            List<int> listaEquipo = new List<int>();
            for (int i = 0; i < grdEquipo.Rows.Count; i++)
            {
                listaEquipo.Add(int.Parse(grdEquipo.Rows[i].Cells[0].Value.ToString()));
            }
            bool resultado = Acceso.AltaNuevoEquipo(int.Parse(txtNroNuevoEquipo.Text), txtNombreDeEquipo.Text, DateTime.Parse(txtFecha.Text), listaEquipo);
            if (resultado)
            {
                MessageBox.Show("Equipo dado de alta con éxito!");
            }

            else
            {
                MessageBox.Show("Error al dar de alta!");

            }
        }           
    }
 }
    
