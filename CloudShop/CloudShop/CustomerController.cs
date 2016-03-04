using System.Threading.Tasks;
using System.Web.Http;

namespace CloudShop
{
    public class CustomerController : ApiController
    {
        private readonly ILogger _logger;

        public CustomerController(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<IHttpActionResult> Get()
        {
            _logger.Info("TEST_MESSAGE");
            return await Task.Run(() => Ok("OK"));
        }
    }
}
