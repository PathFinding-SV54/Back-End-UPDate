using Domain;
using Infrastructure;
using Infrastructure.DataClass;

namespace UpDate.Domain.Test;
using Moq;

public class UnitTest1
{
    [Theory]
    [InlineData(10,20,30)]
    [InlineData(10,100,110)]
    [InlineData(50,70,120)]
    public void sum_integerValues_ReturnSum(int numberA, int numberB, int expected)
    {
        //Arrange - setup
        TesteableClass testeableClass = new TesteableClass();
        
        //Act -exce
        int result = testeableClass.sum(numberA, numberB);
        
        //Assert
        Assert.Equal(result, expected);
        

    }

    [Fact]
    public void Create_ValidActivity_ReturnSuccess()
    {
        ActivityData activityData = new ActivityData()
        {
            Title = "test1"
        };
        var mockTutorialInfraestructure = new Mock<IActivityInfraestructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Create(activityData))
            .Returns(true);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var returnValue = activityDomain.Create(activityData);
        
        Assert.True(returnValue);
    }
    
    [Fact]
    public void Create_InvalidActivity_ReturnError()
    {
        ActivityData activityData = new ActivityData()
        {
            Title = "test1"
        };
        var mockTutorialInfraestructure = new Mock<IActivityInfraestructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Create(activityData))
            .Returns(false);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var returnValue = activityDomain.Create(activityData);
        
        Assert.False(returnValue);
    }
   
    [Fact]
    public void Update_ValidActivity_ReturnSuccess()
    {
        ActivityData activityData = new ActivityData()
        {
            Title = "test1"
        };
        var mockTutorialInfraestructure = new Mock<IActivityInfraestructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Update(5,activityData))
            .Returns(true);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var returnValue = activityDomain.Update(5,activityData);
        
        Assert.True(returnValue);
    }
    
    [Fact]
    public void Update_InvalidActivity_ReturnError()
    {
        ActivityData activityData = new ActivityData()
        {
            Title = "test1"
        };
        var mockTutorialInfraestructure = new Mock<IActivityInfraestructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Update(5,activityData))
            .Returns(false);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var returnValue = activityDomain.Update(5,activityData);
        
        Assert.False(returnValue);
    } 
    [Fact]
    public void Delete_ValidActivity_ReturnSuccess()
    {
        var mockTutorialInfraestructure = new Mock<IActivityInfraestructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Delete(5))
            .Returns(true);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var returnValue = activityDomain.Delete(5);
        
        Assert.True(returnValue);
    }
    
    [Fact]
    public void Delete_InvalidActivity_ReturnError()
    {
        ActivityData activityData = new ActivityData()
        {
            Title = "test1"
        };
        var mockTutorialInfraestructure = new Mock<IActivityInfraestructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Delete(5))
            .Returns(false);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var returnValue = activityDomain.Delete(5);
        
        Assert.False(returnValue);
    } 
    /*[Fact]
    public void Create_InvalidActivity_ReturnException()
    {
        ActivityData activityData = new ActivityData()
        {
            Title = "test1"
        };
        var mockTutorialInfraestructure = new Mock<IActivityInfraestructure>();
        mockTutorialInfraestructure.Setup(t =>
                t.Create(activityData))
            .Returns(false);
        ActivityDomain activityDomain = new ActivityDomain(mockTutorialInfraestructure.Object);

        var ex = Assert.Throws<Exception>(() => activityDomain.Create(activityData));
        
        Assert.Equal("Error", ex.Message);
    }*/
}