using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class UserModel
    {
        [Key]
        public int UserModelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
