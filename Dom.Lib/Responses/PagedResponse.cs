﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dom.Lib.Responses;

public class PagedResponse<T> : Response<T>
{
    public PagedResponse()
    {
        
    }
    [JsonConstructor]
    public PagedResponse(T? data, int totalCount, int currentPage = 1, int pageSize = Configuration.DefaultPageSize) : base(data)
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedResponse(T? data, int code = Configuration.DefaultStatusCode, string? message = null) : base(data) { }

    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages  => (int)Math.Ceiling(TotalCount / (double)PageSize);

}
