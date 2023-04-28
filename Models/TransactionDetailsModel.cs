namespace PaymentModule.Models
{
    public class TransactionDetailsModel
    {
        public int documentNumber{ get; set; }
        public int transactionID { get; set; }
        public double transactionAmount { get; set; }
        public int biller { get; set; }
        public int transactionType { get; set; }
        public int paymentType { get; set; }
    }
}
