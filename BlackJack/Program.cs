using System;
using System.Linq;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Table t = new Table();
            t.StartGame();
            t.Deal();

        }
    }
}
