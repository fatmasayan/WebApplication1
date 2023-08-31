using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        List<Values> list = new List<Values>();

        public DenemeController()
        {
            for (int i = 0; i < 50; i++)
            {
                list.Add(new Values
                {
                    Id = i,
                    Value = $"Example {i}",
                    Date = DateTime.Now.AddDays(-50 + i).ToString("dddd/MMM/yyyy HH:mm:ss")
                });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(list);
        }

        [HttpGet("GetSingle/{id}")]
        public IActionResult GetSingle(int id)
        {
            var result = list.FirstOrDefault(x => x.Id == id);

            return Ok(result);
        }

        [HttpPost("AddValues")]
        public IActionResult AddValues(Values values) 
        {
            list.Add(values);

            return Ok(list);
        }

        [HttpPost("UpdateValues/{id}")]
        public IActionResult UpdateValues(Values values, int id) 
        {
            foreach (Values item in list)
            {
                if (item is not null)
                {
                    if (item.Id == id)
                    {
                        item.Value = values.Value;
                        item.Date = DateTime.Now.ToString("dddd/MMM/yyyy HH:mm:ss");

                        break;
                    }
                }
            }

            return Ok(list);
        }

        [HttpDelete("DeleteValues/{id}")]
        public IActionResult DeleteValues(int id)
        {
            list.Remove(list.First(x => x.Id == id));

            return Ok(new
            {
                Message="aferin",
                Data = list
            });
        }
        
    }
}
