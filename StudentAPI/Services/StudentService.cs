using StudentAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace StudentAPI.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _Students;

        public StudentService(IStudentDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }

        public List<Student> Get() =>
            _Students.Find(Student => true).ToList();

        public Student Get(string id) =>
            _Students.Find<Student>(Student => Student.Id == id).FirstOrDefault();

        public Student Create(Student Student)
        {
            _Students.InsertOne(Student);
            return Student;
        }

        public void Update(string id, Student StudentIn) =>
            _Students.ReplaceOne(Student => Student.Id == id, StudentIn);

        public void Remove(Student StudentIn) =>
            _Students.DeleteOne(Student => Student.Id == StudentIn.Id);

        public void Remove(string id) =>
            _Students.DeleteOne(Student => Student.Id == id);
    }
}