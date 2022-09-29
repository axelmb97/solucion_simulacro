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
    public partial class FrmConsultarRecetas : Form
    {
        private GestorRecetas gestor;
        public FrmConsultarRecetas()
        {
            InitializeComponent();
            gestor = new GestorRecetas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresoReceta nueva = new FrmIngresoReceta();
            nueva.ShowDialog();
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            CargarTiposRecetas();
        }
        #region PRIVATE METHODS
        private void CargarTiposRecetas() {
            DataTable dt = gestor.ObtenerTiposRecetas();
            cboTipoReceta.DataSource = dt;
            cboTipoReceta.DisplayMember = "tipo_receta";
            cboTipoReceta.ValueMember = "id_tipo_receta";
        }
        #endregion

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DataTable dt = gestor.ObtenerRecetasPorTipo(Convert.ToInt32(cboTipoReceta.SelectedValue));
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows) {
                Receta receta = new Receta();
                receta.RecetaNro = Convert.ToInt32(row["id_receta"]);
                receta.Nombre = row["nombre"].ToString();
                receta.Cheff = row["cheff"].ToString();
                receta.TipoReceta = Convert.ToInt32(row["tipo_receta"]);

                dataGridView1.Rows.Add(new object[] { receta.Nombre,receta.TipoReceta,receta.Cheff, receta.RecetaNro});
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colId"].Value);
                string nombre = dataGridView1.CurrentRow.Cells["colNombre"].Value.ToString();
                string cheff = dataGridView1.CurrentRow.Cells["colCheff"].Value.ToString();
                int idTipo = int.Parse(dataGridView1.CurrentRow.Cells["colTipo"].Value.ToString());
                FrmModificar modificar = new FrmModificar(id, nombre, cheff, idTipo);
                modificar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro para modificar", "Advertencia", MessageBoxButtons.OK);
            }
        }
    }
}
