using HangMan.BL.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HangMan.BL.Helpers
{
    public class RandomExtension : IRandomExtension
    {
        private readonly Random _rnd = new Random();

        public int Random(int min, int max)
        {

            return _rnd.Next(min, max);
        }
    }
}
