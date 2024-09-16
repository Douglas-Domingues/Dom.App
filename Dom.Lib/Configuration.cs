using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom.Lib;

public static class Configuration
{
    public const int DefaultPageSize = 25;
    public const int DefaultStatusCode  = 200;

    public static string ConnectionString { get; set; } = string.Empty;
}
