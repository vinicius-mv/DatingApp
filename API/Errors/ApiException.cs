using System;

namespace API.Errors;

public class ApiException(int StatusCode, string Message, string? Details)
{

}
