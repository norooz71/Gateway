using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Domain.Entities.Test
{
    public class TestParent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TestChild> TextChilderen { get; set; }
    }
}
