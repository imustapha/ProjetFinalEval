//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetFinalEval
{
    using System;
    using System.Collections.Generic;
    
    public partial class collaborateurpe
    {
        public collaborateurpe()
        {
            this.evaluation = new HashSet<evaluation>();
            this.projet = new HashSet<projet>();
        }
    
        public int IDCOLLABORATEURPE { get; set; }
        public int IDFONCTION { get; set; }
        public string NOMPE { get; set; }
        public string PRENOMPE { get; set; }
        public byte[] IMAGEPE { get; set; }
        public string STATUT { get; set; }
        public string IdUser { get; set; }
    
        public virtual aspnetusers aspnetusers { get; set; }
        public virtual ICollection<evaluation> evaluation { get; set; }
        public virtual fonction fonction { get; set; }
        public virtual ICollection<projet> projet { get; set; }
    }
}
