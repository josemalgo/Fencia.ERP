﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Extensions
{
    public static class IListExtension
    {
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null) throw new ArgumentNullException(nameof(items));

            if(list is IList<T> asList)
            {
                asList.AddRange(items);
            }
            else
            {
                foreach(var item in items)
                {
                    list.Add(item);
                }
            }
        }
    }
}
