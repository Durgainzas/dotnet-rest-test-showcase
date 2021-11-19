using System.Collections.Generic;
using Tests.Enums;

namespace Tests.Models
{
    public class Location
    {
        public double Lat { get; set; }
        public double Long { get; set; }
    }

    public class Server
    {
        public string EntryIP { get; set; }
        public string ExitIP { get; set; }
        public string Domain { get; set; }
        public string ID { get; set; }
        public Status Status { get; set; }
    }

    public class LogicalServer
    {
        public string Name { get; set; }
        public string EntryCountry { get; set; }
        public string ExitCountry { get; set; }
        public string Domain { get; set; }
        public int Tier { get; set; }
        public Features Features { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string ID { get; set; }
        public Location Location { get; set; }
        public Status Status { get; set; }
        public List<Server> Servers { get; set; }
        public int Load { get; set; }
        public double Score { get; set; }
    }

    public class VPNLogicalsModel
    {
        public int Code { get; set; }
        public List<LogicalServer> LogicalServers { get; set; }
    }
}
