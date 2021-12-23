using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Store : IEntity
	{
		[Key]
		public int StoreID { get; set; }
		[StringLength(100)]
		public String Title { get; set; }
		public String Description { get; set; }
		public String Color { get; set; }
		[StringLength(100)]
		public String Image { get; set; }
		public decimal Money { get; set; }
		public DateTime DateStore { get; set; }
		public bool Status { get; set; }
	}
}
