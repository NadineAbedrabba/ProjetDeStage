using Client.Interface.Models;

namespace Client.Interface.Data
{
    public class ClientContext
    {
        
            public static List<ClientClass> clients = new List<ClientClass>
        {

            new ClientClass
            {
                Id = 1,
                FirstName = "Ahmed",
                LastName = "Ben Ali",
                Email = "ahmed.benali@example.com",
                PhoneNumber = "+216 92345678",
                Address = "12 Rue de la Liberté",
                City = "Tunis",
                PostalCode = "1000",
                Country = "Tunisia",
                DateOfBirth = new DateTime(1980, 5, 14),
                RegistrationDate = DateTime.Now
            },
            new ClientClass
            {
                Id = 2,
                FirstName = "Fatima",
                LastName = "Jebali",
                Email = "fatima.jebali@example.com",
                PhoneNumber = "+216 57654321",
                Address = "45 Avenue Mohamed V",
                City = "Sfax",
                PostalCode = "3000",
                Country = "Tunisia",
                DateOfBirth = new DateTime(1992, 7, 21),
                RegistrationDate = DateTime.Now
            },
            new ClientClass
            {
                Id = 3,
                FirstName = "Omar",
                LastName = "El Kharraz",
                Email = "omar.elkharraz@example.com",
                PhoneNumber = "+216 23456789",
                Address = "78 Boulevard de l'Indépendance",
                City = "Nabeul",
                PostalCode = "8000",
                Country = "Tunisia",
                DateOfBirth = new DateTime(1985, 11, 11),
                RegistrationDate = DateTime.Now
            },
            new ClientClass
            {
                Id = 4,
                FirstName = "Amina",
                LastName = "Sghaier",
                Email = "amina.sghaier@example.com",
                PhoneNumber = "+216 94567890",
                Address = "9 Rue de l'Artisanat",
                City = "Kairouan",
                PostalCode = "3100",
                Country = "Tunisia",
                DateOfBirth = new DateTime(1995, 2, 6),
                RegistrationDate = DateTime.Now
            },
            new ClientClass
            {
                Id = 5,
                FirstName = "Mouhamed",
                LastName = "Mahjoub",
                Email = "mouhamed.mahjoub@example.com",
                PhoneNumber = "+216 25678901",
                Address = "33 Rue des Oliviers",
                City = "Monastir",
                PostalCode = "5000",
                Country = "Tunisia",
                DateOfBirth = new DateTime(1978, 9, 30),
                RegistrationDate = DateTime.Now
            }
        };

        }
    }

