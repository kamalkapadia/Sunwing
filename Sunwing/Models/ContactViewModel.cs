using Sunwing.Business.DAL.Entities;
using Sunwing.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sunwing.Web.Models
{
	public class ContactViewModel: EntitiyMapperViewModel<ContactViewModel, Person>
	{
		[Key]
		public long Id { get; set; }
		[MaxLength(50)]
		public string FirstName { get; set; }
		[MaxLength(50)]
		public string LastName { get; set; }
		public DateTime? Birthday { get; set; }
		[RegularExpression(@"/^[-!#-'*+\/-9=?^-~]+(?:\.[-!#-'*+\/-9=?^-~]+)*@[-!#-'*+\/-9=?^-~]+(?:\.[-!#-'*+\/-9=?^-~]+)+$/i", ErrorMessage = "Please enter valid email address.")]
		public string Email { get; set; }

		[MaxLength(12)]
		[RegularExpression(@"/^[+]?(?:\(\d+(?:\.\d+)?\)|\d+(?:\.\d+)?)(?:[ -]?(?:\(\d+(?:\.\d+)?\)|\d+(?:\.\d+)?))*(?:[ ]?(?:x|ext)\.?[ ]?\d{1,5})?$/", ErrorMessage = "Phone number length should be maximum 12 and must have atleast 7 numbers.")]
		public string Telephone { get; set; }

		public string ContactType { get; set; }
	}
}