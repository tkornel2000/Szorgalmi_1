﻿namespace Academy_2023.Data
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public User? Author { get; set; }
    }
}