using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMatematicaSuperior.Model.ComplexNumbers
{
    public class ComplexPolar
    {
        private Double Module;
        private Double Angle;
    

        public Double ModulePart { get { return Module; } }
        public Double AnglePart { get { return Angle; } }

        public ComplexPolar(Double Module, Double Angle)
        {
            if (Module < 0)
            {
                throw new InvalidModulePartInPolarException();
            }
            else
            { 
            this.Module = Module;
            this.Angle = Angle;
             }
        }

        // 1. Estructura de Datos y Transformaciones

        public string GetNumber()
        {
            return " [ " + Math.Round(this.Module, 6).ToString() + " ; " + Math.Round(this.Angle,6).ToString() + " ] ";
        }

        private double GetImaginaryPartByModuleAndAngle()
        {
            return ModulePart * Math.Round(Math.Sin(AnglePart), 15);
        }

        private double GetRealPartByModuleAndAngle()
        {
            return ModulePart * Math.Round(Math.Cos(AnglePart), 15);
        }

        public ComplexBinomic ConvertToBinomicForm()
        {
            return new ComplexBinomic(GetRealPartByModuleAndAngle(), GetImaginaryPartByModuleAndAngle());
        }

        // 2. Operaciones Basicas
        public static ComplexPolar operator +(ComplexPolar firstComplex, ComplexPolar secondComplex)
        {
            return (firstComplex.ConvertToBinomicForm() + secondComplex.ConvertToBinomicForm()).ConvertToPolarForm();
        }
        public static ComplexPolar operator -(ComplexPolar firstComplex, ComplexPolar secondComplex)
        {
            return (firstComplex.ConvertToBinomicForm() - secondComplex.ConvertToBinomicForm()).ConvertToPolarForm();
        }

        public static ComplexPolar operator *(ComplexPolar firstComplex, ComplexPolar secondComplex)
        {
            return new ComplexPolar(firstComplex.Module * secondComplex.Module, firstComplex.Angle + secondComplex.Angle);
;       }
        public static ComplexPolar operator /(ComplexPolar firstComplex, ComplexPolar secondComplex)
        {
            return new ComplexPolar(firstComplex.ModulePart / secondComplex.ModulePart,
                                    firstComplex.AnglePart - secondComplex.AnglePart);
        }

        // 3. Operaciones avanzadas

        public ComplexPolar Potencia(double numero)
        {
            return new ComplexPolar(Math.Pow(this.Module, numero), numero * this.Angle);
        }
        
        public List<ComplexPolar> Raiz(double numero)
        {
            if (numero > 0)
            {
                List<ComplexPolar> raices = new List<ComplexPolar>();
                int k = 0;
                return ObtenerRaicesNesimas(numero,raices, k);
            }
            else
            {
                throw new InvalidRaizException();
            }
        }
        public List<ComplexPolar> ObtenerRaicesNesimas(double numero, List<ComplexPolar> raices, int k)
        {
            if (k < numero)
            {
                raices.Add(new ComplexPolar(Math.Pow(this.Module,(1 / numero)), (this.Angle + 2 * k * Math.PI) / numero));
                k++;
                ObtenerRaicesNesimas(numero,raices, k);
            }
            return raices;
        }

        public List<ComplexPolar> RaicesPrimitivas(double numero)
        {
            List<ComplexPolar> raicesPrimitivas = new List<ComplexPolar>();
            List<ComplexPolar> raices = new List<ComplexPolar>();

            raices = this.Raiz(numero);

            int k = 0;

            foreach(ComplexPolar raiz in raices)
            {
                if(mcd(numero,k)== 1)
                {
                    raicesPrimitivas.Add(raiz);
                }
                k++;
            }

            return raicesPrimitivas;
        }

        public double mcd(double a, double b)
        {
            double aux;
            while (a > 0)
            {
                aux = a;
                a = b % a;
                b = aux;
            }
            return b;
        }
    }
}
