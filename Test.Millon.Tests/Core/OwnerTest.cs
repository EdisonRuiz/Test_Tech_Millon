using Moq;
using Test.Millon.Core.BusinessCases;
using Test.Millon.Core.Entities;
using Test.Millon.Core.Interfaces;

namespace Test.Millon.Tests.Core
{
    /// <summary>
    /// In this class we are going to test the OwnerBC class
    /// </summary>
    public class OwnerTest
    {
        private OwnerBC _ownerBC;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IRepository<Owner>> _repository;

        [SetUp]
        public void SetUp() 
        {
            //Moq
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _repository = new Mock<IRepository<Owner>>();
            _mockUnitOfWork.Setup(x => x.Owners).Returns(_repository.Object);
            _ownerBC = new OwnerBC(_mockUnitOfWork.Object);
        }

        [Test()]
        public void CreateOwnerTest()
        {
            // Arrange
            Owner model = new Owner()
            {
                Name = "John Doe",
                Address = "calle 123",
                Birthday = new DateOnly(1990, 1, 1)
            };


            // Act
            int owner = _ownerBC.CreateOwner(model).Result;

            // Assert
            _repository.Verify(x => x.AddAsync(model), Times.Once);
            _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
            Assert.IsTrue(owner == model.IdOwner);
        }
    }
}
