using Moq;
using Xunit;

namespace CloudShop.Test.Unit
{
    public class CustomerControllerTests
    {
        [Fact]
        public void Get_Logs_Information_Message()
        {
            var logger = new Mock<ILogger>();
            logger.Setup(m => m.Info("TEST_MESSAGE"));

            var customerController = new CustomerController(logger.Object);

            var result = customerController.Get().Result;

            logger.Verify(m => m.Info("TEST_MESSAGE"), Times.Once());
        }
    }
}
