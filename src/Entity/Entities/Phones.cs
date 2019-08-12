using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    [Table("Phones", Schema = "dbo")]
    public class Phones
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("idUser")]
        public int idUser { get; set; }

        [Column("number")]
        public string number { get; set; }

        [Column("area_code")]
        public string area_code { get; set; }

        [Column("country_code")]
        public string country_code { get; set; }
    }
}
