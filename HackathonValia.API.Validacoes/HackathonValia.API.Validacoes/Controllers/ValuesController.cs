using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackathonValia.API.Validacoes.Models;

namespace HackathonValia.API.Validacoes.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version}/[controller]")]
    [ApiController]
    public class LineRules : ControllerBase
    {
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //
        [HttpPost]
        public IActionResult Post([FromBody] EmpregadoModel empregado)
        {
            return Ok(empregado);
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
