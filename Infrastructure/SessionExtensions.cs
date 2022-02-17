﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CodeSec.Infrastructure
{
    public static class SessionExtensions
    {
    //this extension class contains set and get method for json
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
                ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}