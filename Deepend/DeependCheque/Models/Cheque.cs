using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DeependCheque.Models
{
    public class Cheque
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [RegularExpression(@"(\.\d{2}){1}$")]
        public double Amount { get; set; }

        public string Pay { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}