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
using ConexionDB.Datos;
using ConexionDB.common;
namespace ConexionDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name;
        string value;
        string type;
        parametros parameters = new parametros();
        List<usp_Obtenerparametros_Result> resultados;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name != "" && value != "" && type != "")
            {
                    name = name_box.Text;
                value = value_box.Text;
                type = type_box.Text;
                parameters.nombre = name;
                parameters.tipo = type;
                parameters.valor = value;

                resultados = PruebaDBDA.LeerParametros(parameters.nombre);
                if( resultados.Count > 0){

                

                        MessageBox.Show("Nombre ya existe en la base de datos, actualizando valores: \n " + name + "- " + value + "- " + type, "Actualizar");
                        PruebaDBDA.ActualizarParametro(parameters);

                 }
                else
                {

                    MessageBox.Show("Agregando nuevo valor a la base de datos: \n " + name + "- " + value + "- " + type, "Agregar");
                    PruebaDBDA.InsertarParametro(parameters.nombre, parameters.valor, parameters.tipo);
                }
            
            }
            else
            {
                MessageBox.Show("introduzca valores adecuados", "Error");

            }

        }
    }
}
