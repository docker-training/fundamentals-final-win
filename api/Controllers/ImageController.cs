using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api.Models;

namespace api.Controllers
{
    public class ImagesController : ApiController
    {
        private ImageService imageService = new ImageService();

        public IHttpActionResult GetAllImages()
        {
            List<Image> images = imageService.FindAllImages();
            if (images.Count == 0)
            {
                return NotFound();
            }
            return Ok(images);
        }

        public IHttpActionResult GetImage(int id)
        {
            var image = imageService.findById(id);
            if(image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

    }
}
