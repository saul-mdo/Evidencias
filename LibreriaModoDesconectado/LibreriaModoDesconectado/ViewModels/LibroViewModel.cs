using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaModoDesconectado.Repositories;
using LibreriaModoDesconectado.Models;

namespace LibreriaModoDesconectado.ViewModels
{
    public class LibroViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action Cerrar;

        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int? NUmPaginas { get; set; }
        public RelayCommand Agregar { get; set; }
        public RelayCommand Editar { get; set; }
        private string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value.ToUpper(); //PARA QUE EL MENSAJE DE ERROR APAREZCA EN MAYUSCULAS//
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Error"));
            }
        }

        public bool Validar()
        {
            Error = "";
            if (string.IsNullOrWhiteSpace(Titulo))
                Error = "Introduzca el tiutlo del libro";
            else if (string.IsNullOrWhiteSpace(Autor))
                Error = "Introduzca el nombre del autor del libro";
            else if (string.IsNullOrWhiteSpace(Editorial))
                Error = "Introduzca la editorial del libro";
            else if (NUmPaginas == 0)
            { Error = "Introduzca el numero de paginas del libro"; }
            else if (string.IsNullOrWhiteSpace(NUmPaginas.ToString()))
            { Error = "Introduzca el numero de paginas del libro"; } //AGREGÚE ESTE IF YA QUE SI EL TEXBOX SE DEJA EN BLANCO IGUAL SE AGREGA EL LIBRO SIN NUMERO DE PAGINAS//
            return Error == "";
        }

        void AgregarLibro()
        {
            if (Validar())
            {
                LibrosRepository repos = new LibrosRepository();
                libro l = new libro
                {
                    Titulo = Titulo,
                    Autor = Autor,
                    Editorial = Editorial,
                    NUmPaginas = NUmPaginas
                };
                repos.Add(l);
                Cerrar?.Invoke();
            }
        }

        public LibroViewModel()
        {
            Agregar = new RelayCommand(AgregarLibro);
        }

        void EditarLibro()
        {
            if (Validar())
            {
                LibrosRepository repos = new LibrosRepository();
                libro l = new libro
                {
                    IdLibro = this.IdLibro,
                    Titulo = this.Titulo,
                    Autor = this.Autor,
                    NUmPaginas = this.NUmPaginas,
                    Editorial = this.Editorial

                };
                repos.Update(l);
                Cerrar?.Invoke();
            }
        }

        public LibroViewModel(libro l)
        {
            IdLibro = l.IdLibro;
            Titulo = l.Titulo;
            Autor = l.Autor;
            Editorial = l.Editorial;
            NUmPaginas = l.NUmPaginas;
            Editar = new RelayCommand(EditarLibro);
        }
    }
}
