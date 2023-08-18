using Newtonsoft.Json;
using PruebaSagrario2.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaSagrario2.Vistas.Personas
{
    public partial class TablaPersonas : Form
    {
        private int IdPersona;
        private string Cedula;
        private string NombrePersona;
        private string ApellidoPersona;
        private string TelefonoPersona;
        private string DireccionPersona;
        private DateTime? FechaCreacionl;
        HttpCliente cliente = new HttpCliente();

        public TablaPersonas()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            CargarDatos();
        }

        public async void CargarDatos()
        {
            var json = await cliente.Get("https://localhost:7096/api/personas/listado");

            List<Persona> personas = JsonConvert.DeserializeObject<List<Persona>>(json);
            BindingList<Persona> bindingList = new BindingList<Persona>(personas);
            dataGridView1.DataSource = bindingList;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Persona personaSeleccionada = (Persona)selectedRow.DataBoundItem;

                IdPersona = personaSeleccionada.IdPersona;
                Cedula = personaSeleccionada.Cedula;
                NombrePersona = personaSeleccionada.Nombre;
                ApellidoPersona = personaSeleccionada.Apellido;
                DireccionPersona = personaSeleccionada.Direccion;
                TelefonoPersona = personaSeleccionada.Telefono;
                FechaCreacionl = personaSeleccionada.FechaCreacion;
                btnEditarPer.Enabled = true;
            }
            else
            {
                btnEditarPer.Enabled = false;
            }
        }
        private void TablaPersonas_Activated(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            CrearPersonas crearPersonas = new CrearPersonas();
            crearPersonas.Show();
        }

        private void btnEditarPer_Click(object sender, EventArgs e)
        {
            CrearPersonas crearPersonas = new CrearPersonas()
            {
                txtCedula = { Text = Cedula },
                txtNombre = { Text = NombrePersona },
                txtApellido = { Text = ApellidoPersona },
                txtDireccion = { Text = DireccionPersona },
                txtTelefono = { Text = TelefonoPersona },
                FechaCreacion =this.FechaCreacionl,
                Editar = true,
                idPersonas = IdPersona
            };
            crearPersonas.Show();
        }

        private async Task ElimnarAsync (int IdPersona)
        {
            await cliente.Delete("https://localhost:7096/api/personas/eliminar/" + IdPersona);
            CargarDatos();
        }

        private void btnElimianrPer_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                ElimnarAsync(IdPersona);
            }
        }
    }
}
