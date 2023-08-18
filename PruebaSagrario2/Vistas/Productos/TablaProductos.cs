using Newtonsoft.Json;
using PruebaSagrario2.Modelo;
using PruebaSagrario2.Vistas.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaSagrario2.Vistas
{
    public partial class TablaProductos : Form
    {
        private int IdProducto;
        private string NombreProducto;
        private decimal PrecioProducto;
        private DateTime? FechaCreacion;
        HttpCliente cliente = new HttpCliente();
        public TablaProductos()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            CargarDatos();
        }

        private async void CargarDatos()
        {
            HttpCliente cliente = new HttpCliente();
            var json = await cliente.Get("https://localhost:7096/api/productos/listado");

            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json);

            BindingList<Producto> bindingList = new BindingList<Producto>(productos);
            dataGridView1.DataSource = bindingList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearProductos crearProductos = new CrearProductos();
            crearProductos.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Producto productoSeleccionado = (Producto)selectedRow.DataBoundItem;

                IdProducto = productoSeleccionado.IdProducto;
                NombreProducto = productoSeleccionado.Nombre;
                PrecioProducto = (decimal)productoSeleccionado.PrecioUnitario;
                FechaCreacion = productoSeleccionado.FechaCreacion;
                btnEditarPro.Enabled = true;
            }
            else
            {
                btnEditarPro.Enabled = false;
            }
        }

        private void btnEditarPro_Click(object sender, EventArgs e)
        {
            CrearProductos crearProductos = new CrearProductos()
            {
                txtNombrePro = { Text = NombreProducto },
                txtPrecioPro = { Text = PrecioProducto.ToString() },
                FechaCreacion = this.FechaCreacion,
                Editar = true,
                IdProducto = IdProducto
            };
            crearProductos.Show();
        }

        private void TablaProductos_Activated(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private async Task EliminarAsync(int IdProducto)
        {
            await cliente.Delete("https://localhost:7096/api/productos/eliminar/" + IdProducto);
            CargarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Deseas eliminar el producto?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                EliminarAsync(IdProducto);
            }
        }
    }
}
