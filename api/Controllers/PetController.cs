using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api.Models;

namespace api.Controllers
{
    public class PetController : ApiController
    {
        private ImageService imageService = new ImageService();

        public IHttpActionResult GetPet()
        {
            int max = 13;
            Random rnd = new Random();
            int imageId = rnd.Next(1, max+1);
            Image image = imageService.findById(imageId);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }
    }
}