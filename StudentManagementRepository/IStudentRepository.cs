using System;
using Common.Models;
namespace StudentManagementRepository
{
	public interface IStudentRepository
	{
        public Task<List<Student>> GiveAllStudents();
        public Task<List<Student>> GiveStudentName();
        public Task<bool> AddStudent(Student student);
        public Task<bool> DeleteStudent(int id);
        public Task<bool> UpdateStudent(Student student);
    }
}