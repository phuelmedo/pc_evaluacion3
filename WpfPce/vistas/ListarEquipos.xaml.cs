using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPce.vistas
{
    /// <summary>
    /// Lógica de interacción para ListarEquipos.xaml
    /// </summary>
    public partial class ListarEquipos : Window
    {
        NegocioPce.EquipoCollection equipoCollection;
        public ListarEquipos()
        {
            InitializeComponent();
            CargarGrilla();
        }
        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ListViewItem item = FindParent<ListViewItem>(button);

            if (item != null)
            {
                lvEquipos.SelectedItem = item.Content;

                var filaSeleccionada = (NegocioPce.Equipo)lvEquipos.SelectedItem;
                ModificarEquipo modificarEquipo = new ModificarEquipo(filaSeleccionada.EquipoId);
                modificarEquipo.ShowDialog();
                CargarGrilla();
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ListViewItem item = FindParent<ListViewItem>(button);
            if (item != null)
            {
                lvEquipos.SelectedItem = item.Content;
                EliminarRegistroSeleccionado();
            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            CargarGrilla();
        }
        private void CargarGrilla()
        {
            equipoCollection = new NegocioPce.EquipoCollection();
            lvEquipos.ItemsSource = equipoCollection.ReadAll();
        }
        private void EliminarRegistroSeleccionado()
        {
            var filaSeleccionada = (NegocioPce.Equipo)lvEquipos.SelectedItem;
            int id = filaSeleccionada.EquipoId;
            string title = "Eliminar equipo";
            string message = string.Format("Estás seguro de eliminar el equipo {0}", id);

            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, buttons);

            if (result == MessageBoxResult.Yes)
            {
                var res = filaSeleccionada.Delete(id) ?
                    MessageBox.Show(string.Format("Equipo {0} eliminado", id)) :
                    MessageBox.Show("Equipo no pudo ser eliminado");
                CargarGrilla();
            }
        }
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObj = VisualTreeHelper.GetParent(child);
            if (parentObj == null) return null;

            if (parentObj is T parent)
            {
                return parent;
            }

            return FindParent<T>(parentObj);
        }
    }
}
