using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib.Requests.Categories;

public class CreateCategoryReq : Request
{
    [Required(ErrorMessage = "Invalid Title")]
    [MaxLength(75, ErrorMessage = "Title length exceeded max permitted")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Invalid Description")]
    public string Description { get; set; } = string.Empty;
}
