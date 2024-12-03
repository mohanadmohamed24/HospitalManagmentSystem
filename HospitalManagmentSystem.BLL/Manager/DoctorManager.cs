using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.DAL.Data.Models;
using HospitalManagmentSystem.DAL.Repositories;

namespace HospitalManagmentSystem.BLL.Manager
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepo _doctorRepo;
        public DoctorManager(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }
        public IEnumerable<DoctorReadDto> GetAll()
        {
            var DoctorModelList = _doctorRepo.GetAll();

            var DoctorDtoList = DoctorModelList.Select(x => new DoctorReadDto()
            {
                Age = x.Age,
                Name = x.Name,
                PerformanceRate=x.PerformanceRate,
            });

            return DoctorDtoList;
        }
        public DoctorReadDto GetById(int id)
        {
            var DoctorModel = _doctorRepo.GetById(id);

            var DoctorDto = new DoctorReadDto()
            {
                Age= DoctorModel.Age,
                Name = DoctorModel.Name,
                PerformanceRate=DoctorModel.PerformanceRate
            };

            return DoctorDto;
        }
        public void Add(DoctorAddDto doctorAddDto)
        {
            var doctorModel = new Doctor
            {
                Name = doctorAddDto.Name,
                Age = doctorAddDto.Age,
                Salary = doctorAddDto.Salary,
            };

            _doctorRepo.Add(doctorModel);
            _doctorRepo.SaveChange();

        }
        public void Delete(int id)
        {
            var doctorModel= _doctorRepo.GetById(id);
            _doctorRepo.Delete(doctorModel);
            _doctorRepo.SaveChange();

        }
        public void Update(DoctorUpdateDto doctorUpdateDto)
        {
            var doctorModel = _doctorRepo.GetById(doctorUpdateDto.Id);
           
            doctorModel.Salary= doctorUpdateDto.Salary;
            doctorModel.Name= doctorUpdateDto.Name;
            doctorModel.Age=doctorUpdateDto.Age;
            doctorModel.PerformanceRate= doctorUpdateDto.PerformanceRate;
           
            _doctorRepo.Update(doctorModel);
            _doctorRepo.SaveChange();
        }
        public void SaveChange()
        {
            _doctorRepo.SaveChange();
        }
    }
}
