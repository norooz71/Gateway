using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Test.Presentation.Responses;

public record BaseResponse<T> where T : class
{
    public bool IsSuccess { get; set; }

    public int StatusCode { get; set; }
    
    public T Result { get; set; }
    
    public IEnumerable<string> Messages { get; set; }

    public BaseResponse(bool isSuccess, int statusCode, T result, IEnumerable<string> messages)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Result = result;
        Messages = messages;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
