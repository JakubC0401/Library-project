using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class BookModel
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsAvailable => UserModelId == -1;
    public int UserModelId { get; set; } = -1;//If -1 it means that book is not rented.
}