using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Sube : IEntity
	{
		[Key]
		public int SubeID { get; set; }
		[StringLength(100)]
		public String Title { get; set; }
		[StringLength(1500)]
		public String Map { get; set; }
		public bool Status { get; set; }
	}
}
