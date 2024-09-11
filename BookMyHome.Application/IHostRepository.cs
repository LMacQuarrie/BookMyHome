using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Domain.Entity;

namespace BookMyHome.Application
{
    public interface IHostRepository
    {
        Host GetHost(int id);
        void AddHost(Host host);
        void UpdateHost(Host host, byte[] rowVersion);
        void DeleteHost(Host host, byte[] rowVersion);
    }
}
