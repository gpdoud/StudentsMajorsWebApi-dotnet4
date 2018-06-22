using StudentsMajorsWebApi.Models;
using StudentsMajorsWebApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsMajorsWebApi.Controllers {

	public class StudentsController : ApiController {

		private Models.StudentMajorDbContext db = new Models.StudentMajorDbContext();

		[HttpGet]
		[ActionName("List")]
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Students.ToList()
			};
		}
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse Get(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Get requires an Id"
				};
			return new JsonResponse {
				Data = db.Students.Find(id)
			};
		}
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(Student student) {
			if (student == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Student"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Students.Add(student);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = student
			};
		}
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(Student student) {
			if (student == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Change requires an instance of Student"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(student).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = student
			};
		}
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(Student student) {
			if (student == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "Remove requires an instance of Student"
				};
			if (!ModelState.IsValid)
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			db.Entry(student).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = student
			};
		}
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if (id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a Student.Id"
				};
			var student = db.Students.Find(id);
			if (student == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No student has Id of {id}"
				};
			db.Students.Remove(student);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = student
			};
		}

	}
}
