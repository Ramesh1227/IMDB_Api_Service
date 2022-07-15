using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Domain.DataEntities
{
    public interface MovieInfoDataModel
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; }    

        public string DateOfrelease { get; set; }

        public string Producer { get; set; }

        public int ActorsId { get; set; }

        public string ActorsName { get; set; }
    }
}
