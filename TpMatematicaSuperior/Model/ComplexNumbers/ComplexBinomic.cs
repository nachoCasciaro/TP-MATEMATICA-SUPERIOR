using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMatematicaSuperior.Model.ComplexNumbers
{
    public class ComplexBinomic
    {
        private Double Imaginary;
        private Double Real;
        public Double ImaginaryPart { get { return Imaginary; } }
        public Double RealPart { get { return Real; } }

        public ComplexBinomic(Double Real, Double Imaginary)
        {
            this.Real = Real;
            this.Imaginary = Imaginary;

        }


        // 1. Estructura de Datos y Transformaciones

        public string GetNumber()
        {
                return Math.Round(this.Real, 6).ToString() + " + " + Math.Round(this.Imaginary, 6).ToString() + " j";
        }

        public ComplexPolar ConvertToPolarForm()
        {
            return new ComplexPolar(this.GetMymodule(), this.GetMyAlphaAngle());
        }

        private double GetAngleCorrection()
        {
            double angleCorrection = 0;

            if ((this.Real < 0 && this.Imaginary > 0) || (this.Real < 0 && this.Imaginary < 0))
            {
                angleCorrection = Math.PI;
            }
            else if (this.Imaginary < 0)
            {
                angleCorrection = 2 * Math.PI;
            }

            return angleCorrection;
        }

        public Double GetMyAlphaAngle()
        {
            double argument = 0;
            double angle = 0;
            if (this.Real != 0 && this.Imaginary != 0)
            {
                argument = (this.Imaginary / this.Real);
                angle = Math.Atan(argument) + this.GetAngleCorrection();
            }
            else if (this.Real == 0 && this.Imaginary != 0)
            {
                angle = this.Imaginary > 0 ? Math.PI / 2 : Math.PI * 3 / 2;
            }
            else if (this.Imaginary == 0 && this.Real != 0 && this.Real < 0)
            {
                angle = Math.PI;
            }

            return angle;
        }

        public Double GetMymodule()
        {
            return Math.Sqrt(this.GetMySumOfSquares());
        }

        public Double GetMySumOfSquares()
        {
            int potencia = 2;
            return Math.Pow(this.Real, potencia) + Math.Pow(this.Imaginary, potencia);
        }

        // 2. Operaciones Basicas

        private ComplexBinomic GetMyConjugate()
        {
            return new ComplexBinomic(this.Real, -this.Imaginary);
        }

        private ComplexBinomic GetMyOpposite()
        {
            return new ComplexBinomic(-this.Real, -this.Imaginary);
        }

        public static ComplexBinomic operator +(ComplexBinomic firstComplex, ComplexBinomic secondComplex)
        {
            return new ComplexBinomic(firstComplex.Real + secondComplex.Real,
                               firstComplex.Imaginary + secondComplex.Imaginary);
        }
        public static ComplexBinomic operator -(ComplexBinomic firstComplex, ComplexBinomic secondComplex)
        {
            return firstComplex + secondComplex.GetMyOpposite();
        }

        public static ComplexBinomic operator *(ComplexBinomic firstComplex, ComplexBinomic secondComplex)
        {
            return new ComplexBinomic(firstComplex.Real * secondComplex.Real - firstComplex.Imaginary * secondComplex.Imaginary,
                               firstComplex.Real * secondComplex.ImaginaryPart + secondComplex.RealPart * firstComplex.Imaginary);
        }

        public static ComplexBinomic operator *(ComplexBinomic complex, double scalar)
        {
            return new ComplexBinomic(complex.Real * scalar,
                               complex.Imaginary * scalar);
        }

        public static ComplexBinomic operator *(double scalar, ComplexBinomic complex)
        {
            return complex * scalar;
        }

        public static ComplexBinomic operator /(ComplexBinomic firstComplex, ComplexBinomic secondComplex)
        {
            return (firstComplex.ConvertToPolarForm() / secondComplex.ConvertToPolarForm()).ConvertToBinomicForm();
        }

        // 3. Operaciones avanzadas

        public ComplexBinomic Potencia(double numero)
        {
            return ConvertToPolarForm().Potencia(numero).ConvertToBinomicForm();
        }

        public List<ComplexBinomic> Raiz(double numero)
        {
            List<ComplexBinomic> raices = new List<ComplexBinomic>();
            return ConvertToPolarForm().Raiz(numero).ConvertAll(x => x.ConvertToBinomicForm());
        }

        public List<ComplexBinomic> RaicesPrimitivas(double numero)
        {
            List<ComplexBinomic> raices = new List<ComplexBinomic>();
            return ConvertToPolarForm().RaicesPrimitivas(numero).ConvertAll(x => x.ConvertToBinomicForm());

        }

    }


}
