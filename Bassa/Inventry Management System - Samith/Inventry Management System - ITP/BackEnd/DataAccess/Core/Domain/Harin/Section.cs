using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Section
    {
        public long SectionId { set; get; }
        public string SectionName { set; get; }

        public ICollection<Rack> Racks { get; set; }
    }
}
