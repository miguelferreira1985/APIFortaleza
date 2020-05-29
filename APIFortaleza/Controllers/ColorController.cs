using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository;
using Entities;
using System.Web.WebPages;


namespace APIFortaleza.Controllers
{
    [RoutePrefix("api/color")]
    public class ColorController : ApiController
    {
        ColorRepository colorRepository;

        [Route("GetActiveColors")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetActivePresentations()
        {
            colorRepository = new ColorRepository();

            List<Color> colors = new List<Color>();

            colors = colorRepository.getActiveColor();

            if (colors.Count == 0)
            {
                return NotFound();
            }

            return Ok(colors);


        }

        [Route("UpdateColor")]
        [Authorize]
        [HttpPut]
        public IHttpActionResult UpdateColor(Color color)
        {
            colorRepository = new ColorRepository();

            if ( color.Name.IsEmpty() || color.ColorID.Equals(0) )
            {
                return BadRequest("Falta el id o el nombre en el request.");
            }

            if (!colorRepository.updateColor(color) )
            {
                return NotFound();
            }
            else
            {
                return Ok(color);
            }            
        }

        [Route("DeleteColor")]
        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            colorRepository = new ColorRepository();

            if ( id.Equals(0) )
            {
                return BadRequest("Falta el id o el nombre en el request.");
            }

            if (!colorRepository.deleteColor(id))
            {
                return NotFound();
            }
            else
            {
                return Ok(id);
            }
        }
    }
}
