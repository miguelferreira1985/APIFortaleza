using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Repository;

namespace APIFortaleza.Controllers
{
    [Route("api/presentation/GetActivePresentations")]
    [Authorize]
    public class PresentationController : ApiController
    {
        PresentationRepository presentationRepository;
        public IHttpActionResult GetActivePresentations()
        {
            presentationRepository = new PresentationRepository();

            List<Presentation> presentations = new List<Presentation>();

            presentations = presentationRepository.getActivePresentation();

            if ( presentations.Count == 0)
            {
                return NotFound();
            }

            return Ok(presentations);


        }
    }
}
