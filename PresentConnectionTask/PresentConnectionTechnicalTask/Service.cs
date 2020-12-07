
namespace PresentConnectionTechnicalTask
{
    public class Service
    {
        public string ServiceDescription { get; set; }
        public double ServicePrice { get; set; }

        public Service(string serviceDescription, double servicePrice)
        {
            ServiceDescription = serviceDescription;
            ServicePrice = servicePrice;
        }
    }
}
