using Moq;
using NUnit.Framework;
using PS.Template.Application.Services;
using PS.Templete.Domain.Commands;
using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.ApplicationTest
{
    public class ServiceCursoTest
    {
        [Test]
        public void TestGetById()
        {
            // arange 
            Mock<IGenericsRepository> _repository = new Mock<IGenericsRepository>();
            Mock<ICursoQuery> _query = new Mock<ICursoQuery>();
            var cursoId = Guid.NewGuid().ToString();
            var service = new CursoServices(_repository.Object, _query.Object);
            var respuestaEsperada = new ResponseGetCursoById
            {
                CursoId = Guid.Parse(cursoId)
            };
            _query.Setup(x => x.GetById(It.IsAny<string>())).Returns(respuestaEsperada);

            // act 
            var result = service.GetById(cursoId);

            // assert
            Assert.AreEqual(respuestaEsperada, result);
        }
        

    }
}
