﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BachoLibrary.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsBetween(this decimal number, decimal min, decimal max) => number >= min && number <= max;
    }
}
