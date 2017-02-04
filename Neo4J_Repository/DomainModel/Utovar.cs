using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4J_Repository.DomainModel
{
    class Utovar
    {
        public int Godina { set; get; }
        public int Mesec { set; get; }
        public int Dan { set; get; }
        public int Tezina { set; get; }

        public string ToJsonString()
        {
            return JsonSerializer.SerializeToString(this);
        }
    }
}
