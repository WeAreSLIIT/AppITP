using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CustomerController()
        {
            _unitOfWork = new UnitOfWork();       
        }
        


    }
}
