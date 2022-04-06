using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;

namespace Store.BusinessLogic.Services.EmailService
{
    public class EmailConfigure
    {
        public string MailServerAddress { get; set; }
        public int MailServerPort { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public SecureSocketOptions SecureSocket { get; set; }
    }
}
