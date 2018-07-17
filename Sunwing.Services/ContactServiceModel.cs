using Sunwing.Business.DAL.Entities;
using Sunwing.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Sunwing.Utility;

namespace Sunwing.Web.Models
{
	[DataContract]
	public class ContactServiceModel : ValidatableViewModel<ContactServiceModel, Person>
	{
		[DataMember]
		public long Id { get; set; }

		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public DateTime? Birthday { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string Telephone { get; set; }

		[DataMember]
		public string Name { get { return string.Concat(FirstName, " ", LastName).Trim(); } }

		[DataMember]
		public string ContactType { get; set; }
	}
}