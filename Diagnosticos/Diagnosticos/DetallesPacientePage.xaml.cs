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
	public partial class DetallesPacientePage : ContentPage
	{
        private Paciente paciente;

		public DetallesPacientePage (Paciente paciente)
		{
            this.paciente = paciente;
            Title = paciente.NombreCompleto;
			InitializeComponent ();
            BindingContext = paciente.Diagnosticos;
		}

        public void AgregarDiagnostico(object sender, EventArgs e)
        {
            AgregarDiagnosticoPage page = new AgregarDiagnosticoPage();
            page.Finalizar += OnAgregarDiagnostico;
            Navigation.PushAsync(page);
        }

        private void OnAgregarDiagnostico(object sender, string e)
        {
            paciente.Diagnosticos.Add(e);
        }

        public void EditarDiagnostico(object sender, ItemTappedEventArgs e)
        {
            string diagnosticoTapped = e.Item as string;
            int indiceDiagnostico = paciente.Diagnosticos.IndexOf(diagnosticoTapped);
            EditarDiagnosticoPage page = new EditarDiagnosticoPage(new InfoDiagnostico(indiceDiagnostico, diagnosticoTapped));
            page.Finalizar += OnEditarDiagnostico;
            Navigation.PushAsync(page);
            (sender as ListView).SelectedItem = null;
        }

        public void OnEditarDiagnostico(object sender, InfoDiagnostico e)
        {
            paciente.Diagnosticos[e.Indice] = e.Diagnostico;
        }

        public void EliminarDiagnostico(object sender, EventArgs e)
        {
            if (paciente.Diagnosticos.Count > 1)
            {
                paciente.Diagnosticos.RemoveAt(paciente.Diagnosticos.Count - 1);
            }
            else
            {
                DisplayAlert("Información", "No puede borrar el primer diagnostico", "Aceptar");
            }
        }
    }
}