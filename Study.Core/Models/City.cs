using Study.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Models
{
    public class City : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}