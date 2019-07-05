using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMatematicaSuperior.Model.ComplexNumbers
{
    public class Fasor
    {
        private Double Amplitude;
        private String FuntionSinusoidal;
        private Double Frequency;
        private Double FaseAngle;

        public Double GetAmplitude { get { return Amplitude; } }
        public String GetFuntionSinusoidal { get { return FuntionSinusoidal; } }
        public Double GetFrequency { get { return Frequency; } }
        public Double GetFaseAngle { get { return FaseAngle; } }

        public Fasor(Double Amplitud, String FuncionSinusoidal, Double Frecuencia, Double AnguloFase)
        {
            if ((string.Equals(FuncionSinusoidal, "sin")) || (string.Equals(FuncionSinusoidal, "cos")))
            {
                this.Amplitude = Amplitud;
                this.FuntionSinusoidal = FuncionSinusoidal;
                this.Frequency = Frecuencia;
                this.FaseAngle = AnguloFase;
            }
            else
            {
                throw new InvalidFasorException();
            }
        }

        public string ObtenerFasor()
        {
            return Math.Round(GetAmplitude,6) .ToString() + " . " + GetFuntionSinusoidal + "(" + Math.Round(GetFrequency,6).ToString() + "t" + " + " + Math.Round(GetFaseAngle,6).ToString() + ")"; 
        }

        public static Fasor operator +(Fasor firstFasor, Fasor secondFasor)
        {
            if (firstFasor.GetFrequency == secondFasor.GetFrequency)
            {
                return resultOfOperationWithFasores(firstFasor, secondFasor, "sum");
            }
            else
            {
                throw new InvalidOperationWithFasores();
            }
        }
        public static Fasor operator -(Fasor firstFasor, Fasor secondFasor)
        {
            if (firstFasor.GetFrequency == secondFasor.GetFrequency)
            {
                return resultOfOperationWithFasores(firstFasor, secondFasor, "remainder");
            }
            else
            {
                throw new InvalidOperationWithFasores();
            }
        }

        public static Fasor resultOfOperationWithFasores(Fasor firstFasor, Fasor secondFasor, String operation)
        {
            if (!string.Equals(firstFasor.GetFuntionSinusoidal, secondFasor.GetFuntionSinusoidal))
            {
                CorrectionOfSinusoidalFunctions(firstFasor, secondFasor);
            }
            ComplexBinomic firstBinomic = ConvertToBinomic(firstFasor);
            ComplexBinomic secondBinomic = ConvertToBinomic(secondFasor);
            ComplexBinomic result = ResolveOperation(firstBinomic, secondBinomic, operation);
            return ConvertToFasor(result, firstFasor.GetFuntionSinusoidal, firstFasor.GetFrequency);

        }
        public static ComplexBinomic ResolveOperation(ComplexBinomic firstBinomic, ComplexBinomic secondBinomic, String operation)
        {
            if (string.Equals("sum", operation))
            {
                return (firstBinomic + secondBinomic);
            }
            else
            {
                return (firstBinomic - secondBinomic);
            }
        }
        public static void CorrectionOfSinusoidalFunctions(Fasor firstFasor, Fasor secondFasor) // siempre devolvemos el resultado en cos
        {
            if (firstFasor.GetFuntionSinusoidal == "sin")
            {
                firstFasor.FuntionSinusoidal = secondFasor.GetFuntionSinusoidal;
                firstFasor.FaseAngle = firstFasor.FaseAngle - (Math.PI / 2);
            }
            else
            {
                CorrectionOfSinusoidalFunctions(secondFasor, firstFasor);
            }
        }

        public static ComplexBinomic ConvertToBinomic(Fasor fasor)
        {
            return new ComplexBinomic(fasor.GetAmplitude * Math.Cos(fasor.GetFaseAngle), fasor.GetAmplitude * Math.Sin(fasor.GetFaseAngle));
        }
        public static Fasor ConvertToFasor(ComplexBinomic binomic, String funtionSinusoidal, Double frecuencia)
        {
            Double newAmplitud = binomic.GetMymodule();
            Double newAnguloFase = binomic.GetMyAlphaAngle(); // al usar la funcion GetMyAlphaAngle(), nos devuelve siempre el angulo corregido(Es decir en la pimera vulta)
            return new Fasor(newAmplitud, funtionSinusoidal, frecuencia, newAnguloFase);
        }
    }

}
