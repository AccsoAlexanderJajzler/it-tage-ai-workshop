using System.Net;

namespace Service.DWD.Model;
public class GenericResult
{
    public object? Content { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}