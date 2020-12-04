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
using System.Windows.Shapes;
using LibreriaModoDesconectado.ViewModels;
using LibreriaModoDesconectado.Models;

namespace LibreriaModoDesconectado.Views
{
    /// <summary>
    /// Lógica de interacción para ListaLibrosView.xaml
    /// </summary>
    public partial class ListaLibrosView : Window
    {
        ListaLibrosViewModel ll = new ListaLibrosViewModel();
        public ListaLibrosView()
        {
            InitializeComponent();
            try
            {
                ll.Cargar();
                this.DataContext = ll;
                ll.Confirmar = Confirmar;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public bool Confirmar(string LibroEliminar)
        {
            return MessageBox.Show($"Seguro que desea eliminar el libro con el titulo {LibroEliminar}?", "ATENCIÓN", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AgregarLibrosView al = new AgregarLibrosView();
                LibroViewModel l = new LibroViewModel();
                l.Cerrar = al.Close;
                al.DataContext = l;
                al.ShowDialog();
                ll.Cargar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditarLibrosView el = new EditarLibrosView();
                libro l = dgvLibros.SelectedItem as libro;
                if(l == null) //AGREGUÉ LA EXCEPCION PARA QUE APAREZCA UN MENSAJE CUANDO LE DEMOS CLIC EN EL BOTON DE EDITAR SIN HABER SELECCIONADO NIGNUN LIBRO//
                {
                    throw new ArgumentException("Seleccione el libro que desea editar de la lista"); 
                }
                LibroViewModel lvm = new LibroViewModel(l);
                lvm.Cerrar = el.Close;
                el.DataContext = lvm;
                el.ShowDialog();
                ll.Cargar();
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
