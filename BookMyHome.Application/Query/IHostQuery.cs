using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyHome.Application.Query.QueryDto;

namespace BookMyHome.Application.Query
{
    public interface IHostQuery
    {
        HostDto GetHost(int Id);
        IEnumerable<HostDto> GetAllHosts();
    }
}
