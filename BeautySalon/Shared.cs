using BeautySalon.Models;
using System;

namespace BeautySalon
{
    public static class Shared
    {
        public static Usuario UsuarioLogado { get; set; }
        public static string DatabaseName { get; set; } = $@"Filename={AppDomain.CurrentDomain.BaseDirectory}data.db;Password=@Taf061090;Upgrade=true";
    }
}
