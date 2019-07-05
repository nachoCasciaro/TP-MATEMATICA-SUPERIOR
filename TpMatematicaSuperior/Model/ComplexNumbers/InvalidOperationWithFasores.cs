using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMatematicaSuperior.Model.ComplexNumbers
{
    [Serializable()]
    public class InvalidOperationWithFasores : System.Exception
    {
        public static string message = "No puede realizarse la operacion entre fasores ya que poseen distintas frecuencias";
        public InvalidOperationWithFasores() : base(message) { }
    }
}
