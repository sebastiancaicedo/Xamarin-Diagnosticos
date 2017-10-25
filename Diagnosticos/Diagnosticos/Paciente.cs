using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Diagnosticos
{
    public class Paciente
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string NombreCompleto { get { return string.Format("{0} {1}", Nombre, Apellido); } }
        public IList<string> Diagnosticos { get; private set; } = new ObservableCollection<string>();
        public string UltDiagnostico { get { return Diagnosticos[Diagnosticos.Count - 1]; } }

        public Paciente(string nombre, string apellido, string primerDiagnostico)
        {
            Nombre = nombre;
            Apellido = apellido;
            Diagnosticos.Add(primerDiagnostico);
        }
    }
}
