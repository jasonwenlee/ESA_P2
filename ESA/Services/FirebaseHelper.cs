using ESA.Models.Model;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESA.Services
{
    public class FirebaseHelper
    {
        public async Task<List<Person>> GetAllPersons()
        {

            return (await App.firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  PersonName = item.Object.PersonName,
                  PersonId = item.Object.PersonId
              }).ToList();
        }

        public async Task AddPerson(int personId, string name)
        {

            await App.firebase
              .Child("Persons")
              .PostAsync(new Person() { PersonId = personId, PersonName = name });
        }

        public async Task<Person> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await App.firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }

        public async Task UpdatePerson(int personId, string name)
        {
            var toUpdatePerson = (await App.firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await App.firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonId = personId, PersonName = name });
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await App.firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await App.firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}
