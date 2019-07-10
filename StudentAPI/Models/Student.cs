using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace StudentAPI.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Subjects")]
        public List<Subject> SubjectsEnrolled { get; set; }

    }

    public class Subject
    {
        [BsonElement("SubjectName")]
        public string SubjectName { get; set; }

        [BsonElement("StudentGrade")]
        public string StudentGrade { get; set; }

        [BsonElement("GPA")]
        public double GPA { get; set; }

    }
}
