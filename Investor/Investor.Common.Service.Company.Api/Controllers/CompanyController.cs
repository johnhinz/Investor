﻿using System.Configuration;
using Investor.Common.Shared.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Investor.Common.Shared.Pocos;


namespace Investor.Common.Service.Company.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api.invest.com/companies")]
    public class CompanyController : ApiController
    {
        // GET: Company
        private ICompanyLogic _logic;

        public CompanyController(ICompanyLogic logic)
        {
            _logic = logic;
        }
/*------------------------HttpGet----------------------*/
        [HttpGet]
        [Route("{companyId}")]
        public HttpResponseMessage GetCompany(long companyId)
        {
            var company = _logic.ReadCompany(companyId);
            if (company == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, company);
        }

        [HttpGet]
        [Route("{companyId}/addresses")]
        public HttpResponseMessage GetAddresses(long companyId)
        {
            var addresses = _logic.ReadAddresses(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, addresses);
        }

        [HttpGet]
        [Route("{companyId}/phoneNumbers")]
        public HttpResponseMessage GetPhoneNumber(long companyId)
        {
            var phoneNumber = _logic.ReadPhoneNumber(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, phoneNumber);
        }

        /*------------------------HttpPut----------------------*/
        [HttpPut]
        [Route("")]
        public HttpResponseMessage UpdateCompany(CompanyPoco company)
        {
            var isUpdated = _logic.Update(company.Id, company);
            if (isUpdated == true)
                return Request.CreateResponse(HttpStatusCode.OK, company);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, company);

        }

        [HttpPut]
        [Route("{companyId}/addresses/{addressId}")]
        public HttpResponseMessage UpdateAddress(long companyId, [FromBody] CompanyAddressPoco address)
        {
            var isUpdated = _logic.UpdateAddress(companyId, address);
            if (isUpdated == true)
                return Request.CreateResponse(HttpStatusCode.OK, address);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, address);


        }

        [HttpPut]
        [Route("{companyId}/phoneNumbers/{phoneNumberId}")]
        public HttpResponseMessage UpdatePhoneNumber(long companyId, [FromBody] CompanyPhoneNumberPoco phoneNumber)
        {
            var isUpdated = _logic.UpdatePhoneNumber(companyId, phoneNumber);
            if (isUpdated == true)
                return Request.CreateResponse(HttpStatusCode.OK, phoneNumber);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified, phoneNumber);
            
        }

        /*------------------------HttpPost----------------------*/
        [HttpPost]
        [Route("")]
        public HttpResponseMessage CreateCompany([FromBody] CompanyPoco company)
        {
            var isAdded = _logic.Add(company);
            if (isAdded != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, isAdded);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
        }

        [HttpPost]
        [Route("{companyId}/phoneNumber")]
        public HttpResponseMessage CreatePhoneNumber(long companyId, [FromBody] CompanyPhoneNumberPoco phoneNumber)
        {
            _logic.CreatePhoneNumber(companyId, phoneNumber);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

      

        [HttpPost]
        [Route("{companyId}/addresses")]
        public HttpResponseMessage CreateAddress(long companyId, [FromBody] CompanyAddressPoco address)
        {
            _logic.CreateAddress(companyId, address);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

       

        /* [HttpGet]
         [Route("CompanyAddress/{companyId}")]
         public HttpResponseMessage GetCompanyAddress(long companyId)
         {
             var address = _logic.ReadAddress(companyId);
             if (address == null)
             {
                 return Request.CreateResponse(HttpStatusCode.NotFound);
             }
             return Request.CreateResponse(HttpStatusCode.OK, address);
         }
         */

        /*------------------------HttpDelete----------------------*/
      

        [HttpDelete]
        [Route("{CompanyId}")]
        public HttpResponseMessage DeleteCompany(long CompanyId)
        {
            var isDeleted = _logic.Delete(CompanyId);
            if (isDeleted == true)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.NotModified);

        }

        [HttpDelete]
        [Route("{companyId}/addresses/{addressId}")]
        public HttpResponseMessage DeleteAddress(long companyId, long addressId)
        {
            _logic.DeleteAddress(companyId, addressId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{companyId}/phoneNumber/{phoneNumberId}")]
        public HttpResponseMessage DeletePhoneNumber(long companyId, long phoneNumberId)
        {
            _logic.DeletePhoneNumber(companyId, phoneNumberId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}