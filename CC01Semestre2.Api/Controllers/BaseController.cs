using CC01Semestre2.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC01Semestre2.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected CC01Entities db = new CC01Entities();
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
