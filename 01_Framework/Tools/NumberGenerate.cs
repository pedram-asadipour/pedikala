using System;

namespace _01_Framework.Tools
{
    public class NumberGenerate
    {
        public static int Random()
        {
            var random = new Random();

            return random.Next();
        }
    }
}