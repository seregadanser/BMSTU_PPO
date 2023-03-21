using System;
using System.Collections.Generic;

namespace DB_course.Models.DBModels;

public partial class PlaceofObject
{
    public int Id { get; set; }

    public int? PlaceId { get; set; }

    public int? InventoryId { get; set; }

    public virtual InventoryProduct? Inventory { get; set; }

    public virtual Place? Place { get; set; }
}
