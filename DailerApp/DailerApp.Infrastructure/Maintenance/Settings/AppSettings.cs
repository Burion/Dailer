using System;
using DailerApp.AppCore.Settings;

namespace DailerApp.Infrastructure.Settings
{
    public class AppSettings : IAppSettings
    {
        public int LevelExp => 40;

        public int ToAdd => 20;
    }
}