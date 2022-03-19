using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexion;
using Conexion.Acceso;
using Conexion.Entidades;

namespace Ejercicio3
{
    public partial class FrmUsuariosIngresados : Form
    {
        public FrmUsuariosIngresados()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        ConexionBase conexionBase = new ConexionBase();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        
        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = conexionBase.ListarUsuarios();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
            RolComboBox.Enabled = true;
            SexoComboBox.Enabled = true;
            EdadTextBox.Enabled = true;

            EstaActivoCheckBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            


        }

        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            RolComboBox.Enabled = false;
            EdadTextBox.Enabled = false;
            SexoComboBox.Enabled = false;
            EstaActivoCheckBox.Enabled = false;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            


        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ClaveTextBox.Clear();
            RolComboBox.Text = string.Empty;
            SexoComboBox.Text= string.Empty;
            EdadTextBox.Clear();
            EstaActivoCheckBox.Enabled = false;
        }


        private void GuardarButton_Click_1(object sender, EventArgs e)
        {
            user.Codigo = CodigoTextBox.Text;
            user.Nombre = NombreTextBox.Text;
            user.Clave = ClaveTextBox.Text;
            user.Puesto = RolComboBox.Text;
            user.EstaActivo = EstaActivoCheckBox.Checked;
            user.Sexo = SexoComboBox.Text;
            user.Edad = EdadTextBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = conexionBase.InsertarUsuario(user);

                if (inserto)
                {
                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Crear");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = conexionBase.ModificarUsuario(user);
                if (modifico)
                {
                    MessageBox.Show("Usuario Modificado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Modificar");
                }
            }

        }

        private void CancelarButton_Click_1(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();

        }

        private void EliminarButton_Click_1(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = conexionBase.EliminarUsuario(UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Usuario Eliminado");
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo Eliminar");
                }

            }

        }

        private void EstaActivoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ModificarButton_Click_1(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)

            {
                //para saber cuales elementos del datagrid estan seleccionados
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ClaveTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                RolComboBox.Text = UsuariosDataGridView.CurrentRow.Cells["Puesto"].Value.ToString();
                EdadTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Edad"].Value.ToString();
                SexoComboBox.Text = UsuariosDataGridView.CurrentRow.Cells["Sexo"].Value.ToString();
                EstaActivoCheckBox.Checked = Convert.ToBoolean(UsuariosDataGridView.CurrentRow.Cells["EstaActivo"].Value);
                
                //habilitar los controles
                HabilitarControles();
            }

        }

        private void FrmUsuariosIngresados_Load(object sender, EventArgs e)
        {
            ListarUsuarios();

        }

        private void SalirButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
