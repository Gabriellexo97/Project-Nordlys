using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Nordlys.Game.Habbos
{
    [Table("users")]
    public class Habbo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [StringLength(20)]
        [Column("name")]
        public string Username { get; private set; }

        [Column("rank")]
        public sbyte Rank { get; private set; }

        [Column("signed_up")]
        public DateTime SignedUp { get; private set; }

        [StringLength(50)]
        [Column("email")]
        public string Email { get; private set; }

        [Column("date_of_birth")]
        public string DateOfBirth { get; private set; }
        
        [StringLength(40)]
        [Column("motto")]
        public string Motto { get; private set; }

        [StringLength(90)]
        [Column("figure")]
        public string Figure { get; private set; }

        [StringLength(1)]
        [Column("gender")]
        public string Gender { get; private set; }

        [Column("coins")]
        public int Coins { get; private set; }

        [Column("achievement_points")]
        public int AchievementPoints { get; private set; }

        [StringLength(70)]
        [Column("authentication_ticket")]
        public string AuthenticationTicket { get; private set; }
    }
}
