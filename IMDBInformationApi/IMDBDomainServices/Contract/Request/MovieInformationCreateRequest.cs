using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Domain
{
    public class MovieInformationCreateRequest
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }

        public string Plot { get; set; }

        public string DateOfRelease { get; set; }

        public int ProducerId { get; set; }
        public string ProducerName { get; set; }

        public List<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public string ActorsId { get; set; }
        public string ActorsName { get; set; }
    }
}
