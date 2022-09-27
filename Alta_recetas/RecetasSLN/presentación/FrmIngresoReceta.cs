using RecetasSLN.datos;
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
    public partial class FrmIngresoReceta : Form
    {
        private GestorRecetas gestor;
        private Receta receta;
        public FrmIngresoReceta()
        {
            InitializeComponent();
            gestor = new GestorRecetas();
            receta = new Receta();

        }

        private void FrmIngresoReceta_Load(object sender, EventArgs e)
        {
            CargarTipos(cbTipoReceta,"tipo_receta","id_tipo_receta");
            CargarIngredientes(cbIngrediente,"n_ingrediente","id_ingrediente");
            ProximaReceta();
        }
        #region PRIVATE METHODS
        private void CargarCombo(ComboBox cb, string dMember, string vMember,DataTable dt) {
            cb.DataSource = dt;
            cb.DisplayMember = dMember;
            cb.ValueMember = vMember;
        }
        private void CargarTipos(ComboBox cb,string dMember,string vMember) {
            DataTable dt = gestor.ObtenerTiposRecetas();
            CargarCombo(cb,dMember,vMember,dt);
        }
        private void CargarIngredientes(ComboBox cb, string dMember, string vMember)
        {
            DataTable dt = gestor.ObtenerIngredientes();
            CargarCombo(cb, dMember, vMember, dt);
        }
        private void ProximaReceta() {
            int cantidad = gestor.ObtenerCantidadRecetas() + 1;
            lblTitulo.Text = "Receta #: " + cantidad;
        }
        private void CalcularTotalIngredientes() { 
            int total = 0;
            foreach (DataGridViewRow r in dgvDetalles.Rows) total++;

            lblTotalIngredientes.Text = "Total de ingredientes: " + total.ToString();
        }
        private void GuardarReceta() {
            receta.Nombre = txtNombre.Text;
            receta.Cheff = txtCheff.Text;
            receta.TipoReceta = Convert.ToInt32(cbTipoReceta.SelectedValue);
            if (gestor.Confirmar(receta))
            {
                MessageBox.Show("Receta registrada correctamente","Resgitro",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Dispose();
            }
            else { 
            
                MessageBox.Show("Error al registrar la receta.Intente de nuevo","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Desea salir? Se borraran todos sus datos","Saliendo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (msg == DialogResult.Yes) this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbIngrediente.Text == "") {
                MessageBox.Show("Debe seleccionar un ingrediente");
                return;
            }
            if (nupCantidad.Value == 0) {
                MessageBox.Show("La cantidad a agregar no puede ser cero");
                return;
            }
            foreach (DataGridViewRow r in dgvDetalles.Rows) {
                if (r.Cells["ColNombreIngrediente"].Value.ToString().Equals(cbIngrediente.Text)) {
                    MessageBox.Show("Ya ingreso este ingrediente","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }
            DataRowView item = (DataRowView)cbIngrediente.SelectedItem;
            int idPro = Convert.ToInt32(item.Row.ItemArray[0]);
            string nombre = item.Row.ItemArray[1].ToString();
            string medida = item.Row.ItemArray[2].ToString();
            Ingrediente ingrediente = new Ingrediente(idPro,nombre,medida);

            int cantidad = Convert.ToInt32(nupCantidad.Value);
            DetalleReceta detalle = new DetalleReceta(ingrediente,cantidad);

            receta.AgregarDetalle(detalle);

            dgvDetalles.Rows.Add(new object[] { nombre, cantidad });

            nupCantidad.Value = 0;
            CalcularTotalIngredientes();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvDetalles.CurrentCell.ColumnIndex == 2) {
                DialogResult msg = MessageBox.Show("Desea eliminar este ingrediente?","Eliminar ingrediente",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (msg == DialogResult.Yes) {
                    receta.EliminarDetalle(dgvDetalles.CurrentRow.Index);
                    dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                } 
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") {
                MessageBox.Show("Debe ingresar un nombre","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (txtCheff.Text == "") { 
                MessageBox.Show("Debe ingresar un cheff","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (cbTipoReceta.SelectedIndex == -1) { 
                MessageBox.Show("Debe seleccionar un tipo de receta","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (dgvDetalles.Rows.Count < 3) {
                DialogResult msg = MessageBox.Show("Ha olvidado de reguistrar ingredientes?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (msg == DialogResult.Yes) return;
               
            } 
            GuardarReceta();
        }
    }
}
