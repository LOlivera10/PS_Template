using FluentAssertions;
using Moq;
using NUnit.Framework;
using PS.Template.Application.Services;
using PS.Templete.Domain.Commands;
using PS.Templete.Domain.DTOs;
using PS.Templete.Domain.Queries;
using System;
using Xunit;

namespace PS.Template.UnitTest
{
    public class Tests
    {
        private Mock<IGenericsRepository> _repository;
        private Mock<ICursoQuery> _query;
        public Tests() 
        {
            _repository = new Mock<IGenericsRepository>();
            _query = new Mock<ICursoQuery>();
        }

        [Test]
        public void CursoIdInvalid()
        {
            // Arrange
            string cursoId = "";
            CursoServices services = new CursoServices(_repository.Object, _query.Object);

            // Act
            var result = services.GetById(cursoId);

            // Assert
            Assert.IsNull(result);
            result.Should().BeNull();
            
        }
        [Test]
        public void CursoIdValid()
        {
            // Arrange
            Guid cursoId = Guid.NewGuid();
            _query.Setup(_ => _.GetById(It.IsAny<string>()))
                .Returns(new ResponseGetCursoById() { CursoId = cursoId });
            CursoServices services = new CursoServices(_repository.Object, _query.Object);

            // Act
            var result = services.GetById(cursoId.ToString());

            // Assert
            Assert.NotNull(result);
            result.Should().NotBeNull();
            result.CursoId.Should().Be(cursoId);

        }
    }
}