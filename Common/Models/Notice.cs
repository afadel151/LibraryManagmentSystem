using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class Notice
{
    public decimal IdNotice { get; set; }

    public decimal? IdSourceArticle { get; set; }

    public decimal IdType { get; set; }

    public string? IdPeriodicite { get; set; }

    public string? TitrePropre { get; set; }

    public string? SousTitre { get; set; }

    public string? NPartie { get; set; }

    public string? CollationImpMaterielle { get; set; }

    public string? CollationAutresCarMat { get; set; }

    public string? CollationFormat { get; set; }

    public decimal? NbrExemple { get; set; }

    public string? Cote { get; set; }

    public string? Localisation { get; set; }

    public string? Cdd { get; set; }

    public string? Resume { get; set; }

    public string? Isbn { get; set; }

    public string? Date1erPub { get; set; }

    public string? TitreCle { get; set; }

    public string? NumeroVol { get; set; }

    public string? IssnNotice { get; set; }

    public string? NoteGenerale { get; set; }

    public decimal? IsIndexed { get; set; }

    public string? Accessibilite { get; set; }

    public decimal? ExemplaireExiste { get; set; }

    public string? TypeDonneesResourceElec { get; set; }

    // one to one, IdNotice is a PK in other table
    public virtual NoticeDipDisEtab? NoticeDipDisEtab { get; set; }

    // meme besoin ?
    public virtual NoticeMentionEdition? NoticeMentionEdition { get; set; }
    public virtual MentionEdition? MentionEdition { get; set; }



    // one to many relationships forward
    public virtual TableCdd? TableCdd { get; set; } = null!;
    public virtual Periodicite? Periodicite { get; set; }
    public virtual SourceArticle? SourceArticle { get; set; }
    public virtual TypeNotice TypeNotice { get; set; } = null!;





    // on to many  backward
    public virtual ICollection<NoticeEdition> NoticeEditions { get; set; } = [];
    public virtual ICollection<NoticeCollection> NoticeCollections { get; set; } = [];
    public virtual ICollection<AuteurSecondaire> AuteurSecondaires { get; set; } = [];
    public virtual ICollection<NoticeTerme> NoticeTermes { get; set; } = [];
    public virtual ICollection<NoticeTermeExact> NoticeTermeExacts { get; set; } = [];
    public virtual ICollection<Exemplaire> Exemplaires { get; set; } = [];
    public virtual ICollection<Reservation> Reservations { get; set; } = [];

    // many to many 
    public virtual ICollection<MentionResponsabilite> CoAuteurs { get; set; } = [];

    public virtual ICollection<MentionResponsabilite> Auteurs { get; set; } = [];
    public virtual ICollection<MentionResponsabilite> AuteurSecondairesMentionRes { get; set; } = [];



    public virtual ICollection<Terme> Termes { get; set; } = [];
    public virtual ICollection<TermeExact> TermeExacts { get; set; } = [];
    public virtual ICollection<CollectionModel> Collections { get; set; } = [];

    public virtual ICollection<Pay> Pays { get; set; } = [];

    public virtual ICollection<MotsCle> MotsCles { get; set; } = [];
    public virtual ICollection<Langue> Langues { get; set; } = [];
    public virtual ICollection<Selection> Selections { get; set; } = [];

}
