using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Galery : IEntity
	{
		[Key]
		public int GaleryID { get; set; }
		[StringLength(100)]
		public String Title { get; set; }
		[StringLength(100)]
		public String Image { get; set; }
		public DateTime DatePhoto { get; set; }
		public bool Status { get; set; }
	}
}
