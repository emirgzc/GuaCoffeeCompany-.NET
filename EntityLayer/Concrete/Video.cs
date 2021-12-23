using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Video : IEntity
	{
		[Key]
		public int VideoID { get; set; }
		[StringLength(250)]
		public String VideoURL { get; set; }
		public bool Status { get; set; }
		public DateTime DateVideo { get; set; }
	}
}
