using Investor.Common.Shared.DataTransferObjects;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Investor.MVC.Controllers
{
    public class InvestmentController : Controller
    {
        // GET: Investment
        public ActionResult Index()
        {
            return View();
        }

        public InvestmentDto GetInvestment(string id)
        {
            InvestmentDto investment = new InvestmentDto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51285/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"api.invest.com/investments/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    investment = JsonConvert.DeserializeObject<InvestmentDto>(
                        response.Content.ReadAsStringAsync().Result);
                }
            }
            return investment;
        }

        public ActionResult Search(string SearchBox)
        {

            //if (string.IsNullOrWhiteSpace(SearchBox))
            //{
                return View("GetInvestment", GetInvestment(SearchBox));
            //}
            //else
            //{
            //    return GetInvestment(SearchBox);
            //}

            
        }


    }
}