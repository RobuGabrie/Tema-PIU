using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Modele.ClaseModele
{
    public class AdminUser
    {
        private static readonly string filePath = "useri.json";
        private User? userCurent;

        public AdminUser()
        {
            userCurent = null;
        }

     
        public User GetUserCurent()
        {
            if (userCurent == null)
            {
                throw new Exception("Nu există utilizator curent.");
            }
            return userCurent;
        }

      
        public bool EsteAutentificat()
        {
            return userCurent != null;
        }


        public bool Inregistrare(string nume, string email, string parola)
        {
            List<User> useri = AdaugaUseri();

            if (useri.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            int nextId = useri.Count > 0 ? useri.Max(u => u.Id) + 1 : 1;
            User newUser = new User(nextId, nume, email, parola);
            useri.Add(newUser);


            SalveazaUseri(useri);

            userCurent = newUser;

            return true;
        }
      
        public bool Autentificare(string email, string parola)
        {
            List<User> useri = AdaugaUseri();
            User? user = useri.FirstOrDefault(u =>
                u.Email == email &&
                u.Parola == parola);

            if (user != null)
            {
                userCurent = user;
                return true;
            }

            return false;
        }

        public void Deconectare()
        {
            userCurent = null;
        }

        private List<User> AdaugaUseri()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
            }
            return new List<User>();
        }
        private void SalveazaUseri(List<User> useri)
        {
            string jsonString = JsonSerializer.Serialize(useri, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
