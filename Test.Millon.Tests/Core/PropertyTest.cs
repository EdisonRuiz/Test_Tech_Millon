using Moq;
using Test.Millon.Core.BusinessCases;
using Test.Millon.Core.Entities;
using Test.Millon.Core.Interfaces;

namespace Test.Millon.Tests;

/// <summary>
/// In this class we are going to test the PropertyBC class
/// </summary>
public class PropertyTest
{
    private PropertyBC _ownerBC;
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private Mock<IRepository<Property>> _repository;

    [SetUp]
    public void Setup()
    {
        //Moq
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _repository = new Mock<IRepository<Property>>();
        _mockUnitOfWork.Setup(x => x.Properties).Returns(_repository.Object);
        _ownerBC = new PropertyBC(_mockUnitOfWork.Object);
    }

    [Test]
    public async Task CreateProperty_WithNoItems_ShouldThrowException()
    {
        // Arrange
        Property model = new Property()
        {
            Name = "John Doe",
            Address = "calle 123",
            Price = 400000,
            CodeInternal = "Internal123",
            Year = 2010
        };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _ownerBC.CreateProperty(model));
    }

    [Test()]
    public async Task CreatePropertyTest()
    {
        // Arrange
        Property model = new Property()
        {
            Name = "John Doe",
            Address = "calle 123",
            Price = 400000,
            CodeInternal = "Internal123",
            Year = 2010,
            IdOwner = 1
        };


        // Act
        await _ownerBC.CreateProperty(model);

        // Assert
        _repository.Verify(x => x.AddAsync(model), Times.Once);
        _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
        Assert.Pass();
    }
}
