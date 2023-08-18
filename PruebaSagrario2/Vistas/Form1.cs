using PruebaSagrario2.Vistas;
using PruebaSagrario2.Vistas.Facturas;
using PruebaSagrario2.Vistas.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaSagrario2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            TablaProductos tablaPersonas = new TablaProductos();
            tablaPersonas.Show();
        }

        private void btnPersonas_Click_1(object sender, EventArgs e)
        {
            TablaPersonas tablaPersonas = new TablaPersonas();
            tablaPersonas.Show();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            TablaFacturas tablaFacturas = new TablaFacturas();
            tablaFacturas.Show();
        }
    }
}
