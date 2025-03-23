using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PesnL.DataTransferObject
{
    public class CreatedDepartmentDto
    {

        public string Name { get; set; } = null!;
        public string code { get; set; } = null!;
        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }

    }
}
