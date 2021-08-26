using Alunos.Domain.Service.MateriaProfessores;
using Alunos.Domain.Service.MateriaProfessores.Dto;
using Alunos.SharedKernel.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Api_Alunos.Controllers.MateriaProfessores
{
    [ApiController]
    [Route("api/materiaprofessores")]
    public class MateriaProfessoresController : Controller
    {
        private readonly INotification _notification;
        private readonly IMateriaProfessoresService _materiaProfessoresService;

        public MateriaProfessoresController(INotification notification, IMateriaProfessoresService materiaProfessoresService)
        {
            _notification = notification;
            _materiaProfessoresService = materiaProfessoresService;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            var materiaProfessores = _materiaProfessoresService.Get();

            return Ok(materiaProfessores);
        }

        [HttpGet("findbyid")]
        //[Authorize]
        public IActionResult GetById(int id)
        {
            var materiaProfessor = _materiaProfessoresService.GetById(id);
            if (materiaProfessor == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(materiaProfessor);
        }

        [HttpGet("materiasdeumprofessor")]
        //[Authorize]
        public IActionResult GetByMateriasDeUmProfessor(int idProfessor)
        {
            var materiaProfessores = _materiaProfessoresService.GetMateriasDoProfessor(idProfessor);
            if (materiaProfessores == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(materiaProfessores);
        }

        [HttpDelete("delete")]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            var response = _materiaProfessoresService.Delete(id);

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
        public IActionResult Post(MateriaProfessoresDto professor)
        {
            var response = _materiaProfessoresService.Post(professor);

            if (response == null)
                return BadRequest(_notification.GetNotifications());

            return Ok(response);
        }
    }
}

