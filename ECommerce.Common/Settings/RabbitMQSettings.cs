﻿namespace ECommerce.Common.Settings
{
    public class RabbitMQSettings
    {
        public string HostName { get; init; } = null!;
        public int Port { get; init; }
        public string UserName { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}