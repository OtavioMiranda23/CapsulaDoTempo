using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CapsulaDoTempo.Entities;

public class CapsulaModel
{
    public Guid Uuid { get; set; }
    [Required(ErrorMessage = "Message is required.")]
    public string Message { get; set; }
    public string? PathImage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public void SetPathImage(string imageName)
    {
      var regexPattern = @"\.(gif|jpe?g|tiff?|png|webp|bmp)$";
      var match = Regex.Match(imageName, regexPattern);
      if (!match.Success)
      {
        throw new ArgumentOutOfRangeException(nameof(imageName), $"Extension image {imageName} must be gif|jpg|jpeg|tiff|png|webp|bmp");
      }
      var baseDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
      if (baseDirectory == null)
      {
        throw new DirectoryNotFoundException();
      }
      PathImage = $"{baseDirectory}/public/upload/image/{imageName}";
    }
}