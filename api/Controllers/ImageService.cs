using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.Models;

namespace api.Controllers
{
    public class ImageService
    {        
        public List<Image> FindAllImages()
        {
            using(var context = new DatabaseContext())
            {
                return context.Images.ToList();
            }
        }

        public Image findById(int imageId)
        {
            using (var context = new DatabaseContext())
            {
                return context.Images.ToList<Image>().Find(image => image.imageid.Equals(imageId));
            }
        }

    }
}