using RecetasSLN.dominio;
using RecetasSLN.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmModificar : Form
    {
        private GestorRecetas gestor;
        private Receta receta;
        public FrmModificar(int idReceta, string nombre, string cheff, int tipo)
        {
            InitializeComponent();
            receta = new Receta(idReceta, nombre, tipo, cheff);
            gestor = new GestorRecetas();
        }

        private void FrmModificar_Load(object sender, EventArgs e)
        {
            CargarTipos();
            CargarIngredientes();
            CargarDatos();
            CalcularCantidadIngredientes();
        }
        #region PRIVATE METHODS
        private void CargarCombo(ComboBox cb,string dMember,string vMember,DataTable dt) {
            cb.DataSource = dt;
            cb.DisplayMember = dMember;
            cb.ValueMember = vMember;
        }
        private void CargarTipos() {
            DataTable dt = gestor.ObtenerTiposRecetas();
            CargarCombo(cbTipoReceta,"tipo_receta","id_tipo_receta",dt);
        }
        private void CargarIngredientes()
        {
            DataTable dt = gestor.ObtenerIngredientes();
            CargarCombo(cbIngrediente, "n_ingrediente", "id_ingrediente", dt);
        }
        private void CargarDatos() {
            txtNombre.Text = receta.Nombre;
            txtCheff.Text = receta.Cheff;
            cbTipoReceta.SelectedValue = receta.TipoReceta;

            DataTable dt = gestor.ObtenerDetalleReceta(receta.RecetaNro);
            foreach (DataRow row in dt.Rows) {
                int idIngrediente = (int)row["id_ingrediente"];
                string nombre= row["n_ingrediente"].ToString();
                string unidad = row["unidad_medida"].ToString();
                Ingrediente i = new Ingrediente(idIngrediente,nombre,unidad);

                int cantidad = Convert.ToInt32(row["cantidad"]);
                DetalleReceta dr = new DetalleReceta(i,cantidad);

                receta.AgregarDetalle(dr);
                dgvDetalles.Rows.Add(new object[] { dr.IngredienteDet.Nombre, dr.Cantidad,dr.IngredienteDet.IngredienteId });
            }

        }
        private void CalcularCantidadIngredientes() {
            lblTotalIngredientes.Text = "Total de ingredientes: " + dgvDetalles.Rows.Count;
        }
        private void GuardarReceta() {
            receta.Nombre = txtNombre.Text;
            receta.Cheff = txtCheff.Text;
            receta.TipoReceta = Convert.ToInt32(cbTipoReceta.SelectedValue);
            if (gestor.ModificarReceta(receta))
            {
                MessageBox.Show("Receta registrada con exito","Registrado",MessageBoxButtons.OK);
                this.Dispose();
            }
            else {
                MessageBox.Show("Error al registrar una receta. Intente de nuevo", "Registrado", MessageBoxButtons.OK);
            }
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbIngrediente.Text.Equals(String.Empty)) {
                MessageBox.Show("Debe seleccionar un ingrediente","Adevertencia",MessageBoxButtons.OK);
                return;
            }
            if (nupCantidad.Value == 0) { 
                MessageBox.Show("Debe agregar una cantidad mayor a cero","Adevertencia",MessageBoxButtons.OK);
                return;
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows) {
                if (row.Cells["ColNombreIngrediente"].Value.ToString().Equals(cbIngrediente.Text)) {
                    MessageBox.Show("Ya agrego ese ingrediente","Advertencia",MessageBoxButtons.OK);
                    return;
                }
            }
            DataRowView item = (DataRowView)cbIngrediente.SelectedItem;

            int id = Convert.ToInt32(item.Row.ItemArray[0]);
            string nombre = item.Row.ItemArray [1].ToString();
            string unidad = item.Row.ItemArray[2].ToString();
            Ingrediente i = new Ingrediente(id,nombre,unidad);


            DetalleReceta dr = new DetalleReceta(i,Convert.ToInt32(nupCantidad.Value));

            receta.AgregarDetalle(dr);
            dgvDetalles.Rows.Add(new object[] { dr.IngredienteDet.Nombre,dr.Cantidad,dr.IngredienteDet.IngredienteId});

            CalcularCantidadIngredientes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") {
                MessageBox.Show("Debe ingresar un nombre para la receta","Advertencia",MessageBoxButtons.OK);
                return;
            }
            if (txtCheff.Text.Equals(String.Empty)) { 
                MessageBox.Show("Debe ingresar un nombre para el cheff","Advertencia",MessageBoxButtons.OK);
                return;
            }
            if (cbTipoReceta.Text.Equals(String.Empty)) { 
                MessageBox.Show("Debe seleccionar un tipo","Advertencia",MessageBoxButtons.OK);
                return;
            }
            GuardarReceta();
        }
    }
}
