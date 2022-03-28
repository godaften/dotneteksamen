using System.ComponentModel.DataAnnotations;

namespace cbsStudents.Models.Entities;

public class Comment
{
    public int CommentId { get; set; }
    public string Text { get; set; }
    public DateTime TimeStamp { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

}