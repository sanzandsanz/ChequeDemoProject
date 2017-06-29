using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using DeependCheque.Models;

namespace DeependCheque.Controllers
{
    public class ChequeController : Controller
    {

        /// <summary>
        ///  Get all the cheques
        /// </summary>
        /// <returns>All cheques </returns>
        [HttpGet]
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];
                client.BaseAddress = new Uri(baseAddress);

                HttpResponseMessage response = client.GetAsync("api/chequeservice").Result;
                if (!response.IsSuccessStatusCode) // ? Error exist 
                {
                    var errorMesage = string.Format("Error Status Code: {0}, Error Message: {1}", (int)response.StatusCode,
                                                                                       response.Content.ReadAsStringAsync().Result);
                    throw new Exception(errorMesage);
                }

                var cheques = response.Content.ReadAsAsync<List<Cheque>>().Result;
                cheques = cheques.OrderByDescending(i => i.Date).ToList();

                return this.View(cheques);
            }
        }


        /// <summary>
        /// Get the check details 
        /// </summary>
        /// <param name="id">Cheque Id</param>
        /// <returns>Cheque Details</returns>
        [HttpGet]
        public ActionResult GetCheckDetails(int id)
        {
            using (var client = new HttpClient())
            {
                string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];
                client.BaseAddress = new Uri(baseAddress);

                HttpResponseMessage response = client.GetAsync(string.Format("api/GetCheque/{0}", id)).Result;
                if (!response.IsSuccessStatusCode) // Error Exist 
                {
                    var errorMesage = string.Format("Error Status Code: {0}, Error Message: {1}", (int)response.StatusCode,
                                                                                     response.Content.ReadAsStringAsync().Result);
                    throw new Exception(errorMesage);
                }

                var cheque = response.Content.ReadAsAsync<Cheque>().Result;
                return this.View("Details", cheque);
            }
        }
    }
}