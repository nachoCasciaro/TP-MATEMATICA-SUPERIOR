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
    public class FasorTests
    {
        private Fasor f1 = new Fasor(5,"cos",2,(-Math.PI)/3);
        private Fasor f2 = new Fasor(8,"cos", 12, (Math.PI)/6);
        private Fasor f3 = new Fasor(8,"cos", 2, (Math.PI) / 6);
        private Fasor f4 = new Fasor(1, "sin", 5, (-Math.PI) /2);
        private Fasor f5 = new Fasor(1, "sin", 5, (Math.PI) / 3);
        private Fasor f6 = new Fasor(1, "cos", 3, 0);
        private Fasor f7 = new Fasor(1, "sin", 3, 0);
        private Fasor f8 = new Fasor(4, "sin", 4, 0);
        private Fasor f9 = new Fasor(2, "cos", 4, 0);

        //-----------------tests Fasores-excepciones-----------------------------------
        [TestMethod]
        public void FrecuencyFromf8Plusf9Equals4()
        {
            Assert.AreEqual(4, (f8+f9).GetFrequency);
        }
        [TestMethod]
        public void fasorWithArctgThrowError()
        {
            Assert.ThrowsException<InvalidFasorException>(() => new Fasor(1,"arctg",5,Math.PI/2));
        }
        [TestMethod]
        public void sumOfFasoresWithDifferentFrecuenceThrowError()
        {
            Assert.ThrowsException<InvalidOperationWithFasores>(() => f1+f2);
        }
        //-----------------tests Fasores-Suma con igual funcion sinusoidal (cos)--------
        [TestMethod]
        public void FrequencyOfTheSumOfF1AndF3Is2()
        {
            Assert.AreEqual(2, (f1 + f3).GetFrequency);
        }
        [TestMethod]
        public void FuntionSonoidalFuntionOfTheSumOfF1AndF3IsCos()
        {
            Assert.AreEqual("cos", (f1 + f3).GetFuntionSinusoidal);
        }
        [TestMethod]
        public void AmplitudeOfTheSumOfF1AndF3Is9and43()
        {
            Assert.AreEqual(9.43, (f1+f3).GetAmplitude, 15);
        }
        [TestMethod]
        public void FaseAngleOfTheSumOfF1AndF3IsMinus0and034()
        {
            Assert.AreEqual((-0.034), (f1 + f3).GetFaseAngle, 15);
        }
        //-----------------tests Fasores-Suma con igual funcion sinusoidal (sin)--------
        [TestMethod]
        public void AmplitudefTheSumOfF4AndF5Is0and517()
        {
            Assert.AreEqual(0.517, (f4 + f5).GetAmplitude, 15);
        }
        [TestMethod]
        public void FaseAngleOfTheSumOfF4AndF5IsMius0and262()
        {
            Assert.AreEqual((-0.262), (f4 + f5).GetFaseAngle, 15);
        }
        //-----------------tests Fasores con distinta funcion sinusoidal--------
        [TestMethod]
        public void FuntionSiusoidalOfTheRemainderOfF6AndF7IsCos() 
        {
            Assert.AreEqual("cos", (f6 - f7).GetFuntionSinusoidal);
        }
        //-----------------tests Fasores-Resta ---------------------------------
        [TestMethod]
        public void AmplitudelOfTheRemainderfF6AndF7Is0and211()
        {
            Assert.AreEqual(7.211, (f6 - f7).GetAmplitude,15);
        }
        public void FaseAnglelOfTheRemainderfF6AndF7Is0and211()
        {
            Assert.AreEqual((-0.982), (f6 - f7).GetFaseAngle, 15);
        }

    }
}
