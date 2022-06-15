﻿namespace VMServer.Models;

public record ConnectionModel
{
    public string IpAddress { get; set; }
    public string Port { get; set; }
    public string ExtraParams { get; set; }
}