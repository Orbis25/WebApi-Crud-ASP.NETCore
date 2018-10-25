using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.IService;

namespace Api_Crud.Controllers
{
    [Produces("application/json")]
    [Route("/students")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _studentService.GetAll()
                );
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(
                _studentService.Get(id));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Student model)
        {
            return Ok(_studentService.Add(model));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody]Student model)
        {
           return Ok(
                _studentService.Update(model));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           return Ok(
                _studentService.Delete(id));
        }
    }
}
