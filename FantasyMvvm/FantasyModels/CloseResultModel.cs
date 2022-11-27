using System;
namespace FantasyMvvm.FantasyModels
{
	public class CloseResultModel
	{
		public CloseResultModel()
		{
			

		}

        public CloseResultModel(bool success,object data)
        {
            Success = success;
			this.Data = data;
        }

        public bool Success { get; set;}

		public object Data { get; set; }

	}
}

