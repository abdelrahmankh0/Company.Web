﻿

using Azure.Core.Pipeline;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
		private readonly IUnitOfWork _unitOfWork;

		public DepartmentService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

        public void Add(Department department)
        {
            var mappedDepartment = new Department
            {
                Code = department.Code,
                Name = department.Name,
                CreateAt = DateTime.Now
            };
            _unitOfWork.departmentRepository.Add(mappedDepartment);

            _unitOfWork.Complete();

		}

		public void Delete(Department department)
        {
            _unitOfWork.departmentRepository.Delete(department);
            _unitOfWork.Complete();
        }

        public IEnumerable<Department> GetAll()
        {
            var Department = _unitOfWork.departmentRepository.GetAll();
            return Department;
        }

        public Department GetById(int? id)
        {
            if (id is null)
                return null;


            var department = _unitOfWork.departmentRepository.GetById(id.Value);

            if (department is null)
                return null;

            return department;
        }

        public void Update(Department department)
        {
         
           _unitOfWork.departmentRepository.Update(department);
            _unitOfWork.Complete();

        }
    }
}
