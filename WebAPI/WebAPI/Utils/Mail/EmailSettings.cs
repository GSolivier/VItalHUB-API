﻿namespace WebAPI.Utils.Mail
{
    public class EmailSettings
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? Host { get; set; } //Host SMTP

        public string? Displayname { get; set; }

        public int Port { get; set;}
    }
}