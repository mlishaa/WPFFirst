using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
   public enum Status{
        Teacher,Student,Professional
    }
    class Visitor
    {
        // for simplicity of development we will use poblic properties
        public string Name { get; set; }
        public string Major { get; set; }
        public string Country { get; set; }
        public Status VisitorStatus { get; set; }
        public bool IsSpeaker { get; set; }
        public DateTime CheckInDate { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} | {Major} | {Country} | {VisitorStatus} "
                +
                (IsSpeaker ? "Guest Speaker " : "Spectator"));
               
        }
    }
}
