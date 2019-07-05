using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TpMatematicaSuperior.Model.ComplexNumbers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class AdvancedOperationsTests
    {
        private readonly ComplexBinomic n7 = new ComplexBinomic(1,1);
        private readonly ComplexBinomic ComplexWithAngle0 = new ComplexBinomic(4, 0);
        private readonly ComplexBinomic ComplexWithAngle90 = new ComplexBinomic(0, 2);
        private readonly ComplexBinomic ComplexWithAngle180 = new ComplexBinomic(-2, 0);
        private readonly ComplexBinomic ComplexWithAngle270 = new ComplexBinomic(0, -8);
        private ComplexPolar p3 = new ComplexPolar(1, Math.PI/2);
        private ComplexPolar p4 = new ComplexPolar(2, 3*Math.PI / 2);
        private ComplexPolar p5 = new ComplexPolar(1,0);
        private ComplexPolar p6 = new ComplexPolar(8, 3 * Math.PI / 2);
        private ComplexPolar p7 = new ComplexPolar(16, Math.PI );
        private readonly ComplexBinomic n8 = new ComplexBinomic(0, 8);
        private readonly ComplexBinomic n9 = new ComplexBinomic(-16, 0);


        //-----------------Potencia en Binomica------------------------
        [TestMethod]
        public void theImaginaryPartOftheSquareOfN7Is2()
        {
            Assert.AreEqual(2, n7.Potencia(2).ImaginaryPart,5);
        }

        [TestMethod]
        public void theImaginaryPartOfComplexWithAngle0ToTheFifthPowerIs0()
        {
            Assert.AreEqual(0, ComplexWithAngle0.Potencia(5).ImaginaryPart);
        }

        [TestMethod]
        public void theImaginaryPartOfComplexWithAngle180ToTheSixthPowerIs64()
        {
            Assert.AreEqual(64,ComplexWithAngle180.Potencia(6).RealPart);
        }

        [TestMethod]
        public void theImaginaryPartOfTheSquareOfComplexWithAngle90Is0()
        {
            Assert.AreEqual(-4, ComplexWithAngle90.Potencia(2).RealPart);
        }

        //-----------------Potencia en Polar----------------------------

        [TestMethod]
        public void theModulelPartOfP4ToTheSeventhPowerIs128()
        {
            Assert.AreEqual(128, p4.Potencia(7).ModulePart);
        }

        [TestMethod]
        public void theAngleOfTheSquareOfP3IsPi()
        {
            Assert.AreEqual(Math.PI, p3.Potencia(2).AnglePart);
        }

        [TestMethod]
        public void theAngleOfP4ToTheFifthPowerIs15PiDivided2()
        {
            Assert.AreEqual(15*Math.PI/2, p4.Potencia(5).AnglePart);
        }

        //-----------------Raiz en Binomica-------------------------

        [TestMethod]
        public void laRaizCubicaDeN8TieneParteImaginaria1j()
        {
            Assert.AreEqual( 1 , n8.Raiz(3).ElementAt(1).ImaginaryPart);
        }

        [TestMethod]
        public void laRaizCuadradaDeN9tieneParteReal0()
        {
            Assert.AreEqual( 0 , n9.Raiz(2).ElementAt(0).RealPart);
        }

        [TestMethod]
        public void laRaizCuadradaDeN9tieneParteImaginaria4j()
        {
            Assert.AreEqual(4, n9.Raiz(2).ElementAt(0).ImaginaryPart);
        }


        //-----------------Raiz en Polar----------------------------
        [TestMethod]
        public void negativeRootTrhowInvlidRaizException()
        {
            Assert.ThrowsException<InvalidRaizException>(() => p3.Raiz(-1));
        }

        [TestMethod]
        public void theModuleOfTheFirstElementOfCubeRootOfP6Is2()
        {
            Assert.AreEqual(2, p6.Raiz(3).ElementAt(1).ModulePart);
        }

        [TestMethod]
        public void theAngleOfTheFirstElementeOfCubeRootOfP4IsPi()
        {
            Assert.AreEqual(Math.PI / 2, p4.Raiz(3).ElementAt(0).AnglePart);
        }

        [TestMethod]
        public void theAngleOfTheSecondElementeOfCubeRootOfP4Is7PiDivided6()
        {
            Assert.AreEqual(7* Math.PI / 6, p4.Raiz(3).ElementAt(1).AnglePart);
        }

        [TestMethod]
        public void theAngleOfTheThirdElementeOfFourthRootOfP5IsPi()
        {
            Assert.AreEqual(Math.PI, p5.Raiz(4).ElementAt(2).AnglePart);
        }
        // fifth root

        //-----------------Raices primitivas ----------------------------

        [TestMethod]
        public void laCantidadDeRaicesPrimitivasDeP6Es4()
        {
            Assert.AreEqual(4, p6.RaicesPrimitivas(10).Count());
        }

        [TestMethod]
        public void laCantidadDeRaicesPrimitivasDeP7Es2()
        {
            Assert.AreEqual(2, p7.RaicesPrimitivas(4).Count());
        }

        [TestMethod]
        public void elModuloDeW1QueEsRaizPrimitivaDeP7Es2()
        {
            Assert.AreEqual(2, p7.RaicesPrimitivas(4).ElementAt(0).ModulePart);
        }

        [TestMethod]
        public void elAnguloDeW1QueEsRaizPrimitivaDeP7Es3PiSobre4()
        {
            Assert.AreEqual(Math.PI * 3/4, p7.RaicesPrimitivas(4).ElementAt(0).AnglePart);
        }

        [TestMethod]
        public void elAnguloDeW3QueEsRaizPrimitivaDeP7Es7PiSobre4()
        {
            Assert.AreEqual(Math.PI * 7 / 4, p7.RaicesPrimitivas(4).ElementAt(1).AnglePart);
        }
    }
}
