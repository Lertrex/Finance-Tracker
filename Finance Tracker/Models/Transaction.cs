using System;

namespace Finance_Tracker.Models
{
    class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Payee { get; set; }
        public decimal Amount { get; set; }
        public int Account { get; set; }
    }
}
