using Alunos.Domain.Service.Materias;
using Alunos.Domain.Service.Materias.Dto;
using Alunos.SharedKernel.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Api_Alunos.Controllers.Materias
{
    [ApiController]
    [Route("api/materias")]
    public class MateriasController : Controller
    {
        private readonly INotification _notification;
        private readonly IMateriasService _materiasService;

        public MateriasController(INotification notification, IMateriasService materiasService)
        {
            _notification = notification;
            _materiasService = materiasService;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            var materias = _materiasService.Get();

            return Ok(materias);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var materia = _materiasService.GetById(id);
            if (materia == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(materia);
        }

        [HttpDelete("delete")]
        //[Authorize]
        public IActionResult Delete(int materia)
        {
            var response = _materiasService.Delete(materia);

            if (!response)
                return BadRequest(_notification.GetNotifications());

            return Ok(_notification.GetNotifications());
        }

        [HttpGet("getbyName")]
        //[Authorize]
        public IActionResult GetByName(string name)
        {
            var response = _materiasService.GetByName(name);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(MateriasDto materia)
        {
            var response = _materiasService.Post(materia);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }
    }
}
