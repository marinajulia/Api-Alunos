using Alunos.Domain.Service.MateriaAlunos;
using Alunos.Domain.Service.MateriaAlunos.Dto;
using Alunos.SharedKernel.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Api_Alunos.Controllers.MateriaAlunos
{
    [ApiController]
    [Route("api/materiaalunos")]
    public class MateriaAlunosController : Controller
    {
        private readonly INotification _notification;
        private readonly IMateriaAlunosService _materiaAlunosService;

        public MateriaAlunosController(INotification notification, IMateriaAlunosService materiaAlunosService)
        {
            _notification = notification;
            _materiaAlunosService = materiaAlunosService;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            var materiaAlunos = _materiaAlunosService.Get();

            return Ok(materiaAlunos);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var materiaAluno = _materiaAlunosService.GetById(id);
            if (materiaAluno == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(materiaAluno);
        }

        [HttpGet("alunosdamateria")]
        //[Authorize]
        public IActionResult GetByAlunosDeUmaMateria(int idMateria)
        {
            var materiaAluno = _materiaAlunosService.GetAlunosdaMateria(idMateria);
            if (materiaAluno == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(materiaAluno);
        }

        [HttpGet("materiasdoaluno")]
        //[Authorize]
        public IActionResult GetByMAteriasDeUmAluno(int idAluno)
        {
            var materiaAluno = _materiaAlunosService.GetAlunosdaMateria(idAluno);
            if (materiaAluno == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(materiaAluno);
        }

        [HttpDelete("delete")]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            var response = _materiaAlunosService.Delete(id);

            if (!response)
                return BadRequest(_notification.GetNotifications());

            return Ok(_notification.GetNotifications());
        }

        //[HttpGet("getbyName")]
        ////[Authorize]
        //public IActionResult GetByName(string name)
        //{
        //    var response = _materiaAlunosService.GetByName(name);

        //    if (response == null)
        //        return BadRequest(_notification.GetNotifications());

        //    return Ok(response);
        //}

        [HttpPost]
        public IActionResult Post(MateriaAlunosDto aluno)
        {
            var response = _materiaAlunosService.Post(aluno);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }
    }
}

