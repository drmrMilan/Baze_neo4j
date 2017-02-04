using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4J_Repository.DomainModel
{
    public class Fabrika
    {
        public string Ime { get; set; }
        public int BrRadnika { get; set; }
        public string Adresa { get; set; }
        public string Proizvodnja { get; set; }

        public string ToJsonString()
        {
            return JsonSerializer.SerializeToString(this);
        }
    }
}
