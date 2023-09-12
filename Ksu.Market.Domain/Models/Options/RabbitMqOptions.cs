using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Market.Domain.Models.Options
{
	public class RabbitMqOptions
	{
		public string Host { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }	
	}
}
