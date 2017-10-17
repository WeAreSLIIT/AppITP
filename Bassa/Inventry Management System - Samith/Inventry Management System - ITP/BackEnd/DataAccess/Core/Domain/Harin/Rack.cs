using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Rack
    {
        public long RackId { set; get; }
        public string RackName { set; get; }

        public long SectionId { set; get; }
        public Section Section { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
