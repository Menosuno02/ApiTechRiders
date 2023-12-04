﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_ALTA_USERS")]
    public class PeticionAltaUsers
    {
        [Key]
        [Column("IDPETICION")]
        public int IdPeticion { get; set; }
        [Column("IDUSER")]
        public int IdUser { get; set; }
    }
}
