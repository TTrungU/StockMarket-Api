using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class UserNotFoundException:NotFoundException
    {
        public UserNotFoundException(int id):base($"User with id {id} was not found")
        {
            
        }
    }
}
