using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Helber;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace Company.Service.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;	

		public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public void Add(EmployeeDto employeeDto)
		{
			/*Employee employee = new Employee
			{
				Name = employeeDto.Name,
				PhoneNumber = employeeDto.PhoneNumber,
				Salary = employeeDto.Salary,
				Address = employeeDto.Address,
				Age = employeeDto.Age,
				DepartmentId = employeeDto.DepartmentId,
				Email = employeeDto.Email,
				HiringDate = employeeDto.HiringDate,
				ImageUrl = employeeDto.ImageUrl,

			};*/
			employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");

			Employee employee = _mapper.Map<Employee>(employeeDto);
			_unitOfWork.EmployeeRepository.Add(employee);
			_unitOfWork.Complete();

		}

		public void Delete(EmployeeDto employeeDto)
		{
			/*Employee employee = new Employee
			{
				Name = employeeDto.Name,
				PhoneNumber = employeeDto.PhoneNumber,
				Salary = employeeDto.Salary,
				Address = employeeDto.Address,
				Age = employeeDto.Age,
				DepartmentId = employeeDto.DepartmentId,
				Email = employeeDto.Email,
				HiringDate = employeeDto.HiringDate,
				ImageUrl = employeeDto.ImageUrl,

			};*/
			Employee employee = _mapper.Map<Employee>(employeeDto);

			_unitOfWork.EmployeeRepository.Delete(employee);
			_unitOfWork.Complete();
		}

		public IEnumerable<EmployeeDto> GetAll()
		{
			var employees = _unitOfWork.EmployeeRepository.GetAll();

			/*var mappedEmployees = employees.Select(x => new EmployeeDto
			{
				DepartmentId = x.DepartmentId,
				Name = x.Name,
				PhoneNumber = x.PhoneNumber,
				Salary = x.Salary,
				Address = x.Address,
				Age = x.Age,
				Email = x.Email,
				HiringDate = x.HiringDate,
				ImageUrl = x.ImageUrl,
				CretaAt = x.CreateAt,
				Id = x.Id

			});*/

			IEnumerable<EmployeeDto> mappedemployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

			return mappedemployees;
		}

		public EmployeeDto GetById(int? id)
		{
			if (id is null)
				return null;


			var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

			if (employee is null)
				return null;
			/*EmployeeDto employeeDto = new EmployeeDto
			{
				Name = employee.Name,
				PhoneNumber = employee.PhoneNumber,
				Salary = employee.Salary,
				Address = employee.Address,
				Age = employee.Age,
				DepartmentId = employee.DepartmentId,
				Email = employee.Email,
				HiringDate = employee.HiringDate,
				ImageUrl = employee.ImageUrl,
				Id = employee.Id,
				CretaAt= employee.CreateAt

			};*/

			EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);



			return employeeDto;
		}
		public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
		{ 
			var employees =  _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
			/*var mappedEmployees = employees.Select(x => new EmployeeDto
			{
				DepartmentId = x.DepartmentId,
				Name = x.Name,
				PhoneNumber = x.PhoneNumber,
				Salary = x.Salary,
				Address = x.Address,
				Age = x.Age,
				Email = x.Email,
				HiringDate = x.HiringDate,
				ImageUrl = x.ImageUrl,
				CretaAt = x.CreateAt,
				Id = x.Id

			});*/

			IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

			return mappedEmployees;

		}

		public void Update(EmployeeDto employee)
		{

			//_unitOfWork.EmployeeRepository.Update(employee);
			_unitOfWork.Complete();

		}
	}
}