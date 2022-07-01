using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;
using Lab3.Models;
using Lab3.DB;
using System.IO;
using System.Xml.Serialization;
using System.Net.Http.Formatting;
using Newtonsoft.Json;


namespace Lab3.Controllers
{
    public class StudentController : ApiController
    {
        private readonly Lab3Context dbContext = new Lab3Context();

        [HttpGet]
        public object Get([FromUri] StudentsQuery request)
        {
            try
            {
                List<Student> students = new List<Student>();

                if (request.Sort == SortTypes.NameAsc)
                {
                    students = dbContext.Students.OrderBy(x => x.Name).ToList();
                }
                else if (request.Sort == SortTypes.NameDesc)
                {
                    students = dbContext.Students.OrderByDescending(x => x.Name).ToList();
                }
                else if (request.Sort == SortTypes.IdAsc)
                {
                    students = dbContext.Students.OrderBy(x => x.Id).ToList();
                }
                else if (request.Sort == SortTypes.IdDesc)
                {
                    students = dbContext.Students.OrderByDescending(x => x.Id).ToList();
                }


                if (request.Limit != null)
                {
                    students = students.Skip(request.Offset).Take(request.Limit.Value).ToList();
                }

                if (request.MinId.HasValue)
                {
                    students = students.Where(x => x.Id >= request.MinId).ToList();
                }

                if (request.MaxId.HasValue)
                {
                    students = students.Where(x => x.Id <= request.MaxId).ToList();
                }

                if (request.Like != null)
                {
                    students = students.Where(x => x.Name.ToLower().Contains(request.Like.ToLower())).ToList();
                }

                if (request.GlobalLike != null)
                {
                    students = students.Where(x => (x.Id + x.Name + x.Phone).Contains(request.GlobalLike)).ToList();
                }

                //throw new Exception("");

                List<StudentDto> studentDtos = new List<StudentDto>();

                string link = Request.RequestUri.Query == "" ? Request.RequestUri.AbsoluteUri : Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.Query, string.Empty);

                foreach (Student student in students)
                {
                    StudentDto studentDto = new StudentDto { StudentId = student.Id, Name = student.Name, Phone = student.Phone };
                    studentDto.Links = new List<LinkDto>
                {
                    new LinkDto($"{link}/{studentDto.StudentId}", "self", "GET"),
                    new LinkDto($"{link}/{studentDto.StudentId}", "UpdateItem", "PUT"),
                    new LinkDto($"{link}/{studentDto.StudentId}", "DeleteItem", "DELETE"),
                };
                    studentDtos.Add(studentDto);
                }

                if (request.Format == ResponseTypes.XML)
                {
                    using (var writer = new StringWriter())
                    {
                        XmlSerializer serializer;

                        if (request.Columns == null || request.Columns.Length == 0)
                        {
                            serializer = new XmlSerializer(studentDtos.GetType());
                        }
                        else
                        {
                            XmlAttributes studentDtoPropertyAttributes = new XmlAttributes();
                            studentDtoPropertyAttributes.XmlIgnore = true;

                            XmlAttributeOverrides studentDtoAttributes = new XmlAttributeOverrides();
                            foreach (var prop in typeof(StudentDto).GetProperties())
                            {
                                if (!request.Columns.ToLower().Contains(prop.Name.ToLower()) && prop.Name.ToLower() != "links")
                                {
                                    studentDtoAttributes.Add(typeof(StudentDto), prop.Name, studentDtoPropertyAttributes);
                                }
                            }

                            serializer = new XmlSerializer(studentDtos.GetType(), studentDtoAttributes);
                        }

                        XmlMediaTypeFormatter formatter = new XmlMediaTypeFormatter
                        {
                            UseXmlSerializer = true
                        };
                        formatter.SetSerializer(studentDtos.GetType(), serializer);

                        return Content(HttpStatusCode.OK, studentDtos, formatter);
                    }
                }

                string result = request.Columns == null || request.Columns.Length == 0 ? JsonConvert.SerializeObject(studentDtos) : JsonConvert.SerializeObject(studentDtos,
                    Formatting.Indented, new JsonSerializerSettings { ContractResolver = new DynamicContractResolver(request.Columns.ToLower().Split(',').Append("links").Append("href").Append("rel").Append("method").ToArray()) });

                return Content(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { status = HttpStatusCode.BadRequest, href = "http://localhost:49985/api/errors/50000", ex = ex });
            }

        }

        // GET api/<controller>/5
        public object Get(int id, [FromUri] ResponseTypes format = ResponseTypes.JSON)
        {
            Student student = dbContext.Students.Find(id);

            if (student == null)
            {
                return Content(HttpStatusCode.BadRequest, new { status = HttpStatusCode.BadRequest, href = "http://localhost:49985/api/errors/40004" });
            }
            else
            {
                if (format == ResponseTypes.XML)
                {
                    using (var writer = new StringWriter())
                    {
                        XmlSerializer serializer = new XmlSerializer(student.GetType());
                        serializer.Serialize(writer, student);

                        return Content(HttpStatusCode.OK, writer.ToString());
                    }
                }
                return Content(HttpStatusCode.OK, student);
            }
        }

        // POST api/<controller>
        public object Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { status = HttpStatusCode.BadRequest, href = "http://localhost:49985/api/errors/40000" });
            }

            Student newStudent = dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return Content(HttpStatusCode.OK, newStudent);
        }

        // PUT api/<controller>/5
        public object Put(int id, [FromBody] Student student)
        {
            student.Id = id;
            dbContext.Entry(student).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return Ok();
        }

        // DELETE api/<controller>/5
        public object Delete(int id)
        {
            Student student = dbContext.Students.Find(id);
            if (student == null)
            {
                return Content(HttpStatusCode.BadRequest, new { status = HttpStatusCode.BadRequest, href = "http://localhost:49985/api/errors/40004" });
            }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
