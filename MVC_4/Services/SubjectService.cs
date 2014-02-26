using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MVC_4.Models;

namespace MVC_4.Services
{
    public class SubjectService //: ISubjectService
    {
        private readonly SubjectDataContext _subjectDataContext = new SubjectDataContext();

        public IList<Subject> GetAllSubjects()
        {
            return _subjectDataContext.Subjects.ToList();
        }

        public Subject GetSubject(int id)
        {
            var subject = _subjectDataContext.Subjects.Find(id);
            if (subject != null)
                return subject;
            throw new Exception("Subject not found");
        }

        public Subject AddSubject(Subject subject)
        {
            //db.Subjects.Find(subject.Id);//already exist
            var addedSubject = _subjectDataContext.Subjects.Add(subject);
            _subjectDataContext.SaveChanges();
            return addedSubject;
        }

        public Subject UpdateSubject(Subject subject)
        {
            _subjectDataContext.Entry(subject).State = EntityState.Modified;
            _subjectDataContext.SaveChanges();
            return subject;
        }

        public Subject DeleteSubject(int id)
        {
            var subject = _subjectDataContext.Subjects.Find(id);
            _subjectDataContext.Subjects.Remove(subject);
            _subjectDataContext.SaveChanges();
            return subject;
        }
    }
}