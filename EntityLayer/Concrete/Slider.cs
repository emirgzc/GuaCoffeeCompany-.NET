using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Slider : IEntity
	{
		[Key]
		public int SliderID { get; set; }
		[StringLength(150)]
		public String Title { get; set; }
		[StringLength(500)]
		public String Description { get; set; }
		[StringLength(100)]
		public String Image { get; set; }
	}
}
