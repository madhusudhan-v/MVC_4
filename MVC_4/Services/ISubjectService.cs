using System.Collections.Generic;
using MVC_4.Models;

namespace MVC_4.Services
{
    interface ISubjectService
    {
        IList<Subject> GetAllSubjects();
        Subject GetSubject(int id);
        Subject AddSubject(Subject student);
        Subject UpdateSubject(Subject student);
        Subject DeleteSubject(int id);
    }
}
