﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GUI_Index.Session
{
    //make abstraction for testing purposes
    public interface IUserSession
    {
        User User { get; set; }

    }

    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User User
        {
            get => _httpContextAccessor.HttpContext.Session.GetObjectFromJson<User>("user");
            set => _httpContextAccessor.HttpContext.Session.SetObjectAsJson("user", value);
        }
    }

    //from: https://benjii.me/2016/07/using-sessions-and-httpcontext-in-aspnetcore-and-mvc-core/
    public static class SessionExtension
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
