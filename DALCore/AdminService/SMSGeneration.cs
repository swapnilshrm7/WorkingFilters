using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace UserService
{
    public class SMSGeneration : ISMSGeneration
    {
        public int SMS(long contact)
        {
            try
            {
                // Find your Account Sid and Auth Token at twilio.com/user/account 
                const string accountSid = "AC7142aef8be75aa40aaa65cbcca4b2329";
                const string authToken = "8ed4e7af2f184cf4c9a781efeff950d7";
                TwilioClient.Init(accountSid, authToken);
                int otp = RandomNumber();
                var to = new PhoneNumber("+91" + contact);
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber("+13158832734"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ). 
                    body: $"Hello tavisca visitor!! Your one time password is {otp}");
                return otp;
            }
            catch (Exception ex)
            {
                throw new Exception("Registration Failure:" + ex.Message);
            }
        }
        public static int RandomNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}

