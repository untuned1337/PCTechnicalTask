using System;

namespace PresentConnectionTechnicalTask
{
    public static class BillPrinter
    {
        public static void PrintBillToConsole(Bill bill)
        {
            PrintFormattedParticipants(bill);
            PrintFormattedBillHeader(bill);
            PrintFormattedBillRow(bill);
        }

        private static void PrintFormattedParticipants(Bill bill)
        {
            string formattedParticipants = FormatBillParticipants(bill.ClientName, bill.ProviderName);
            Console.WriteLine(formattedParticipants);
        }

        private static string FormatBillParticipants(string clientName, object providerName)
        {
            string formattedBillParticipants = String.Format("Provider - {0}\nClient - {1}", providerName, clientName);

            return formattedBillParticipants;
        }

        private static void PrintFormattedBillHeader(Bill bill)
        {
            string formattedHeader = FormatBillHeader(bill);
            Console.WriteLine(formattedHeader);
        }

        private static string FormatBillHeader(Bill bill)
        {
            string header = String.Format("|{0,-17}|{1,-17}|{2,-10}|{3,-17}|",
                "Service", "Price Before VAT", "VAT Rate", "Price After VAT");

            return header;
        }

        private static void PrintFormattedBillRow(Bill bill)
        {
            string formattedBillRow = FormatBillRow(bill);
            Console.WriteLine(formattedBillRow);
        }
             
        private static string FormatBillRow(Bill bill)
        {
            string formattedBillInfo = String.Format("|{0,-17}|{1,-17}|{2,-10}|{3,-17}|",
                bill.Service.ServiceDescription,
                String.Format("{0:0.00}", bill.Service.ServicePrice),
                bill.VATRate,
                String.Format("{0:0.00}", bill.ServicePriceAfterVAT));

            return formattedBillInfo;
        }
    }
}
