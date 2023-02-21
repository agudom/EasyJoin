# EasyJoin (an easy way to do joins in C#)

## General Syntax:

IEnumerableA.[DesiredJoin](IEnumerableB, OnClauseForA, OnClauseForB);


## Examples:

//InnerJoin

var query1 = professors.InnerJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();


//LeftJoin

var query2 = professors.LeftJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();


//RightJoin

var query3 = professors.RightJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();


//FullJoin

var query4 = professors.FullJoin(subjects, p => p.Id, s => s.ProfessorId).ToList();


//CrossJoin

var query5 = professors.CrossJoin(subjects).ToList();


//SelfJoin

var query6 = professors.SelfJoin(p1 => p1.Id, p2 => p2.SupervisorId).ToList();


### This Repository includes a Visual Studio solution with EasyJoin DLL and an console project with tests.
