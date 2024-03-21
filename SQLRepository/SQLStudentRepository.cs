using System;
using StudentManagementRepository;
using Common.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace SQLRepository
{
	public class SQLStudentRepository : IStudentRepository
	{
		private readonly IDbConnection _connection;
		public SQLStudentRepository(IDbConnection connection)
		{
			_connection = connection;
		}
        public async Task<bool> AddStudent(Student NewStudent)
        {
            try
            {
                _connection.Open();
                string query = "INSERT INTO student (sid, sname, gender) VALUES (@SID,@Name, @Gender)";
                SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
                command.Parameters.AddWithValue("@SID", NewStudent.roll_no);
                command.Parameters.AddWithValue("@Name", NewStudent.name);
                command.Parameters.AddWithValue("@Gender", NewStudent.gender);
                //command.Parameters.AddWithValue("@Sno", NewStudent.sno);
                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getallstudents: {ex.Message}");
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return false;

        }

        public async Task<bool> DeleteStudent(int id)
        {
            try
            {
                _connection.Open();
                string query = "DELETE FROM student where sid=@SID";
                SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
                command.Parameters.AddWithValue("@SID", id);
                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in delete student with id: {ex.Message}");
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return false;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            try
            {
                _connection.Open();
                string query = "UPDATE student SET sname=@Name,gender=@Gender where sid=@SID";
                SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
                command.Parameters.AddWithValue("@Name", student.name);
                command.Parameters.AddWithValue("@Gender", student.gender);
                command.Parameters.AddWithValue("@SID", student.roll_no);
                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getallstudents: {ex.Message}");
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return false;
        }


        public async Task<List<Student>> GiveStudentName()
		{
            List<Student> students = new List<Student>();
            try
            {
                _connection.Open();
                string query = "SELECT sid,sname,gender From student";
                SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Student student = new Student()
                        {
                            roll_no = Convert.ToInt32(reader["sid"]),
                            name = Convert.ToString(reader["sname"])
                        };
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in getallstudents: {ex.Message}");
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return students;
        }
        public async Task< List<Student>> GiveAllStudents()
		{
			List<Student> students = new List<Student>();
			_connection.Open();
			string query = "SELECT sid,sname,gender From student";
			SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
			using (SqlDataReader reader =await command.ExecuteReaderAsync())
			{
				while (await reader.ReadAsync())
				{
					Student student = new Student()
					{
						roll_no = Convert.ToInt32(reader["sid"]),
						name = Convert.ToString(reader["sname"])
					};
					students.Add(student);
				}
			}
				return students;
		}
	}
}