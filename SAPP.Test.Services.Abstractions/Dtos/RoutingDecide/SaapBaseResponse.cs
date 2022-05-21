using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SAPP.Gateway.Services.Abstractions.Dtos.RoutingDecide
{
    public class BaseResponse<T>
    {
        #region Variables

        [JsonIgnore]
        public ServerAnswerEnum ServerAnswer { get; set; }

        public String Answer
        {
            get { return ServerAnswer.ToString(); }
        }
        public int AnswerCode
        {
            get { return (int)ServerAnswer; }
        }
        /*public String PersianAnswerCode
        {
            get { return GetServerAnswerEnumByType(ServerAnswer); }
        }*/

        public T Data { get; set; }
        public Object AdditionalData { get; set; }
        public List<String> MessageList { get; set; }

        #endregion

        #region Constructors

        public BaseResponse()
        {
            MakeDefaults();
        }

        public BaseResponse(Exception ex)
        {
            MakeDefaults();

            ServerAnswer = ServerAnswerEnum.Exception;
            MessageList.Add(ex != null ? ex.Message : "خطای نامشخص");
        }
        public BaseResponse(ServerAnswerEnum answer, T data = default(T), Object additionalData = null, List<String> messagelist = null)
        {
            MakeDefaults();

            ServerAnswer = answer;
            Data = data;
            AdditionalData = additionalData;
            if (messagelist != null)
                MessageList = messagelist;
        }
        public BaseResponse(ServerAnswerEnum answer, List<String> messagelist)
        {
            MakeDefaults();

            ServerAnswer = answer;

            if (MessageList != null)
                MessageList = messagelist;
        }
        public BaseResponse(ServerAnswerEnum answer, List<Exception> messagelist)
        {
            MakeDefaults();

            ServerAnswer = answer;

            if (MessageList != null)
                MessageList = messagelist.Select(x => x.Message).ToList();
        }
        #endregion

        #region Helper Methods

        private void MakeDefaults()
        {
            ServerAnswer = ServerAnswerEnum.Null;
            Data = default(T);
            AdditionalData = "";
            MessageList = new List<string>();
        }
       
        public void AddMessage(string message)
        {
            if (MessageList == null)
                MessageList = new List<string>();

            MessageList.Add(message);
        }


        #endregion
    }


   


    public enum ServerAnswerEnum
    {
        [Description("خطای نامشخص")]
        Null = 0,

        [Description("ورودی نامشخص")]
        InputDataWasNull = 1,

        [Description("موفق")]
        Ok = 10,

        [Description("تغییر آدرس")]
        Redirect = 20,

        [Description("توکن منقضی شده")]
        TokenExpire = 30,

        [Description("شکست در بازخوانی توکن")]
        TokenFailed = 31,

        [Description("شکست در کنترل توکن یکتا")]
        CsrfFailed = 32,

        [Description("عدم دسترسی")]
        AccessDenied = 40,

        [Description("نبود اطلاعات کاربری")]
        LoginFailed = 50,

        [Description("قبلاً در سیستم وارد شده")]
        YouAreLogedIn = 51,

        [Description("دستگاه برای کاربر دیگری تعریف شده است")]
        DeviceRegisterForOtherUser = 52,

        [Description("خطا در کنترل کد امنیتی")]
        CaptchaCodeError = 53,


        [Description("خطا")]
        Error = 60,

        [Description("خطای بحرانی")]
        Exception = 70,

        [Description("خطای بحرانی مرکزی")]
        WebCoreException = 71,

        [Description("خطای عملکرد سرویس نرم افزاری")]
        ServiceUnavailableException = 72,

        [Description("اطلاعاتی در دیتابیس موجود نمی باشد.")]
        NotFoudDataInDb= 73

    }
}
