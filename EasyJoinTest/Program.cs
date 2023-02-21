using EasyJoin.ExampleDomain;
using System.Collections.Generic;
using System.Linq;

namespace EasyJoin
{
    class Program
    {
        static void WriteJoinResultProfessorSubject(IEnumerable<JoinResult<Professor, Subject>> results)
        {
            foreach (JoinResult<Professor, Subject> result in results)
            {
                System.Console.WriteLine("{0} {1} {2} {3}   {4} {5} {6} {7}", result.A?.Id, result.A?.Name, result.A?.Surname, result.A?.IsTutor, result.A?.SupervisorId, result.B?.Id, result.B?.Name, result.B?.Course, result.B?.ProfessorId);
            }
        }

        static void WriteJoinResultProfessor(IEnumerable<JoinResult<Professor, Professor>> results)
        {
            foreach (JoinResult<Professor, Professor> result in results)
            {
                System.Console.WriteLine("{0} {1} {2} {3} {4} | {5} {6} {7} {8} {9}", result.A?.Id, result.A?.Name, result.A?.Surname, result.A?.IsTutor, result.A?.SupervisorId, result.B?.Id, result.B?.Name, result.B?.Surname, result.B?.IsTutor, result.B?.SupervisorId);
            }
        }

        static void Main(string[] args)
        {
            List<Professor> professors = new List<Professor>();
            List<Subject> subjects = new List<Subject>();

            professors.Add(new Professor(1, "Prof1", "Essor1", true, 2));
            professors.Add(new Professor(2, "Prof2", "Essor2", false, 3));
            professors.Add(new Professor(3, "Prof3", "Essor3", true, null));
            professors.Add(new Professor(4, "Prof4", "Essor4", false, null));
            professors.Add(new Professor(5, "Prof5", "Essor5", true, 4));

            subjects.Add(new Subject(1, "Subject1", 1, 3));            
            subjects.Add(new Subject(2, "Subject2", 2, 1));
            subjects.Add(new Subject(3, "Subject3", 3, null));
            subjects.Add(new Subject(4, "Subject4", 4, 4));
            subjects.Add(new Subject(5, "Subject5", 5, null));

            //InnerJoin
            var query1 = professors.InnerJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();
            WriteJoinResultProfessorSubject(query1);
            
            //LeftJoin
            var query2 = professors.LeftJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();
            WriteJoinResultProfessorSubject(query2);
            
            //RightJoin
            var query3 = professors.RightJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();
            WriteJoinResultProfessorSubject(query3);

            //FullJoin
            var query4 = professors.FullJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();
            WriteJoinResultProfessorSubject(query4);

            //CrossJoin
            var query5 = professors.CrossJoin(subjects).ToList();
            WriteJoinResultProfessorSubject(query5);

            //SelfJoin
            var query6 = professors.SelfJoin(p1 => p1.Id, p2 => p2.SupervisorId).ToList();
            WriteJoinResultProfessor(query6);
            
            System.Console.ReadKey();
        }
    }
}
