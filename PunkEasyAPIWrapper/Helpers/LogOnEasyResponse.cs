using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkEasyAPIWrapper.Helpers
{
    public enum AccountsTypes
    {
        CustomerNumber, SmartCardNumber
    }
    public class LogOnEasyResponse
    {
        public Customerdetails customerDetails { get; set; }
        public Account[] accounts { get; set; }
        public string AuditReferenceNumber { get; set; }
    }

    public class Customerdetails
    {
        public int number { get; set; }
        public string salutation { get; set; }
        public string initials { get; set; }
        public string surname { get; set; }
        public string emailAddress { get; set; }
        public string cellNumber { get; set; }
        public string faxNumber { get; set; }
        public string workTelephone { get; set; }
        public string homeTelephone { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string typeName { get; set; }
        public string language { get; set; }
        public string vATRegNo { get; set; }
        public string correspondence { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirh { get; set; }
        public string Priority { get; set; }
        public Reference Reference { get; set; }
        public string MgIndicator { get; set; }
        public string AuditReferenceNumber { get; set; }
    }

    public class Reference
    {
        public string type { get; set; }
        public string value { get; set; }
        public string Description { get; set; }
    }

    public class Account
    {
        public int number { get; set; }
        public bool isPrimary { get; set; }
        public string segmentation { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public float totalBalance { get; set; }
        public float afterDue1To30Field { get; set; }
        public float afterDue31To60Field { get; set; }
        public float afterDue61To90Field { get; set; }
        public float afterDue91To120Field { get; set; }
        public float afterDue121To150 { get; set; }
        public float afterDue151To180 { get; set; }
        public float afterDue180UpField { get; set; }
        public string methodOfPayment { get; set; }
        public DateTime lastInvoiceDate { get; set; }
        public DateTime paymentDueDate { get; set; }
        public float lastInvoiceAmount { get; set; }
        public float currentAmount { get; set; }
        public int invoicePeriod { get; set; }
        public string currency { get; set; }
        public string defaultCuurencyCode { get; set; }
        public float defaultCurrencytotalBalance { get; set; }
    }

    public class SignInResponse
    {
        public string customerName { get; set; }
        public List<SmartCard> smartCards { get; set; }

        public SignInResponse(LogOnEasyResponse logOnEasy)
        {
            customerName = logOnEasy.customerDetails.FirstName + " " + logOnEasy.customerDetails.surname;
            smartCards = new List<SmartCard>();
            buildSmartCards(logOnEasy.accounts);

        }

        private void buildSmartCards(Account[] accounts)
        {
            foreach (var account in accounts)
            {
                smartCards.Add(new SmartCard() { accountHolder = customerName, balance = account.totalBalance, currency = account.currency, currentAmount = account.currentAmount, defaultCurrencytotalBalance = account.defaultCurrencytotalBalance, defaultCuurencyCode = account.defaultCuurencyCode, invoicePeriod = account.invoicePeriod, isPrimary = account.isPrimary, lastInvoiceAmount = account.lastInvoiceAmount, package = account.type, status = account.status, paymentDueDate = account.paymentDueDate, smartCardNumber = account.number, segmentation = account.segmentation });
            }
        }
    }

    public class SmartCard
    {
        public int smartCardNumber { get; set; }
        public string accountHolder { get; set; }
        public float balance { get; set; }
        public string package { get; set; }
        public string status { get; set; }
        public DateTime paymentDueDate { get; set; }
        public float lastInvoiceAmount { get; set; }
        public float currentAmount { get; set; }
        public int invoicePeriod { get; set; }
        public string currency { get; set; }
        public string defaultCuurencyCode { get; set; }
        public float defaultCurrencytotalBalance { get; set; }
        public bool isPrimary { get; set; }
        public string segmentation { get; set; }
        public string type { get; set; }
    }

    public class SignInRequest
    {
        public string dataSource { get; set; }
        public string number { get; set; }
        public string currencyCode { get; set; }
        public string type { get; set; }
        public string ReferenceValue { get; set; }
        public string vendorCode { get; set; }
        public string businessUnit { get; set; }
        public string language { get; set; }
        public string ipAddress { get; set; }

        public override string ToString()
        {
            return $"dataSource={dataSource}&number={number}" +
                $"&currencyCode={currencyCode}&type={type}" +
                $"&ReferenceValue={ReferenceValue}&vendorCode={vendorCode}" +
                $"&businessUnit={businessUnit}&language={language}" +
                $"&ipAddress={ipAddress}";
        }

    }
}
