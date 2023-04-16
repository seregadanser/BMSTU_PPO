using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DB_course.Models.DBModels;

public partial class Useful
{
    [DisplayName("Inventory Id")]
    [Required(ErrorMessage = "Inventory Id is requerid")]
    [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int InventoryId { get; set; }

    [DisplayName("Person Login")]
    [Required(ErrorMessage = "Person Login is requerid")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Person Login must be between 3 and 50 characters")]
    public string? PersonId { get; set; }

    [DateLessThanOrEqualToToday]
    public DateTime? DateOfStart { get; set; }

  //  public virtual InventoryProduct Inventory { get; set; } = null!;

   //public virtual Person? Person { get; set; }
}
