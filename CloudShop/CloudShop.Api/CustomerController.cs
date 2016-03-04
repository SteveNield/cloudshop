using System.Threading.Tasks;
using System.Web.Http;

namespace CloudShop.Api
{
    public class CustomerController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            return await Task.Run(() => Ok("OK"));
        }
    }
}
