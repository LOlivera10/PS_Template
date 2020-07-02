using NUnit.Framework;
using PS.Template.Application;
using System;

namespace PS.Template.ApplicationTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InvalidFormat()
        {
            // Arange
            var cursoIdInvalid = "123";
            var util = new Util();

            // Act
            var result = util.ValidarFormatoCursoId(cursoIdInvalid);
            
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidFormat()
        {
            // Arange
            var cursoIdValid = Guid.NewGuid().ToString();
            var util = new Util();

            // Act
            var result = util.ValidarFormatoCursoId(cursoIdValid);

            // Assert
            Assert.IsTrue(result);
        }
    }
}