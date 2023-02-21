
namespace EasyJoin.ExampleDomain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsTutor { get; set; }

        public int? SupervisorId { get; set; }

        public Professor(int id, string name, string surname, bool isTutor, int? supervisorId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            IsTutor = isTutor;
            SupervisorId = supervisorId;
        }
    }
}
