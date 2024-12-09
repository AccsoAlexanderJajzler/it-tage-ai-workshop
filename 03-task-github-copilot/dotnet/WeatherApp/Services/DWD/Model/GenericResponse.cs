using System.Net;

namespace Service.DWD.Model;
public class GenericResponse
{
    public string? Content { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}