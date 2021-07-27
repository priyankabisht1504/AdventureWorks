using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class DepartmentModel : BaseModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string GroupName { get; set; }

    }
}
