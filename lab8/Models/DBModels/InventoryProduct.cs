using System;
using System.Collections.Generic;

namespace DB_course.Models.DBModels;

public partial class InventoryProduct
{
    public int InventoryNumber { get; set; }

    public int? ProductId { get; set; }

    //public virtual ICollection<PlaceofObject> PlaceofObjects { get; } = new List<PlaceofObject>();

   // public virtual Product? Product { get; set; }

    //public virtual Useful? Useful { get; set; }
}
