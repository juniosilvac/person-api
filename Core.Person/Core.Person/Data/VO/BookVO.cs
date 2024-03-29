﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Core.Person.Data.VO
{
    [DataContract]
    public class BookVO
    {
        [DataMember(Order = 1, Name = "codigo")]
        public long? Id { get; set; }

        [DataMember(Order = 2)]
        public string Title { get; set; }

        [DataMember(Order = 3)]
        public string Author { get; set; }

        [DataMember(Order = 5)]
        public decimal Price { get; set; }

        [DataMember(Order = 4)]
        public DateTime LaunchDate { get; set; }
    }
}
