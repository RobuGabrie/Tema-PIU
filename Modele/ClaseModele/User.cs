using System;
using System.Text.Json.Serialization;

namespace Modele.ClaseModele
{
    public class User
    {
        public int Id { get; private set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }

        [JsonConstructor]
        public User(int id, string nume, string email, string parola)
        {
            Id = id;
            Nume = nume;
            Email = email;
            Parola = parola;
        }

        public override string ToString()
        {
            return $"User Id: {Id}, Nume: {Nume}, Email: {Email}";
        }
    }
}
