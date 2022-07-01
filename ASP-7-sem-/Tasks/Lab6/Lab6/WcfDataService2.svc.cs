//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;
using System.Linq;
using System.ServiceModel.Web;

namespace Lab6
{
    public class WcfDataService2 : EntityFrameworkDataService<lab6Entities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead
                | EntitySetRights.WriteMerge
                | EntitySetRights.WriteReplace
                | EntitySetRights.AllWrite
                | EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }


        [WebGet]
        public IQueryable<Note> ChangeNote(int id, String subject, int Note, int studentId)
        {
            lab6Entities context = this.CurrentDataSource;
            Note note = context.Note.Find(id);
            note.subj = subject;
            note.id_s = studentId;
            note.note1 = Note.ToString();
            context.SaveChanges();
            return context.Note;
        }

        [WebGet]
        public IQueryable<Note> InsertNote(int id, String subject, String Note, int studentId)
        {
            Note note = new Note();
            note.id = id;
            note.subj = subject;
            note.id_s = studentId;
            note.note1 = Note;
            lab6Entities context = this.CurrentDataSource;
            context.Note.Add(note);
            context.SaveChanges();
            return context.Note;
        }

        [WebGet]
        public IQueryable<Students> ChangeStudent(int id, String name)
        {
            lab6Entities context = this.CurrentDataSource;
            Students student = context.Students.Find(id);
            student.name = name;
            context.SaveChanges();
            return context.Students;
        }

        [WebGet]
        public IQueryable<Students> InsertStudent(int id, String name)
        {
            Students student = new Students();
            student.id = id;
            student.name = name;
            lab6Entities context = this.CurrentDataSource;
            context.Students.Add(student);
            context.SaveChanges();
            return context.Students;
        }
    }
}
