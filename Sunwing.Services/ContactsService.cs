using Sunwing.Business.DAL.Entities;
using Sunwing.Business.Servies.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunwing.Business.Servies
{
	public interface IContactService : IContact<Person>
	{ }

	public class ContactsService : IContactService
	{
		private static int NewIncrementIds = 0;

		private static int GetNewInsertId()
		{
			NewIncrementIds++;
			return NewIncrementIds;
		}

		// Mock database with some sample data
		private static readonly List<Person> mockPersonData = new List<Person>
		{
			//DateTime.ParseExact("03/12/1980", "dd-MM-yyyy", CultureInfo.InvariantCulture)
			new Person{Id = GetNewInsertId(), Birthday = DateTime.Parse("2009-12-18 10:54:50"), Email="cindyp@gmail.com", FirstName="Cindy", LastName="P", Telephone="111-222-3333",ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.MinValue, Email="monas@gmail.com", FirstName="Mona", LastName="S", Telephone="222-333-4444",ContactType="S",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.MinValue, Email="peterm@gmail.com", FirstName="Peter", LastName="M", Telephone="333-444-5555",ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.Parse("2009-12-18 10:54:50"), Email="heers@gmail.com", FirstName="Heer", LastName="S", Telephone="444-555-6666", ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.Parse("2009-12-18 10:54:50"), Email="Jhonp@gmail.com", FirstName="Jhon", LastName="P", Telephone="555-666-7777", ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.Parse("2009-12-18 10:54:50"), Email="MartinH@gmail.com", FirstName="Martin", LastName="H", Telephone="666-777-8888", ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.MinValue, Email="adamK@gmail.com", FirstName="Adam", LastName="K", Telephone="777-888-9999", ContactType="S",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.MinValue, Email="NicoleP@gmail.com", FirstName="Nicole", LastName="P", Telephone="888-999-0000", ContactType="S",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.Parse("2009-12-18 10:54:50"), Email="brianm@gmail.com", FirstName="Brian", LastName="M", Telephone="999-789-0000", ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.Parse("2009-12-18 10:54:50"), Email="PeterG@gmail.com", FirstName="Peter", LastName="G", Telephone="123-345-6666", ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.MinValue, Email="miked@gmail.com", FirstName="Mike", LastName="D", Telephone="222-444-3333", ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.MinValue, Email="kater@gmail.com", FirstName="Kate", LastName="R", Telephone="111-202-5555", ContactType="S",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.MinValue, Email="lauraf@gmail.com", FirstName="laura", LastName="R", Telephone="111-200-3000", ContactType="C",},
			new Person{Id = GetNewInsertId(), Birthday = DateTime.Parse("2009-12-18 10:54:50"), Email="dabbyw@gmail.com", FirstName="Dabby", LastName="w", Telephone="222-222-3333", ContactType="S",},
		};

		public Person AddContact(Person contact)
		{
			mockPersonData.Add(contact);
			contact.Id = GetNewInsertId();
			return contact;
		}

		public bool Any(long Id)
		{
			return mockPersonData.Any(Person => Person.Id == Id);
		}

		public bool Any(string name)
		{
			return mockPersonData.Any(Person => Person.Name == name);
		}

		public bool Delete(long Id)
		{
			var contactToRemove = mockPersonData.SingleOrDefault(Person => Person.Id == Id);
			if (contactToRemove == null) return false;
			return mockPersonData.Remove(contactToRemove);
		}

		public bool Delete(string Name)
		{
			var contactToRemove = this.Get(Name);
			if (contactToRemove == null)
				return false;

			return this.Delete(contactToRemove.Id);
		}

		public void Dispose()
		{
			mockPersonData.Clear();
		}

		public IEnumerable<Person> GetAll()
		{
			return mockPersonData;
		}

		public Person GetContact(int Id)
		{
			return mockPersonData.SingleOrDefault(Person => Person.Id == Id);
		}

		public Person Get(string name)
		{
			return mockPersonData.SingleOrDefault(Person => Person.Name == name);
		}

		public bool Update(Person updateContact)
		{
			// Check for NULL
			if (updateContact == null) return false;

			// Check if Item must exists
			if (!this.Any(updateContact.Id)) return false;

			var dbContact = mockPersonData.Find(Person => Person.Id == updateContact.Id);

			dbContact.FirstName = updateContact.FirstName;
			dbContact.LastName = updateContact.LastName;
			dbContact.Telephone = updateContact.Telephone;
			if(updateContact.Birthday != DateTime.MinValue)
				dbContact.Birthday = updateContact.Birthday;
			dbContact.Email = updateContact.Email;

			return true;
		}
	}
}
