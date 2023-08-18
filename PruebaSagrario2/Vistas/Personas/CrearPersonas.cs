using Newtonsoft.Json;
using PruebaSagrario2.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaSagrario2.Vistas.Personas
{
    public partial class CrearPersonas : Form
    {
        public string cedulaPersona;
        public string nombrePersona;
        public string apellidoPersona;
        public string telefonoPersona;
        public string direccionPersona;
        HttpCliente cliente = new HttpCliente();
        public CrearPersonas()
        {
            InitializeComponent();
            if (cedulaPersona != null && nombrePersona != null && apellidoPersona != null &&
                telefonoPersona != null && direccionPersona != null)
            {
                txtCedula.Text = cedulaPersona;
                txtNombre.Text = nombrePersona;
                txtApellido.Text = apellidoPersona;
                txtTelefono.Text = telefonoPersona;
                txtDireccion.Text = direccionPersona;
            }
            if (Editar)
            {
                label6.Visible = true;
                txtFechaCreacion.Visible = true;
                txtFechaCreacion.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"); 
            }
            else
            {
                label6.Visible = false;
                txtFechaCreacion.Visible = false;
            }
        }

        private async Task CrearPersonasAsync(Persona personas)
        {
            try
            {
                var jsonPersona = JsonConvert.SerializeObject(personas);
                var contenido = new StringContent(jsonPersona, Encoding.UTF8, "application/json");
                var response = await cliente.Post("https://localhost:7096/api/personas/crear", jsonPersona);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Persona creada exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al crear la persona: " + response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private async Task EditarPersonasAsync(Persona personas)
        {
            try
            {
                var jsonPersona = JsonConvert.SerializeObject(personas);
                var contenido = new StringContent(jsonPersona, Encoding.UTF8, "application/json");

                var response = await cliente.Put("https://localhost:7096/api/personas/actualizar/" + idPersonas, jsonPersona);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Persona actualizada exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar la persona: " + response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void btnGuardarPer_ClickAsync(object sender, EventArgs e)
        {
            Persona persona = new Persona()
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text
            };
            if (Editar)
            {
                persona.IdPersona = idPersonas;
                persona.EstadoPersona = "A";
                persona.FechaCreacion = FechaCreacion;
                persona.FechaActualizacion = DateTime.Now;
                EditarPersonasAsync(persona);
            }
            else
            {
                CrearPersonasAsync(persona);
            }
        }
    }
}
