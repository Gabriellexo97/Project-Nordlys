using System;
using System.Data;

namespace Nordlys.Game.Habbos
{
    public class Habbo
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public sbyte Role { get; private set; }
        public DateTime SignedUp { get; private set; }
        public string Email { get; private set; }
        public string DOB { get; private set; }
        public string Motto { get; private set; }
        public string Figure { get; private set; }
        public string Gender { get; private set; }
        public int Coins { get; private set; }

        public Habbo(DataRow row)
        {
            Id = (int)row["id"];
            Username = (string)row["username"];
            Role = (sbyte)row["role"];
            SignedUp = (DateTime)row["signedup"];
            Email = (string)row["email"];
            DOB = (string)row["dob"];
            Motto = (string)row["motto"];
            Figure = (string)row["figure"];
            Gender = (string)row["gender"];
            Coins = (int)row["coins"];
        }
    }
}
