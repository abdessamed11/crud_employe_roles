using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_étudiants.Models
{
    public class Etudiant
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Entrer le nom")]
        [Display(Name ="Nom de l'etudiant")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Entrer le prenom")]
        [Display(Name = "prenom de l'etudiant")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Entrer le Cin")]
        [Display(Name = "cin de l'etudiant")]
        public string Cin { get; set; }

        [Required(ErrorMessage = "Entrer l'adresse")]
        [Display(Name = "adresse de l'etudiant")]
        public string Adresse { get; set; }
    }
}
