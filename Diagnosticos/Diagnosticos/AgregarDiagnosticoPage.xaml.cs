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
	public partial class AgregarDiagnosticoPage : ContentPage
	{
        public event EventHandler<string> Finalizar;

		public AgregarDiagnosticoPage ()
		{
            Title = "Nuevo Diagnostico";
			InitializeComponent ();
		}

        public void Aceptar(object sender, EventArgs e)
        {
            string diagnostico = entryDiagnostico.Text;
            if (!String.IsNullOrEmpty(diagnostico))
            {
                Finalizar(this, diagnostico);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "Verifique que los campos estén completos", "Aceptar");
            }
        }

    }
}