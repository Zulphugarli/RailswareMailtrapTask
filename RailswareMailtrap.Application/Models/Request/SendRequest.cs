using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailswareMailtrap.Application.Models.Request
{
    public class SendRequest
    {
        public MailParams MailParams { get; set; }
        public Settings Settings { get; set; }
    }
}
