using Sunwing.Services;
using Sunwing.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Sunwing.Business.Servies;
using System.Net;
using Sunwing.Business.DAL.Entities;
using Sunwing.Utility;
using AutoMapper;
using System.Collections;

namespace Sunwing.Web.Controllers
{
	public class ContactManagerAPIController : ApiController, ICrudServies<ContactServiceModel>
	{
		private readonly IContactService _contactsService;

		public ContactManagerAPIController(ContactsService contactsService) {

			_contactsService = contactsService;
			
		}
	
		//Get all contacts including supplier
		public HttpResponseMessage Get()
		{
			ContactServiceModel csVM = new ContactServiceModel();
			List<ContactServiceModel> lstCSVM = new List<ContactServiceModel>();

			Mapper.CreateMap<ContactServiceModel, Person>();

			if (_contactsService.GetAll().Select(ContactServiceModel.MapFromEntity) != null)
				lstCSVM.AddRange(_contactsService.GetAll().Select(ContactServiceModel.MapFromEntity));
			
			GetRequestConfig();
			if (lstCSVM.Count > 0)
				return Request.CreateResponse(HttpStatusCode.OK, lstCSVM);
			else
				return Request.CreateResponse(HttpStatusCode.NoContent, lstCSVM);
		}

		public void GetRequestConfig() {

			Request = new HttpRequestMessage();
			var configuration = new HttpConfiguration();
			Request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
		}

		//Get contacts by Id
		public HttpResponseMessage Get(int id)
		{
			var person = new Person();
			GetRequestConfig();

			var contact = _contactsService.GetContact(id);
			if (contact == null)
			{
				Request.CreateResponse(HttpStatusCode.NotFound);
			}

			Mapper.CreateMap<ContactServiceModel, Person>();

			return Request.CreateResponse(HttpStatusCode.OK, ContactServiceModel.MapFromEntity(person));
		}

		//Update contact
		public HttpResponseMessage Put([FromBody]ContactServiceModel updatedContactVM)
		{
			GetRequestConfig();
			// Check if contact exists to update.
			if (updatedContactVM.Id == 0 || !_contactsService.Any(updatedContactVM.Id))
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, MessageConst.UpdateErr);
			}

			Person person = updatedContactVM.MapToEntity();

			if (!_contactsService.Update(person))
			{
				return Request.CreateResponse(HttpStatusCode.NotModified, MessageConst.UpdateErr);
			}

			return new HttpResponseMessage(HttpStatusCode.OK);
		}

		//Create contact
		public HttpResponseMessage Post(ContactServiceModel contact)
		{
			GetRequestConfig();
			Person person = contact.MapToEntity();
			var addedContact = _contactsService.AddContact(person);
			return Request.CreateResponse(HttpStatusCode.Created, addedContact);
		}

		//Delete contact
		public HttpResponseMessage Delete(int id)
		{
			GetRequestConfig();
			var item = _contactsService.GetContact(id);
			if (item == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound, MessageConst.DeleteErr);
			}

			return Request.CreateResponse(HttpStatusCode.OK, _contactsService.Delete(id));
		}
	}
}