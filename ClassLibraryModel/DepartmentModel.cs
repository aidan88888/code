using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class DepartmentsModel
    {

        public int pk_DepartmentId { get; set; }
        public string? Name { get; set; }
        public int fk_OrganizationId { get; set; }
        public string Block { get; set; }
        public bool IsActive { get; set; }

    }

}

