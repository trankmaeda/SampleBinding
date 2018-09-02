using SampleBinding.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace SampleBinding.Services
{
    public class PCService : IPCService
    {
        public List<PC> PCs { get; } = GetSampleData();

        public PCService()
        {
            Debug.WriteLine("PCService constructor called.");
        }

        private static List<PC> GetSampleData()
        {
            return new List<PC>
            {
                new PC
                {
                    Name = "ServerA",
                    IP = "10.2.0.1"
                },
                new PC
                {
                    Name = "ServerB",
                    IP = "192.168.1.1"
                },
                new PC
                {
                    Name = "ServerC",
                    IP = "192.168.10.0"
                },
                new PC
                {
                    Name = "ServerD",
                    IP = "10.11.1.0"
                }
            };
        }
    }
}
