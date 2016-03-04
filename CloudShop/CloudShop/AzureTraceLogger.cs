namespace CloudShop
{
    public class AzureTraceLogger : ILogger
    {
        private readonly ITraceWrapper _traceWrapper;

        public AzureTraceLogger(ITraceWrapper traceWrapper)
        {
            _traceWrapper = traceWrapper;
        }

        public void Info(string message)
        {
            _traceWrapper.Information(message);
        }
    }
}