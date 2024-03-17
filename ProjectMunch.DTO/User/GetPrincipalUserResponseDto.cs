using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMunch.DTO.User
{
    public record GetPrincipalUserResponseDto(string UserName, IEnumerable<string> Roles);
}
