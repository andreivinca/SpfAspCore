using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpfAspCore.Extensions
{
    public static class ExArray
    {
        static int LastIndexOf<T>(this T[] array, T[] sought) where T : IEquatable<T> =>
           array.AsSpan().LastIndexOf(sought);
    }
}
