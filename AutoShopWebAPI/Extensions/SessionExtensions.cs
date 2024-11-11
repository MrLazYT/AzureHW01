﻿using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BusinessLogic.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            string stringValue = JsonSerializer.Serialize(value);

            session.SetString(key, stringValue);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string stringValue = session.GetString(key)!;

            return stringValue == null ? default : JsonSerializer.Deserialize<T>(stringValue);
        }
    }
}
