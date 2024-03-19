using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTraining.MvcApp.Models;

[Table("Tbl_Blog")]
public class BlogModel
{
    [Key]
    public int BlogId { get; set; }
    //[Column("BlogTitle")]
    public String BlogTitle { get; set; }
    public String BlogAuthor { get; set; }
    public String BlogContent { get; set; }
}

