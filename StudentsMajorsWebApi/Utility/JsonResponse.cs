using System;

namespace StudentsMajorsWebApi.Utility {

	public class JsonResponse {
		public string Result { get; set; } = "Ok";
		public string Message { get; set; } = "Success";
		public object Data { get; set; }
		public object Error { get; set; }
	}

}