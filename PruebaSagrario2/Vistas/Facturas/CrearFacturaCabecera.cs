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

namespace PruebaSagrario2.Vistas.Facturas
{
    public partial class CrearFacturaCabecera : Form
    {
        public string numeroFactura;
        public string nombreCliente;
        public string nombreEmpresa;
        public string direccionEmpresa;
        public string telefonoEmpresa;
        public int idPersona;
        public DateTime fechaActual = DateTime.Now;
        public DateTime fechaVencimiento = DateTime.Now.AddMonths(1);
        public CrearFacturaCabecera()
        {
            InitializeComponent();
            if(numeroFactura != null && nombreCliente != null && nombreEmpresa != null && direccionEmpresa != null && telefonoEmpresa != null && idPersona != 0)
            {
                txtNumeroFactura.Text = numeroFactura;
                txtNombre.Text = nombreCliente;
                txtNombreEmpresa.Text = nombreEmpresa;
                txtDireccion.Text = direccionEmpresa;
                txtTelefono.Text = telefonoEmpresa;
                txtIdPersona.Text = idPersona.ToString();
            }
        }

        async Task CrearFacturaCabeceraAsync(FacturaCabecera facturaCabecera)
        {
            try
            {
                var jsonFacturaCabecera = JsonConvert.SerializeObject(facturaCabecera);
                var contenido = new StringContent(jsonFacturaCabecera, Encoding.UTF8, "application/json");

                HttpCliente clienteHttp = new HttpCliente();

                var response = await clienteHttp.Post("https://localhost:7096/api/facturas/cabecera/crear", jsonFacturaCabecera);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Factura creada exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al crear la factura: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FacturaCabecera facturaCabecera = new FacturaCabecera()
            {
                NumeroFactura = GenerarNumeroFactura(),
                NombreCliente = txtNombre.Text,
                NombreEmpresa = txtNombreEmpresa.Text,
                DireccionEmpresa = txtDireccion.Text,
                TelefonoEmpresa = txtTelefono.Text,
                IdPersona = Convert.ToInt32(txtIdPersona.Text),
                Subtotal = 0,
                FechaVencimiento = fechaVencimiento,
            };
            CrearFacturaCabeceraAsync(facturaCabecera);
        }

        static string GenerarNumeroFactura()
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(1000, 10000);
            string numeroFactura = "F" + numeroAleatorio.ToString();
            return numeroFactura;
        }
    }
}
