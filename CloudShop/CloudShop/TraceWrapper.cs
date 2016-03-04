using System.Diagnostics;

namespace CloudShop
{
    public class TraceWrapper : ITraceWrapper
    {
        public void Information(string message)
        {
            Trace.TraceInformation(message);
        }
    }
}