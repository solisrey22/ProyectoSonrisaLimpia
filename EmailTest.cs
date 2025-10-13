using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonrisaLimpia.Dominio.ObjetosDeValor;
using SonrisaLimpia.Dominio.Excepciones;

namespace SonrisaLimpia.Dominio.PruebasUnitarias.ObjetosDeValor;
{

[TestClass]
public class EmailTest
{


    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaNegocio))]
    public void Constructor_EmailNulo_LanzaExcepcion()
    {
        new Email(null!);

    }
  }
}