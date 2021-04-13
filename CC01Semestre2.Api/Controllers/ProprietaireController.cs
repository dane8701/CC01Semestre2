using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC01Semestre2.Api.Controllers
{
    public class ProprietaireController : BaseController
    {
        [HttpGet]
        public IHttpActionResult ListerProprietaire(int index = 0, int taille = 10)
        {
            try
            {
                var proprietaires = db.Proprietaires
                    .OrderByDescending(x => x.DateCreation)
                    .Skip(index * taille).Take(taille).ToList();
                return Ok(proprietaires);
            }
            catch (DbUpdateException ex)
            {
                var exception = ex.InnerException?.InnerException as SqlException;
                return BadRequest(exception?.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult DetailsProprietaire(int id)
        {
            try
            {
                var proprietaire = db.Proprietaires.Find(id);
                return Ok(proprietaire);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
