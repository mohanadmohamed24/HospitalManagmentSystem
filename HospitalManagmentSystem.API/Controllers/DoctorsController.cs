using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.BLL.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorManager _doctorManager;

        public DoctorsController(IDoctorManager doctorManager)
        {
            _doctorManager = doctorManager;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDto>> GetAll()
        {
            return Ok(_doctorManager.GetAll());
        }
        [HttpGet]
        [Route("{Id}")]
        public ActionResult GetById(int Id )
        {
            return Ok(_doctorManager.GetById(Id));
        }
        [HttpPost]
        public ActionResult Add(DoctorAddDto doctorAddDto)
        {
            _doctorManager.Add(doctorAddDto);
            return NoContent();
        }
        [HttpPut]
        [Route("{Id}")]
        public ActionResult Update(int Id, DoctorUpdateDto doctorUpdateDto)
        {
            if(Id != doctorUpdateDto.Id)
            {
                return BadRequest();
            }
            _doctorManager.Update(doctorUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        [Route("{Id}")]
        public ActionResult Delete(int Id)
        {
            _doctorManager.Delete(Id);
            return NoContent();
        }
    }
}
