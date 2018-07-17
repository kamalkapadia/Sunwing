using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sunwing.Business.DAL.Entities
{
	public class Person
	{
		[Key]
		public long Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? Birthday { get; set; }
		public string Email { get; set; }
		public string Telephone { get; set; }

		public string Name { get { return string.Concat(FirstName, " ", LastName).Trim(); } }

		public string ContactType { get; set; }
	}
}
