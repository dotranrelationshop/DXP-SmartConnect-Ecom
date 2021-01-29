namespace DXP.SmartConnect.Ecom.SharedKernel.WebApi
{
    public class WebApiFaultHandleConfiguration
    {
        public int MaxRetryAttempts { get; set; }
        public int InitialRetryDelayInSec { get; set; }
        public int DurationOnBreakInSec { get; set; }
        public int ExceptionsAllowedBeforeBreaking { get; set; }
        public int WebApiTimeoutInMs { get; set; }
    }
}
