using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.Converters.Models
{
    public class Recent
    {
        public int ChatId { get; set; }
        public string Name { get; set; }
        public string LastMessage { get; set; }
    }
}
