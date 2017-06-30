using System;
using System.ComponentModel.DataAnnotations;

namespace DeependCheque.Models
{
    public class ChequeDetailsViewModel 
    {

        public ChequeDetailsViewModel(Cheque cheque)
        {
            this.Name = cheque.Name;
            this.Amount = cheque.Amount;
            this.Date = cheque.Date;
        }


        public string Pay { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}