using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;
using System.Windows.Forms;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTest
    {

         [TestMethod]
         public void ValidarReintegro250()
         {
             // preparación del caso de prueba
             double saldoInicial = 1000;
             double reintegro = 250;
             double saldoEsperado = 750;
             GestionBancariaApp miApp = new
             GestionBancariaApp(saldoInicial);
             // Método a probar
             miApp.RealizarReintegro(reintegro);
             Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
             "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");
         }
       
        [TestMethod]
        public void ValidarReintegro1000()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 1000;
            double saldoEsperado = 0;
            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.RealizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
            "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");
        }
       
        [TestMethod]
            public void ValidarIngreso250()
            {
                // preparación del caso de prueba
                double saldoInicial = 1000;
                double ingreso = 250;
                double saldoEsperado = 1250;
                GestionBancariaApp miApp = new
                GestionBancariaApp(saldoInicial);
                // Método a probar
                miApp.RealizarIngreso(ingreso);
                Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");
            }
           [TestMethod]
           public void ValidarIngreso1200()
           {
               // preparación del caso de prueba
               double saldoInicial = 1000;
               double ingreso = 1200;
               double saldoEsperado = 2200;
               GestionBancariaApp miApp = new
               GestionBancariaApp(saldoInicial);
               // Método a probar
               miApp.RealizarIngreso(ingreso);
               Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
               "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");
           }
           [TestMethod]
           public void ValidarIngreso0()
           {
               // preparación del caso de prueba
               double saldoInicial = 1000;
               double ingreso = 0;
               double saldoEsperado = 1000;
               GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
               // Método a probar
               miApp.RealizarIngreso(ingreso);
               Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
               "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");
           }
       

        [TestMethod]
        public void ValidarSaldoInicialNegativo()
        {
            // preparación del caso de prueba
            double saldoInicial = -1000;
            double saldoEsperado = 0;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001,
            "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");
            //AICDAW2223
        }
        [TestMethod]
        
        public void ValidarReintegro0()
        {
            //AICDAW2223
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 0;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {

                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }
        
        [TestMethod]
        
        public void validarReintegroCantidadNoValida()
        {
            double saldoInicial = 1000;
            double reintegro = -250;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }
        //AICDAW2223  
       
        [TestMethod]
        
        public void validarIngresoCantidadNoValida()
        {
            double saldoInicial = 1000;
            double ingreso = -250;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarIngreso(ingreso);
            }
            catch (ArgumentOutOfRangeException exception)
            {

                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
            //AICDAW2223  
        }

        [TestMethod]
        
        public void ValidarReintegroSuperiorASaldo()
        {
            
            double saldoInicial = 1000;
            double reintegro = 1100;
            
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {

                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
            //AICDAW2223    

        }

    }
}
