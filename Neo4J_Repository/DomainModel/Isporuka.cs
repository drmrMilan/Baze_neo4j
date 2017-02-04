using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4J_Repository.DomainModel
{
    public class Isporuka
    {
        public string IdVozila { get; set; }
        public string IdIsporuke { get; set; }
        public string ToJsonString()
        {
            return JsonSerializer.SerializeToString(this);
        }
    }
}
