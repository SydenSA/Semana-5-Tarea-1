using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.Controllers;
namespace _06Publicaciones.Views.Ciudades
{
    public partial class frm_Ciudades : Form
    {
        private string id;
        private CiudadesController _ciudadesController = new CiudadesController();

        public frm_Ciudades(string id)
        
        {
            InitializeComponent();
            this.id = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Ciudades_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pubsDataSet.Paises' Puede moverla o quitarla según sea necesario.
            //this.paisesTableAdapter.Fill(this.pubsDataSet.Paises);
            //MessageBox.Show(this.id);

            PaisesController _paises = new PaisesController();
            comboBox1.DataSource = _paises.todos();
            comboBox1.DisplayMember = "Detalle";
            comboBox1.ValueMember = "IdPais";
            DataRow ciudad = _ciudadesController.obtenerPorId(id);

            if (ciudad != null)
            {
                textBox1.Text = ciudad["Detalle"].ToString();
                comboBox1.SelectedValue = ciudad["IdPais"];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nuevoNombre = textBox1.Text;
            int nuevoIdPais = (int)comboBox1.SelectedValue;
            bool actualizado = _ciudadesController.actualizarCiudad(id, nuevoNombre, nuevoIdPais);
            if (actualizado)
            {
                MessageBox.Show("Ciudad actualizada exitosamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al actualizar la ciudad.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

