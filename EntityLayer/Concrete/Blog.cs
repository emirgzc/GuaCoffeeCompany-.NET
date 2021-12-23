using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Blog : IEntity
	{
		[Key]
		public int BlogID { get; set; }
		[StringLength(100)]
		public String Title { get; set; }
		public String Description { get; set; }
		[StringLength(100)]
		public String Image { get; set; }
		[StringLength(100)]
		public String ByAdmin { get; set; }
		public DateTime BlogDate { get; set; }
		public bool Status { get; set; }
	}
}
