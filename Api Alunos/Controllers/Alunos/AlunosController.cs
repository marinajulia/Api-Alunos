using Alunos.Domain.Service.Alunos;
using Alunos.Domain.Service.Alunos.Dto;
using Alunos.SharedKernel.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Api_Alunos.Controllers.Alunos
{
    [ApiController]
    [Route("api/alunos")]
    public class AlunosController : Controller
    {
        private readonly INotification _notification;
        private readonly IAlunosService _alunosService;
        
        public AlunosController(INotification notification, IAlunosService alunosService)
        {
            _notification = notification;
            _alunosService = alunosService;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            var alunos = _alunosService.Get();

            return Ok(alunos);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var aluno = _alunosService.GetById(id);
            if (aluno == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(aluno);
        }

        [HttpDelete("delete")]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            var response = _alunosService.Delete(id);

            if (!response)
                return BadRequest(_notification.GetNotifications());

            return Ok(_notification.GetNotifications());
        }

        [HttpGet("getbyName")]
        //[Authorize]
        public IActionResult GetByName(string name)
        {
            var response = _alunosService.GetByName(name);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(AlunosDto aluno)
        {
            var response = _alunosService.Post(aluno);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }
    }
}
