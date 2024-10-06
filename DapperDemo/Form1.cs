using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        CustomerRepository customerR = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }

        private void btnObtenerID_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerPorID(txtObtenerID.Text);
            dgvCustomers.DataSource = new List<Customers> { cliente };

            if (cliente != null)
            {
                RellenarForm(cliente);
            }
        }

        private void RellenarForm(Customers customers)
        {
            txtCustomerID.Text = customers.CustomerID;
            txtCompanyName.Text = customers.CompanyName;
            txtContactName.Text = customers.ContactName;
            txtContactTitle.Text = customers.ContactTitle;
            txtAddress.Text = customers.Address;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearCliente();
            var insertado = customerR.insertarCliente(nuevoCliente);
            MessageBox.Show($"{insertado} registros insertados");
        }

        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                CustomerID = txtCustomerID.Text,
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
            };
            return nuevo;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var clienteActualizado = CrearCliente();
            var actualizados = customerR.ActualizarCliente(clienteActualizado);
            var cliente = customerR.ObtenerPorID(clienteActualizado.CustomerID);
            dgvCustomers.DataSource = new List<Customers> { cliente };

            MessageBox.Show($"filas actualizadas {actualizados}, {clienteActualizado.CustomerID}");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var eliminado = customerR.EliminarCliente(txtCustomerID.Text);
            MessageBox.Show("Filas eliminadas = " + eliminado);
        }
    }
}
