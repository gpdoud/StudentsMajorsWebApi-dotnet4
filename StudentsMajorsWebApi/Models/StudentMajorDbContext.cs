using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsMajorsWebApi.Models {

	public class StudentMajorDbContext : System.Data.Entity.DbContext {

		public StudentMajorDbContext() : base("name=StudentMajorConnection") { }

		public System.Data.Entity.DbSet<Major> Majors { get; set; }
		public System.Data.Entity.DbSet<Student> Students { get; set; }

	}
}