using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Requests.Put
{
    public class UpdateImageModel
    {
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}
