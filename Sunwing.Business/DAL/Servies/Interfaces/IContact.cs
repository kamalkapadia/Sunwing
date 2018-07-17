using System;
using System.Collections.Generic;

namespace Sunwing.Business.Servies.Interfaces
{
	public interface IContact<T>: IDisposable
	{
		T AddContact(T contact);
		T GetContact(int Id);
		IEnumerable<T> GetAll();
		bool Update(T updateContact);
		bool Delete(long Id);
		bool Any(long Id);
	}
}
