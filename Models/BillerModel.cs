namespace PaymentModule.Models
{
    public class BillerModel
    {
        public int transaction_id { get; set; }
        public string biller_name { get; set; }
        public int amount_to_pay { get; set;}
        public string transaction_type { get; set;}
        
    }
}
