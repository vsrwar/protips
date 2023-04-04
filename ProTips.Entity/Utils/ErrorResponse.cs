using System.Net;

namespace ProTips.Entity.Utils;

public class ErrorResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public Exception Exception { get; set; }
}