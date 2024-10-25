
using Company.Data.Models;
using Company.Service.Interfaces.Department.Dto;

namespace Company.Service.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int? id);

        IEnumerable<DepartmentDto> GetAll();

        void Add(DepartmentDto entity);

        void Update(DepartmentDto entity);

        void Delete(DepartmentDto entity);
    }
}
