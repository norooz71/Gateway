using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide;

public class ComunicatedResponse
{
    #region UserManagement

    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String FullName { get; set; }
    public String Email { get; set; }
    public bool IsShahkarValidated { get; set; }
    public DateTime? ShahkarValidateDate { get; set; }
    public bool IsHeaderNameFull { get; set; }
    public string NationalCode { get; set; }
    public long? MabnaWalletId { get; set; }
    public String MabnaRegisterPhoneNumber { get; set; }
    public bool? IsProfileComplete { get; set; }
    public string AccountNo { get; set; }
    public string CardNumber { get; set; }
    public string AccountName { get; set; }
    public DateTime? CreateDateAccount { get; set; }

    public bool DeviceTokenValidated { get; set; }
    public bool UserValidated { get; set; }
    #endregion
}







