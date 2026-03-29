namespace Borrowing.SharedClasses.Responses.Pret;
using System;
using Shared.Models;

public class CreatePretResponseDto
{
    public bool Done {get;set;} = true;
    public string Message {get;set;} = string.Empty;
}
