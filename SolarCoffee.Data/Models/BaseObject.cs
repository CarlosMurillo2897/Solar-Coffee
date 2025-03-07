﻿using System;

namespace SolarCoffee.Data.Models
{
    /// <summary>
    /// Common Model properties extracted into a Parent Class.
    /// </summary>
    public class BaseObject
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
