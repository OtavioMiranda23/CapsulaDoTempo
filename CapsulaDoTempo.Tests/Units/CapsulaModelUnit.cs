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
        var capsula = new CapsulaModel()
        {
            Message = message,
            CreatedAt = DateTime.Now,
        };
        capsula.SetPathImage("test.png");
        Assert.Equal(message, capsula.Message);
        Assert.Equal(expectPathImage, capsula.PathImage);
    }
    [Fact]
    public void InvalidFileNameCreateModel()
    {
        var message = "Mensagem de teste";
        var capsula = new CapsulaModel()
        {
            Message = message,
            CreatedAt = DateTime.Now,
        };
        Assert.Throws<ArgumentOutOfRangeException>(() => capsula.SetPathImage("test.pnng"));
    }
}