using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class About : IEntity
	{
		[Key]
		public int AboutID { get; set; }
		[StringLength(100)]
		public String Title { get; set; }
		public String GuaAbout { get; set; }
	}
}
