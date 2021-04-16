using System;

namespace HangMan.HMServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new HangManDbContext();
            context.Database.EnsureCreated();
        }
    }
}
