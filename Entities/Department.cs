using System;

namespace course_lecture.Entities
{
    public class Department
    {
        public string Name { get; set; }
        public Department()
        {
        }
        public Department(string name)
        {
            Name = name;
        }
    }
}