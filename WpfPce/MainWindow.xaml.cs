using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPce
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NegocioPce.EquipoCollection equipoCollection;
        NegocioPce.EquipoReporte equipoReporte;
        public MainWindow()
        {
            InitializeComponent();
            equipoCollection = new NegocioPce.EquipoCollection();
            CargarGrilla();
        }
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            vistas.AgregarEquipo agregarEquipo = new vistas.AgregarEquipo();
            agregarEquipo.ShowDialog();
        }

        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            vistas.ListarEquipos listarEquipos = new vistas.ListarEquipos();
            listarEquipos.ShowDialog();
        }

        private void ReportesEquipo_Click(object sender, RoutedEventArgs e)
        {
            equipoReporte = new NegocioPce.EquipoReporte();
            int equiposFemeninos = equipoReporte.ReporteEquiposFemeninos();
            int equiposMasculinos = equipoReporte.ReporteEquiposMasculinos();
            string message = string.Format(
                "Equipos Femeninos: {0} \n " +
                "Equipos Masculinos: {1}",
                equiposFemeninos,
                equiposMasculinos
            );
            MessageBox.Show(message);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            lvEquipos.ItemsSource = equipoCollection.ReadAll();
        }
    }
}
