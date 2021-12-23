using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Kariyer : IEntity
	{
		[Key]
		public int KarID { get; set; }
		[StringLength(100)]
		public String NameSurname { get; set; }
		[StringLength(20)]
		public String Phone { get; set; }
		[StringLength(20)]
		public String Birim { get; set; }
		[StringLength(100)]
		public String LastWorkingName { get; set; }
		[StringLength(30)]
		public String Email { get; set; }
		[StringLength(100)]
		public String Subject { get; set; }
		public DateTime DateKar { get; set; }
		public bool Status { get; set; }
	}
}
