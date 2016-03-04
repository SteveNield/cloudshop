using Moq;
using Xunit;

namespace CloudShop.Test.Unit
{

    public class AzureTraceLoggerTests
    {
        [Fact]
        public void Can_Log_Information_Message()
        {
            var traceWrapper = new Mock<ITraceWrapper>();
            traceWrapper.Setup(m => m.Information("TEST_LOG_MESSAGE"));

            ILogger logger = new AzureTraceLogger(traceWrapper.Object);

            logger.Info("TEST_LOG_MESSAGE");

            traceWrapper.Verify(m => m.Information("TEST_LOG_MESSAGE"), Times.Once());
        }
    }
}
