using System.Collections.Generic;
using Domain;

namespace Tests.DSL
{
    public static class IntExtensions
    {
        public static IEnumerable<Player> Players(this int value)
        {
            for (var i = 0; i < value; i++)
            {
                yield return new Player();
            }
        }
    }
}