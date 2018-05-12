using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Image
    {
        [Key]
        public int imageid { get; set; }
        public String url { get; set; }
        public String description { get; set; }

        public Image() { }

        public Image(int imageid, String url, String decsription, double price, String image)
        {
            this.imageid = imageid;
            this.url = url;
            this.description = description;
        }

        public override string ToString()
        {
            return "Image [imageId=" + this.imageid +
                            ", url=" + this.url +
                            ", description=" + this.description +
                            "]";
        }

    }
}