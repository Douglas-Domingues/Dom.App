using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dom.Lib.Requests.Categories;

public class UpdateCategoryReq : Request
{
    [JsonIgnore]
    [Required( ErrorMessage = "Invalid Id")]
    public long Id { get; set; }
    [MaxLength(75, ErrorMessage = "Title length exceeded max permitted")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Invalid description")]
    public string Description { get; set; } = string.Empty;
}
