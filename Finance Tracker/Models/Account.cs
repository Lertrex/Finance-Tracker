namespace Finance_Tracker.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public int IsChoose { get; set; }
    }
}
