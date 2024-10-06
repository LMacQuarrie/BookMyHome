using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Commands
{
    public interface IGuestCommand
    {
        void CreateGuest(int createGuestDto);
    }
}
