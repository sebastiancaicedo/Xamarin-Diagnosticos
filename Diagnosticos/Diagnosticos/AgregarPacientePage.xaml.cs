using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diagnosticos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgregarPacientePage : ContentPage
	{
        public event EventHandler<Paciente> Finalizar;

		public AgregarPacientePage ()
		{
            Title = "Agregar Paciente";
			InitializeComponent ();
		}

        public void Terminar(object sender, EventArgs e)
        {
            string nombre = entryNombre.Text;
            string apellido = entryApellido.Text;
            string diagnosticoInicial = entryDiagnostico.Text;
            if (!String.IsNullOrEmpty(nombre) && !String.IsNullOrEmpty(apellido) && !String.IsNullOrEmpty(diagnosticoInicial))
            {
                Paciente nuevo = new Paciente(nombre, apellido, diagnosticoInicial);
                Finalizar(this, nuevo);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Verifique que los campos estén completos", "Aceptar");
            }
        }

    }
}