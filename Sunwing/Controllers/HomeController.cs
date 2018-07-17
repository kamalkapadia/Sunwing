using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using Sunwing.Web.Models;
using Sunwing.Business.Servies;
using System.Net;
using Sunwing.Business.DAL.Entities;
using Sunwing.Utility;
using AutoMapper;
using Sunwing.Web.Controllers;
using Newtonsoft.Json;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Sunwing.Controllers
{
	public class HomeController : Controller
	{
		public ContactsService contactsService;
		public ContactManagerAPIController cmAPI;

		public HomeController()
		{
			
		}

		//Get all contacts including supplier
		public ActionResult Get([DataSourceRequest]DataSourceRequest request)
		{
			contactsService = new ContactsService();
			cmAPI = new ContactManagerAPIController(contactsService);

			var ResultString = cmAPI.Get().Content.ReadAsStringAsync().Result;

			var result = JsonConvert.DeserializeObject<IEnumerable<ContactViewModel>>(ResultString);

			return View(Json(ResultString.ToDataSourceResult(request), JsonRequestBehavior.AllowGet));
		}

		//Get contacts by Id
		public ActionResult GetContactbyId(int id)
		{
			contactsService = new ContactsService();
			cmAPI = new ContactManagerAPIController(contactsService);

			var contact = cmAPI.Get(id);

			var person = new Person();
			var contactVNM = ContactViewModel.MapFromEntity(person);
			return View(contactVNM);
		}

		//Update contact
		public ActionResult Put([FromBody]ContactViewModel updatedContactVM)
		{
			contactsService = new ContactsService();
			cmAPI = new ContactManagerAPIController(contactsService);

			// Check if contact exists to update.
			Mapper.CreateMap<ContactViewModel, ContactServiceModel>();
			ContactServiceModel csvcVM = Mapper.Map<ContactViewModel, ContactServiceModel>(updatedContactVM);

			cmAPI.Put(csvcVM);

			return RedirectToAction("Get");
		}

		//Create contact
		public ActionResult Post(ContactViewModel contact)
		{
			contactsService = new ContactsService();
			cmAPI = new ContactManagerAPIController(contactsService);

			Mapper.CreateMap<ContactViewModel, ContactServiceModel>();
			ContactServiceModel csvcVM = Mapper.Map<ContactViewModel, ContactServiceModel>(contact);

			var addedContact = cmAPI.Post(csvcVM);
			return RedirectToAction("Get");
		}

		//Delete contact
		public ActionResult Delete(int id)
		{
			contactsService = new ContactsService();
			cmAPI = new ContactManagerAPIController(contactsService);

			var contactExist = cmAPI.Get(id);
			if (contactExist == null)
			{
				return View("The contact doesn't exist in database!");
			}
			else {
				cmAPI.Delete(id);
			}
			return RedirectToAction("Get");
		}
	}
}