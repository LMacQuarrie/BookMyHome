using BookMyHome.Application.Query;
using BookMyHome.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Infrastructure.Queries
{
    public class HostQuery : IHostQuery
    {
        IEnumerable<HostDto> IHostQuery.GetAllHosts()
        {
            throw new NotImplementedException();
        }

        HostDto IHostQuery.GetHost(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
