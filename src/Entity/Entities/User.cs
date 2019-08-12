using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    [Table("Users", Schema = "dbo")]
    public class User
    {

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Column("firstName")]
        public string firstName { get; set; }

        [Column("lastName")]
        public string lastName { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("created_at")]
        public DateTime? created_at { get; set; }

        [Column("last_login")]
        public DateTime? last_login { get; set; }

        [NotMapped]
        public List<Phones> phones { get; set; }
    }
}
