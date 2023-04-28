namespace PaymentModule.Models
{
    public class TransactionHeaderModel
    {
        public int transactionID { get; set; }
        public double amountTotal { get; set; }
        public string transactionDate { get; set; }
        public double EWT { get; set; }
        public string transactionType { get; set; }
        public bool isDeleted { get; set; }
    }
}
