using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // POST: api/Photo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string[] value)
        {
            var bytes = new List<byte>();

            foreach (var item in value)
            {
                string[] strings = item.Split(',');
                bytes.AddRange(strings.Select(s => byte.Parse(s)));
            }

            PhotoData newPhoto = new PhotoData()
            {
                Id = Guid.NewGuid(),
                Photo = bytes.ToArray()
            };

            EmotionAnalysisController x = new EmotionAnalysisController();
            var thing = await x.AnalyseEmotion(newPhoto.Id, newPhoto.Photo);

            return NoContent();
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
