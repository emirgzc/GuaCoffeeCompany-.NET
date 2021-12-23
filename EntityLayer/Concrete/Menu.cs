using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Menu : IEntity
	{
		[Key]
		public int MenuID { get; set; }
		[StringLength(100)]
		public String Title { get; set; }
		[StringLength(1000)]
		public String Description { get; set; }
		public bool Status { get; set; }
	}
}
