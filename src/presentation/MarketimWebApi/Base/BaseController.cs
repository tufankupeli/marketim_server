using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace MarketimWebApi.Base
{
    
    public class BaseController:Controller
    {
        

        public bool SessionHasValue(string key){
            return (HttpContext.Session.IsAvailable && HttpContext.Session.Get(key) != null) ? true : false;
        }

        public String GetSessionStringValue(string key){
            if(!HttpContext.Session.IsAvailable){
                return null;
            }
            return HttpContext.Session.GetString(key);
        }

        public bool SetSessionStringValue(string key, string value)
        {
            if (!HttpContext.Session.IsAvailable)
            {
                return false;
            }

            try
            {
                HttpContext.Session.SetString(key, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetSessionIntValue(string key, int defaultValue)
        {
            if (!HttpContext.Session.IsAvailable)
            {
                return defaultValue;
            }

            int? value = HttpContext.Session.GetInt32(key);
            if(value.HasValue){
                return value.Value;
            }else{
                return defaultValue;
            }
        }

        public bool SetSessionIntValue(string key, int value)
        {
            if (!HttpContext.Session.IsAvailable)
            {
                return false;
            }

            try
            {
                HttpContext.Session.SetInt32(key, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }


        public T GetSessionValue<T>(string key)
        {
            if (!HttpContext.Session.IsAvailable)
            {
                return default(T);
            }

            string value = HttpContext.Session.GetString(key);
            if(value != null){
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
            }else{
                return default(T);
            }
        }

        public bool SetSessionValue(string key, Object value){
            if (!HttpContext.Session.IsAvailable)
            {
                return false;
            }
            try
            {
                HttpContext.Session.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetSessionCustomer(){
            string customerId = null;

            if(SessionHasValue(SessionConstants.SC_CUSTOMER)){
                customerId = GetSessionValue<string>(SessionConstants.SC_CUSTOMER);
            }

            return customerId;
        }

    }
}
