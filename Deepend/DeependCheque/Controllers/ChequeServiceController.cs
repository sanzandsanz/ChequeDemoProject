using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DeependCheque.Models;

namespace DeependCheque.Controllers
{
    public class ChequeServiceController : ApiController
    {

        private readonly List<Cheque> _cheques = new List<Cheque>()
        {
            new Cheque { Id = 1, Name = "John Smith", Date = new DateTime(2015,10, 1), Amount = 1217.05f, Pay = "ONE THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND FIVE CENTS"},
            new Cheque { Id = 2, Name = "Sanz Bajra", Date = new DateTime(2016,10, 1), Amount = 2217.05f, Pay = "TWO THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND FIVE CENTS"},
            new Cheque { Id = 3, Name = "Jacky Chain", Date = new DateTime(2017,10, 1), Amount = 5217.75f, Pay = "FIVE THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND SEVENTY FIVE CENTS"},
            new Cheque { Id = 4, Name = "Leo Messi", Date = new DateTime(2005,10, 1), Amount = 1217.06f, Pay = "ONE THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND SIX CENTS"},
            new Cheque { Id = 5, Name = "Gerrad Pique", Date = new DateTime(2005,12, 1), Amount = 1217.05f, Pay = "ONE THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND FIVE CENTS"},
            new Cheque { Id = 6, Name = "Xavi Alonso", Date = new DateTime(2001,10, 1), Amount = 1217.05f, Pay = "ONE THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND FIVE CENTS"},
            new Cheque { Id = 7, Name = "Christian Ronaldo", Date = new DateTime(2015,10, 1), Amount = 3217.05f, Pay = "THREE THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND FIVE CENTS"},
            new Cheque { Id = 8, Name = "Wayne Rooney", Date = new DateTime(2015,10, 1), Amount = 1217.05f, Pay = "ONE THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND FIVE CENTS"},
            new Cheque { Id = 9, Name = "Alexis Sanchez", Date = new DateTime(2013,11, 1), Amount = 8217.02f, Pay = "EIGHT THOUSAND TWO HOUNDRED SEVENTEEN DOLLARS AND TWO CENTS"},
            new Cheque { Id = 10, Name = "Arsenal Wenger", Date = new DateTime(2011,2, 1), Amount = 117.15f, Pay = "ONE HOUNDRED SEVENTEEN DOLLARS AND FIVETEEN CENTS"},
        };


        [HttpGet]
        public IEnumerable<Cheque> GetCheques()
        {
            return _cheques;
        }



        [HttpGet]
        [Route("api/GetCheque/{id}")]
        public Cheque GetCheque(int id)
        {
            return _cheques.SingleOrDefault(i => i.Id == id);
        }
    }
}
