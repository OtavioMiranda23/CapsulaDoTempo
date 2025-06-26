using System.ComponentModel.DataAnnotations;
using CapsulaDoTempo.Entities;
using Xunit;

namespace CapsulaDoTempo.Tests.Units;

public class CapsulaModelUnit
{
    [Fact]
    public void SuccessCreateModel()
    {
        var message = "Mensagem de teste";
        var expectPathImage = "/home/otavio/RiderProjects/CapsulaDoTempo/CapsulaDoTempo/public/upload/image/test.png";
        var emailAddress = "teste@gmail.com";
        var capsula = new CapsulaModel(message, emailAddress);
        var dateToSend = DateTime.Now.AddDays(1);
        capsula.SetDateTimeToSend(dateToSend);
        capsula.SetPathImage("test.png");
        Assert.Equal(message, capsula.Message);
        Assert.False(capsula.HasSent);
        Assert.Equal(expectPathImage, capsula.PathImage);
    }
    [Fact]
    public void InvalidFieldsCreateModel()
    {
        var message = "Mensagem de teste";
        var emailAddress = "teste@gmail.com";
        var oldDate = new DateTime(2011, 1, 1);
        var capsula = new CapsulaModel(message, emailAddress);
        Assert.Throws<ArgumentOutOfRangeException>(() => capsula.SetPathImage("test.pnng"));
        Assert.Throws<ArgumentOutOfRangeException>(() => capsula.SetDateTimeToSend(oldDate));
    }
    
    [Fact]
    public void InvalidEmailCreateModel()
    {
        var message = "Mensagem de teste";
        var emailAddress = "teste@gmailcom";
        Assert.Throws<ValidationException>(() => new CapsulaModel(message, emailAddress));
    }

}