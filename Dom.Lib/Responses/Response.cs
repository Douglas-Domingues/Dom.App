using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dom.Lib.Responses;

public class Response<T>
{
    private readonly int _code;
    public T? Data { get; set; }
    public string? Message { get; set; }

    [JsonConstructor]
    public Response()
    {
        _code = Configuration.DefaultStatusCode;
    }

    public Response(T? data, int code = Configuration.DefaultStatusCode, string? message = null)
    { 
        _code = code;
        Data = data;
        Message = message;
    }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}
