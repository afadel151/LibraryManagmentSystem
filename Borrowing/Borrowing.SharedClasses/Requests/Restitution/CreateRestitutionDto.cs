namespace Borrowing.SharedClasses.Requests.Restitution;

class CreateRestitutionDto
{
    public string AdherentId { get; set; } = string.Empty;
    public string ExemplaireId { get; set; } = string.Empty;
    public bool Renouvlement { get; set; } = false;
}
