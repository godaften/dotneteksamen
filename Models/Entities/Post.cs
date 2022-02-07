using System.ComponentModel.DataAnnotations;

namespace cbsStudents.Models.Entities;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public string? Text { get; set; }

    [DataType(DataType.Date)]
    public DateTime Created { get; set; }

    public PostStatus Status { get; set; }

}


