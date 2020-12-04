using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaModoDesconectado.Models;
using LibreriaModoDesconectado.Repositories;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace LibreriaModoDesconectado.ViewModels
{
    public class ListaLibrosViewModel
    {
        public ObservableCollection<libro> Libros { get; set; } = new ObservableCollection<libro>();

        public ICommand Eliminar { get; set; }

        public Func<string, bool> Confirmar;

        public void EliminarLibro(libro li)
        {
            if(li!=null)
            {
                if (Confirmar?.Invoke(li.Titulo) == true)
                {
                    LibrosRepository lr = new LibrosRepository();
                    lr.Delete(li);
                    Cargar();
                }
            }
        }

        public ListaLibrosViewModel()
        {
            Eliminar = new RelayCommand<libro>(EliminarLibro);
        }

        public void Cargar()
        {
            LibrosRepository datosLibros = new LibrosRepository();

            Libros.Clear();

            foreach (var item in datosLibros.GetAll())
            {
                Libros.Add(item);
            }
        }
    }
}
