using System;
using System.Collections.Generic;

namespace LibraryManagement.Shared.Models;

public partial class NoticeDipDisEtab
{
    public decimal IdDiplome { get; set; }

    public decimal IdEtablissement { get; set; }

    public decimal IdDiscipline { get; set; }

    public decimal IdNotice { get; set; }

    public string? NoteTexte { get; set; }

    public string? AnneSoutenance { get; set; }

    public virtual Diplome Diplome { get; set; } = null!;

    public virtual Discipline Discipline { get; set; } = null!;

    public virtual Etablissement Etablissement { get; set; } = null!;

    public virtual Notice Notice { get; set; } = null!;
}
