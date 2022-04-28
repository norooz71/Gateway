using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide
{
    public class ComunicatedInputDto
    {
        public HttpContext HttpAuthenticationContext { get; set; }
    }
}
