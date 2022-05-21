using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide
{
    public class ComunicatedInputDto
    {
        public string AuthHeader { get; set; }

        public string CsrfTokenId { get; set; }
    }
}
