using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Activity : IEntity
	{
		[Key]
		public int ActID { get; set; }
		[StringLength(100)]
		public String Title { get; set; }
		public String Description { get; set; }
		[StringLength(100)]
		public String Admin { get; set; }
		[StringLength(100)]
		public String Image { get; set; }
		public DateTime DateAct { get; set; }
		public DateTime DateActivityStart { get; set; }
		public bool Status { get; set; }
	}
}
