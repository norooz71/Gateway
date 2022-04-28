using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide;

    public class ComunicatedResponse

    {
        #region UserManagement

        public UserData CurrentUser { get; set; }

        #endregion
    }

public class UserData 
{
    #region Variables
    public String UserNickname { get; set; }

    public String Username
    {
        get { return _userName; }
        set
        {
            var temp = value ?? "";
            if (temp.Length > 450)
                temp = temp.Substring(0, 450);

            _userName = temp;
        }
    }
    public String CleanPassword
    {
        set
        {
            _cleanPassword = value ?? "";
            var passWord = EncryptDecryptUtilities.CalculateMd5Hash(_cleanPassword);

            if (passWord.Length > 150)
            {
                _cleanPassword = "";
                _password = "";
            }
            else
                _password = passWord;
        }
    }
    public String Password
    {
        get { return _password; }
    }
    public UserStateEnum UserState { get; set; }
    public String PersianUserState
    {
        get { return GetPersianUserStateEnum(UserState); }
    }
    public DateTime? RegisterDate { get; set; }
    public UserPlatform Platform { get; set; }
    public String UserPhoneNumber
    {
        get { return _userPhoneNumber; }
        set
        {
            var temp = value ?? "";
            if (temp.Length > 450)
                temp = temp.Substring(0, 450);

            _userPhoneNumber = temp;
        }
    }

    public String MelliCode
    {
        get { return _melliCode; }
        set
        {
            var temp = value ?? "";
            if (temp.Length > 15)
                temp = temp.Substring(0, 15);
            _melliCode = temp;
        }
    }
    public UserInformation UserInformationData { get; set; }

    [JsonIgnore]
    public RoleData UserRoleData
    {
        get
        {
            try
            {
                if (_roleData == null ||
                    _roleData.Id != Fk_UserRoleId)
                {
                    var dataTable = new RoleDataDA().GetBaseDbModelById(Fk_UserRoleId);
                    if (dataTable != null)
                        _roleData = new RoleData(dataTable);
                    else
                        _roleData = null;
                }

                return _roleData;
            }
            catch (Exception ex)
            {
                AddExceptionData(ex);
                return null;
            }
        }
    }
    public string UserCode { get; set; }
    public string UserInviteCode { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public NationalityEnum Nationality { get; set; }

    public DateTime? LastSendSmsDate { get; set; }
    public byte? IsExit { get; set; }


    private String _melliCode = "";
    private String _userNickName = "";
    private String _userName = "";
    private String _password = "";
    private String _cleanPassword = "";
    private String _userPhoneNumber = "";
    private RoleData _roleData = null;
    #endregion

    #region Constructors

    public UserData() : base(ObjectTypeEnum.UserData)
    {
        MakeDefaults();
    }
    public UserData(Object data) : base(ObjectTypeEnum.UserData, data)
    {
        MakeDefaults();
        if (data is UserDataTable)
            FillAppDeviceInfoByDbModel(data);
        //else if (data is GetUserListByUserIds_Result)
        //    FillAppDeviceInfoByDbModelFunction(data);

    }

    private void FillAppDeviceInfoByDbModel(Object data)
    {
        if (!(data is UserDataTable)) return;

        var model = (UserDataTable)data;

        Fk_UserRoleId = model.Fk_UserRoleId;
        UserNickname = model.UserNickname;
        Username = model.Username;
        _password = model.Password;
        UserPhoneNumber = model.UserPhoneNumber;
        RegisterDate = model.RegisterDate;
        UserCode = model.UserCode;
        UserInviteCode = model.UserInviteCode;
        Nationality = EnumUtilities.ConvertStringToEnum(model.Nationality, NationalityEnum.Iranian);
        MelliCode = model.MelliCode;
        LastLoginDate = model.LastLoginDate;
        Exception exData = null;
        var platForm = (UserPlatform)SerializUtilities.JsonDeSerialize(model.Platform ?? "", typeof(UserPlatform), out exData);
        if (exData == null)
            Platform = platForm;

        exData = null;
        var userInformation = (UserInformation)SerializUtilities.JsonDeSerialize(model.UserInformationData ?? "", typeof(UserInformation), out exData);
        if (exData == null)
            UserInformationData = userInformation;

        UserState = EnumUtilities.ConvertStringToEnum(model.UserState, UserStateEnum.InActive);

        LastSendSmsDate = model.LastSendSmsDate;
        IsExit = model.IsExit;
    }

    #endregion

    #region Abstract Methods

    protected override object _MakeDAModel()
    {
        var daModel = new UserDataTable()
        {
            Fk_UserRoleId = Fk_UserRoleId,
            UserNickname = UserNickname,
            Username = Username,
            Password = _password,
            UserState = UserState.ToString(),
            RegisterDate = RegisterDate,
            Platform = SerializUtilities.JsonSerialize(Platform),
            UserPhoneNumber = UserPhoneNumber,
            UserInformationData = SerializUtilities.JsonSerialize(UserInformationData),
            UserCode = UserCode,
            UserInviteCode = UserInviteCode,
            MelliCode = MelliCode,
            LastLoginDate = LastLoginDate,
            Nationality = Nationality.ToString(),
            IsExit = IsExit,
            LastSendSmsDate = LastSendSmsDate
        };

        return daModel;
    }
    public override string GetObjectName()
    {
        return Username + " (" + UserNickname + ")";
    }
    public override string GetObjectDescription()
    {
        return UserPhoneNumber;
    }

    #endregion

    #region Helper Methods

    private void MakeDefaults()
    {
        Fk_UserRoleId = 0;
        UserNickname = "";
        Username = "";
        _password = "";
        UserState = UserStateEnum.InActive;
        RegisterDate = null;
        Platform = new UserPlatform();
        UserPhoneNumber = UserPhoneNumber;
        UserInformationData = new UserInformation();
        UserCode = string.Empty;
        UserInviteCode = string.Empty;
        MelliCode = "";
        LastLoginDate = null;
        Nationality = 0;
        IsExit = 0;
        LastSendSmsDate = null;
    }
    public static string GetPersianUserStateEnum(UserStateEnum userState)
    {
        try
        {
            switch (userState)
            {
                case UserStateEnum.InRegister:
                    return "در حال ثبت نام";
                case UserStateEnum.Active:
                    return "فعال";
                case UserStateEnum.InActive:
                    return "غیر فعال";
                case UserStateEnum.BlockByAdmin:
                    return "مسدود توسط مدیر سیستم";
                case UserStateEnum.BlockBySystem:
                    return "مسدود توسط سیستم";
                default:
                    return "نامشخص";
            }
        }
        catch (Exception ex)
        {
            AddStaticExceptionData(ex);
            return "نامشخص";
        }
    }

    #endregion
}





