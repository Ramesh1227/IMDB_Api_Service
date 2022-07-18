using IMDBInformation.Domain.Contract.Request.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInformation.Domain
{
    public class MovieInformationCreateRequest
    {
        public string MovieName { get; set; }

        public string Plot { get; set; }

        public string DateOfRelease { get; set; }

        public int ProducerId { get; set; }

        public List<Actors> Actors { get; set; }
    }

}
