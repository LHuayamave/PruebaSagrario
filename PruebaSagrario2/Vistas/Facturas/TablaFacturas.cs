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

namespace PruebaSagrario2.Vistas.Facturas
{
    public partial class TablaFacturas : Form
    {
        private int IdFactura;
        private string NombreCliente;

        HttpCliente cliente = new HttpCliente();
        public TablaFacturas()
        {
            InitializeComponent();
            CargarDatos();
        }



        private async void FiltrarDatosPorNombre(string nombre)
        {
            NombreBusqueda nombreBusqueda = new NombreBusqueda
            {
                Nombre= nombre
            };
            var json = await cliente.Post("https://localhost:7096/api/facturas/cabecera/buscar-por-nombre", JsonConvert.SerializeObject(nombreBusqueda));
            List<FacturaCabecera> facturaCabeceras = JsonConvert.DeserializeObject<List<FacturaCabecera>>(json.Content.ReadAsStringAsync().Result);

            BindingList<FacturaCabecera> bindingList = new BindingList<FacturaCabecera>(facturaCabeceras);
            dataGridView1.DataSource = bindingList;
        }

        private async void CargarDatos()
        {
            var json = await cliente.Get("https://localhost:7096/api/facturas/cabecera/listado");

            List<FacturaCabecera> facturaCabeceras = JsonConvert.DeserializeObject<List<FacturaCabecera>>(json);

            BindingList<FacturaCabecera> bindingList = new BindingList<FacturaCabecera>(facturaCabeceras);
            dataGridView1.DataSource = bindingList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearFacturaCabecera crearFacturaCabecera = new CrearFacturaCabecera()
            {
                txtNombre = { Text = NombreCliente },
                txtIdPersona = { Text = idPersona.ToString() }
            };
            crearFacturaCabecera.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                FacturaCabecera facturaSeleccionada = (FacturaCabecera)selectedRow.DataBoundItem;

                idPersona = facturaSeleccionada.IdPersona;
                NombreCliente = facturaSeleccionada.NombreCliente;
            }
        }
    }
}
