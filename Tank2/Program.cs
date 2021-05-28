using System;

namespace Tank2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var window = new Scene())
            {
                window.Run(60, 60);
            }
        }
    }
}