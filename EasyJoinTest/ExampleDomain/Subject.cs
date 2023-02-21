namespace EasyJoin.ExampleDomain
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int? ProfessorId { get; set; }

        public Subject(int id, string name, int course, int? professorId)
        {
            Id = id;
            Name = name;
            Course = course;
            ProfessorId = professorId;
        }
    }
}
