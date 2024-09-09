using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib.Requests.Categories;

public class GetCategoryByIdReq : Request
{
    public long Id { get; set; }
}
