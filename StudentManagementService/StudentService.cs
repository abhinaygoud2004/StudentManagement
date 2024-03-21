using System;
using SQLRepository;
using Common.Models;
using StudentManagementRepository;
namespace StudentManagementService
{
	public class StudentService:IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		public async Task<List<Student>> GiveMeAsStudent()
		{
			return await _studentRepository.GiveStudentName();
		}
		public async Task<List<Student>> GiveAllStudents()
		{
			return await _studentRepository.GiveAllStudents();
		}
        public async Task<Student> GiveMeStudentById(int id)
        {
            List<Student> allStudents = await _studentRepository.GiveAllStudents();
            Student student = allStudents.FirstOrDefault(s => s.roll_no == id);

            return student ?? new Student(); 
        }

        public async Task<bool> AddStudent(Student student)
		{
			return await _studentRepository.AddStudent(student);
		}

		public async Task<bool> DeleteStudent(int id)
		{
			return await _studentRepository.DeleteStudent(id);
		}

		public async Task<bool>UpdateStudent(Student student)
		{
			return await _studentRepository.UpdateStudent(student);
		}

		public async Task<List<Student>> GiveStudentsStartingWithA()
		{
            //StudentRepository studentRepository = new StudentRepository();
            List<Student> allStudents = await _studentRepository.GiveAllStudents();
            List<Student> studentsWithStartingA = new List<Student>();
			//         for (int i = 0; i < allStudents.Length; i++)
			//{
			//	if (allStudents[i][0] == 'A')
			//	{
			//		studentsWithStartingA.Add(allStudents[i]);
			//	}
			//}
			//return studentsWithStartingA;
			return allStudents;
		}
		public async Task<List<Student>> GiveStudentsWithAInTheirName()
		{
            //StudentRepository studentRepository = new StudentRepository();
            List<Student> allStudents = await _studentRepository.GiveAllStudents();
            List<Student> studentsWithA = new List<Student>();
			//         for (int i=0;i<allStudents.Length;i++)
			//{
			//	for(int j = 0; j < allStudents[i].Length; j++)
			//	{
			//		if (allStudents[i][j] == 'A')
			//		{
			//			studentsWithA.Add(allStudents[i]);
			//			break;

			//                 }
			//	}
			//}
			//return studentsWithA;
			return allStudents;
        }
	}
}

