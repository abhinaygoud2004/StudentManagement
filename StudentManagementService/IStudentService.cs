using System;
using Common.Models;
namespace StudentManagementService
{
	public interface IStudentService
	{
        public Task<List<Student>> GiveMeAsStudent();
        public Task<List<Student>> GiveStudentsStartingWithA();
        public Task<List<Student>> GiveAllStudents();
        public Task<List<Student>> GiveStudentsWithAInTheirName();
        public Task<Student> GiveMeStudentById(int id);
        public Task<bool> AddStudent(Student student);
        public Task<bool> DeleteStudent(int id);
        public Task<bool> UpdateStudent(Student student);
    }
}

