using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neo4J_Repository.DomainModel
{
    public class Prevoznik
    {
        public string Ime { get; set; }
        public int Vozila { get; set; }

        public string ToJsonString()
        {
            return JsonSerializer.SerializeToString(this);
        }
    }
}