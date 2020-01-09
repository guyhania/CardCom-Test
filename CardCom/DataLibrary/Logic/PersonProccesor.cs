using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class PersonProccesor
    {
        public static int CreatePerson(string personId, string firstName,
            string lastName, string emailAddress, DateTime dob,string gender, string phoneNumber)
        {
            var gen = (gender == "male") ? "1" : "0";
            PersonM data = new PersonM
            {
                PersonId = personId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                DateOfBirth = dob,
                Gender = gen,
                PhoneNumber = phoneNumber
            };

            string sql = @"INSERT INTO dbo.Person (PersonId,FirstName,LastName, EmailAddress
                          ,DateOfBirth, PhoneNumber) VALUES (@PersonId, @FirstName, @LastName, @EmailAddress, @DateOfBirth, @PhoneNumber);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdatePerson(string personId, string firstName,
            string lastName, string emailAddress, DateTime dob,string gender, string phoneNumber)
        {
            var gen = (gender == "male") ? "1" : "0";
            PersonM data = new PersonM
            {
                PersonId = personId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                DateOfBirth = dob,
                Gender = gen,
                PhoneNumber = phoneNumber
            };

            string sql = @"UPDATE dbo.Person
                           SET PersonId=@PersonId,
                               FirstName = @FirstName,
                               LastName = @LastName,
                               EmailAddress = @EmailAddress,
                               DateOfBirth = @DateOfBirth,
                               PhoneNumber = @PhoneNumber
                               WHERE PersonId = @PersonId;";


            return SqlDataAccess.SaveData(sql,data);
        }

        public static List<PersonM> LoadPersons()
        {
            string sql = @"SELECT Id, PersonId, FirstName, LastName, EmailAddress, DateOfBirth, PhoneNumber  
                          FROM dbo.Person;";
            return SqlDataAccess.LoadData<PersonM>(sql);
        }

        public static PersonM LoadPerson(string Id)
        {
            string sql = @"SELECT * FROM dbo.Person WHERE PersonID = @Id";

            return SqlDataAccess.LoadSingleData<PersonM>(sql,Id);
        }

        public static void DeletePerson(string Id)
        {
            string sql = @"DELETE dbo.Person WHERE PersonID = @Id";

             SqlDataAccess.DeleteData(sql, Id);
        }

        public static bool Hasperson(string Id)
        {
            string sql = @"SELECT count(1) FROM dbo.Person WHERE PersonID=@id";

            return SqlDataAccess.IsExist(sql, Id);
        }
    }
}
