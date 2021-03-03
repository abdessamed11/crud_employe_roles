using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_étudiants.Models
{
    public class Role
    {
        [Required]
        public string RoleName { get; set; }

        public string id { get; set; }

        public List<string> Users { get; set; }

        public Role()
        {
            Users = new List<string>();
        }
    }
}
