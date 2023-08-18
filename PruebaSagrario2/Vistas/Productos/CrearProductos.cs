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

namespace PruebaSagrario2.Vistas.Productos
{
    public partial class CrearProductos : Form
    {
        public int idProducto;
        public string nombreProducto;
        public decimal precioProducto;
        public CrearProductos()
        {
            InitializeComponent();

            if(nombreProducto != null)
            {
                txtNombrePro.Text = nombreProducto;
            }
            if(precioProducto != 0)
            {
                txtPrecioPro.Text = precioProducto.ToString();
            }
        }

        private async Task CrearProductoAsync(Producto producto)
        {
            try
            {
                    var jsonProducto = JsonConvert.SerializeObject(producto);
                    var contenido = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                    HttpCliente clienteHttp = new HttpCliente();

                    var response = await clienteHttp.Post("https://localhost:7096/api/productos/crear", jsonProducto);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Producto creado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el producto: " + response.ReasonPhrase);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private async Task EditarProductoAsync(Producto producto)
        {
            try
            {
                    var jsonProducto = JsonConvert.SerializeObject(producto);
                    var contenido = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                    HttpCliente clienteHttp = new HttpCliente();

                    var response = await clienteHttp.Put("https://localhost:7096/api/productos/"+IdProducto, jsonProducto);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Producto editado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al editar el producto: " + response.ReasonPhrase);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }

        private void btnGuardar_ClickAsync(object sender, EventArgs e)
        {
            Producto producto = new Producto()
            {
                Nombre = txtNombrePro.Text,
                PrecioUnitario = Convert.ToDecimal(txtPrecioPro.Text),
            };

            if(Editar)
            {
                producto.IdProducto = IdProducto;
                producto.EstadoProducto = "A";
                producto.FechaCreacion = FechaCreacion;
                producto.FechaActualizacion = DateTime.Now;
                EditarProductoAsync(producto);
            }
            else
            {
                CrearProductoAsync(producto);
            }
        }
    }
}
