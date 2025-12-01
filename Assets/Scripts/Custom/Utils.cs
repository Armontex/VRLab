using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityEngine.Custom
{
    public static class RandomExtensions
    {
        public static T RandomChoice<T>(this System.Random rnd, IEnumerable<T> arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            var list = arr as IList<T> ?? arr.ToList();

            if (list.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");

            int index = rnd.Next(list.Count);
            return list[index];
        }
    }
}


