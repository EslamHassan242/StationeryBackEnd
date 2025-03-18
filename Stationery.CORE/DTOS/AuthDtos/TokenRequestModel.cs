using System.ComponentModel.DataAnnotations;

namespace Stationery.CORE.DTOS.AuthDtos
{
    public class TokenRequestModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}