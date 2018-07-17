using System.Net.Http;
using System.Web.Http;

namespace Sunwing.Services
{
    public interface ICrudServies <in T>
    {
		// READ ALL
		HttpResponseMessage Get();
		// UPDATE
		HttpResponseMessage Put([FromBody] T updatedItem);
		// CREATE
		HttpResponseMessage Post(T item);
		// READ By ID
		HttpResponseMessage Get(int id);
		// DELETE
		HttpResponseMessage Delete(int id);

	}
}
