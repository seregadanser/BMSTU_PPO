using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Xunit.Sdk;

namespace DB_course.Models.DBModels;

public partial class PlaceofObject
{
    public int Id { get; set; }
    [DisplayName("placeid")]
    [Required(ErrorMessage = " place Id is requerid")]
    [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int? PlaceId { get; set; }

    public int? InventoryId { get; set; }

    //public virtual InventoryProduct? Inventory { get; set; }

   // public virtual Place? Place { get; set; }
}
