using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace GarbageScheduleReminder
{
    public class TwilioService
    {
        private readonly string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        private readonly string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
        private readonly string fromPhoneNumber = Environment.GetEnvironmentVariable("TWILIO_FROM_PHONE");
        private readonly string toPhoneNumber = Environment.GetEnvironmentVariable("TWILIO_TO_PHONE");
        public TwilioService()
        {
            TwilioClient.Init(accountSid, authToken);
        }
        public void SendMessage(string message)
        {
            var textMsg = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );

            Console.WriteLine(textMsg.Sid);
        }
    }
}
