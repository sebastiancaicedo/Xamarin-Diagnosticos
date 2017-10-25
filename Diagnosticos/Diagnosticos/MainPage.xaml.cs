using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diagnosticos
{
	public partial class MainPage : ContentPage
	{
        IList<Paciente> pacientes = new ObservableCollection<Paciente>();

		public MainPage()
		{
            Title = "Pacientes";
			InitializeComponent();
            BindingContext = pacientes;
		}

        public void AgregarPaciente(object sender, EventArgs e)
        {
            AgregarPacientePage page = new AgregarPacientePage();
            page.Finalizar += OnAgregarPaciente;
            Navigation.PushAsync(page);
        }

        private void OnAgregarPaciente(object sender, Paciente e)
        {
            pacientes.Add(e);
        }

        public void MostrarDetallesPaciente(object sender, ItemTappedEventArgs e)
        {
            Paciente paciente = e.Item as Paciente;
            DetallesPacientePage page = new DetallesPacientePage(paciente);
            Navigation.PushAsync(page);
            (sender as ListView).SelectedItem = null;
        }

    }
}
