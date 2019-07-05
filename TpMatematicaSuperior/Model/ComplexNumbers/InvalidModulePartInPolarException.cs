using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMatematicaSuperior.Model.ComplexNumbers
{
    [Serializable()]
    public class InvalidModulePartInPolarException : System.Exception
    {
        public static string message = "No es posible ingresar un numero negativo como modulo de un numero complejo en froma Polar.";
        public InvalidModulePartInPolarException() : base(message) { }
       // public InvalidModulePartInPolarException(string message, System.Exception inner) : base(message, inner) { }
    }
}
