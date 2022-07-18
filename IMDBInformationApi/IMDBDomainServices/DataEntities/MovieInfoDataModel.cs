using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Domain.DataEntities
{
    public class MovieInfoDataModel
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Plot { get; set; }

        public string DateOfrelease { get; set; }

        public string ProducerName { get; set; }

        public string ActorName { get; set; }
    }
}
