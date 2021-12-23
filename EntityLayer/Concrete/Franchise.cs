using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Franchise : IEntity
	{
		[Key]
		public int FranID { get; set; }
		[StringLength(100)]
		public String Name { get; set; }
		[StringLength(20)]
		public String Phone { get; set; }
		[StringLength(100)]
		public String CompanyName { get; set; }
		[StringLength(30)]
		public String Email { get; set; }
		[StringLength(100)]
		public String Note { get; set; }
		[StringLength(500)]
		public String Message { get; set; }
		public DateTime DateFran { get; set; }
		public bool Status { get; set; }
	}
}
