using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsMajorsWebApi.Models {

	public class Major {

		public int Id { get; set; }
		[Required]
		[StringLength(30)]
		public string Description { get; set; }
		public int MinSat { get; set; }

		public Major() { }
	}
}