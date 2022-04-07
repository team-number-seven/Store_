﻿using MailKit.Security;

namespace Store.BusinessLogic.Options
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