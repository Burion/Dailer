using System;

namespace DailerApp.AppCore.Services
{
    public interface IHttpContextHendler
    {
        string GetCurrrentUserId();
    }
}