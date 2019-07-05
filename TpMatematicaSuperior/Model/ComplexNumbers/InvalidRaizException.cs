using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMatematicaSuperior.Model.ComplexNumbers
{
    [Serializable()]
    public class InvalidRaizException: System.Exception
    {
        public static string message = "No es posible realizar la raiz negativa de un numero";
        public InvalidRaizException() : base(message) { }
        
    }
}

