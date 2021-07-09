using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        // GET: api/Photo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Photo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        private Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        public class Model
        {
            public string ImageString { get; set; }
        }
        // POST: api/Photo
        [HttpPost]
        public async Task<IActionResult> Post(Model model)
        {
            try
            {
                var value1 = model.ImageString;
                value1 = value1.Remove(0, 22);
                var image = Base64ToImage(value1);
                image.Save(@"c:\test.jpg");

                var bytes = Convert.FromBase64String(value1);

                PhotoData newPhoto = new PhotoData()
                {
                    Id = Guid.NewGuid(),
                    Photo = bytes.ToArray()
                };

                EmotionAnalysisController x = new EmotionAnalysisController();
                var thing = await x.AnalyseEmotion(newPhoto.Id, newPhoto.Photo);

                return NoContent();
            }
            catch (Exception e )
            {

                throw e;
            }
        }

        // PUT: api/Photo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class PhotoData
    {
        public Guid Id { get; set; }

        public byte[] Photo { get; set; }
    }
}
