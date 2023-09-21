using Ksu.Market.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ksu.Market.Domain.Results
{
	public interface IOperationResult : IHaveId
	{
		public object Data { get; set; }
		public bool IsSuccess { get; set; }
		public DateTime DateTime { get; set; }
	}

	public class OperationResult : IOperationResult
	{
		[NotMapped]
		public object Data { get; set; }

		public Guid Id { get; set; }
		public bool IsSuccess { get; set; }
		public DateTime DateTime { get; set; }

		public OperationResult(object data, bool isSuccess)
		{
			Id = Guid.NewGuid();
			Data = data;
			IsSuccess = isSuccess;
			DateTime = DateTime.UtcNow;
		}

		public OperationResult()
		{
		}
	}
}