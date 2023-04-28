namespace PaymentModule.Models
{
    public class PaymentTableViewModel
    {
        public IEnumerable<AccountModel> AccountsViewModel { get; set; }
        public IEnumerable<BillersModel> BillersViewModel { get; set; }
        public IEnumerable<TransactionType> TransactionTypeViewModel { get; set; }
    }
}
