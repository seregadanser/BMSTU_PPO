﻿using System;
using System.Collections.Generic;

namespace DB_course.Models.DBModels;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Value { get; set; }
    [DateLessThanOrEqualToToday("01.01.1940")]
    public DateTime? DateCome { get; set; }
    [DateLessThanOrEqualToToday("01.01.1940")]
    public DateTime? DateProduction { get; set; }

   // public virtual ICollection<InventoryProduct> InventoryProducts { get; } = new List<InventoryProduct>();
}
