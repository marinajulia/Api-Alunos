using Alunos.Domain.Service.Professores;
using Alunos.Domain.Service.Professores.Dto;
using Alunos.SharedKernel.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Api_Alunos.Controllers.Professores
{
    [ApiController]
    [Route("api/professor")]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessoresService _professoresService;
        private readonly INotification _notification;

        public ProfessoresController(IProfessoresService professoresService, INotification notification)
        {
            _professoresService = professoresService;
            _notification = notification;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            var professores = _professoresService.Get();

            return Ok(professores);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var professor = _professoresService.GetById(id);
            if (professor == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(professor);
        }

        [HttpDelete("delete")]
        //[Authorize]
        public IActionResult Delete(int professor)
        {
            var response = _professoresService.Delete(professor);

            if (!response)
                return BadRequest(_notification.GetNotifications());

            return Ok(_notification.GetNotifications());
        }

        [HttpGet("getbyName")]
        //[Authorize]
        public IActionResult GetByName(string name)
        {
            var response = _professoresService.GetByName(name);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(ProfessoresDto professor)
        {
            var response = _professoresService.Post(professor);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }
    }
}
