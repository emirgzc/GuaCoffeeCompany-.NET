using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Setting : IEntity
	{
		[Key]
		public int SetID { get; set; }
		[StringLength(40)]
		public String Address { get; set; }
		[StringLength(20)]
		public String City { get; set; }
		[StringLength(20)]
		public String Country { get; set; }
		[StringLength(20)]
		public String Phone { get; set; }
		[StringLength(20)]
		public String Email { get; set; }
		[StringLength(100)]
		public String Facebook { get; set; }
		[StringLength(100)]
		public String Youtube { get; set; }
		[StringLength(1500)]
		public String Map { get; set; }
		[StringLength(100)]
		public String Instagram { get; set; }
	}
}
