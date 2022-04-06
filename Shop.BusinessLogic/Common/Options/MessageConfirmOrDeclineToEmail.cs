using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.Options
{
    public class MessageConfirmOrDeclineToEmail
    {
        public string Controller { get; set; }
        public string ActionConfirm { get; set; }
        public string ActionDecline { get; set; }
        public string Host { get; set; }
        public string Scheme { get; set; }
    }
}
