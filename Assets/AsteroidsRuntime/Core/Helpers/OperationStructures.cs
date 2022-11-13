using System.Collections.Generic;

namespace Asteroids.Core.Helpers
{
    internal class OperationStructures<T>
    {
        public static readonly List<T> List = new(64);
    }
}