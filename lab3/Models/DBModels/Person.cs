using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DB_course.Models.DBModels;

public partial class Person
{

    [DisplayName("Person Login")]
    [Required(ErrorMessage = "Person Login is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person Login must be between 3 and 50 characters")]
    public string Login { get; set; } = null!;

    [DisplayName("Person Name")]
    [Required(ErrorMessage = "Person name is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person name must be between 3 and 50 characters")]
    [ConcurrencyCheck]
    public string? Name { get; set; }


    [DisplayName("Person SecondName")]
    [Required(ErrorMessage = "Person SecondName is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person SecondName must be between 3 and 50 characters")]
    [ConcurrencyCheck]
    public string? SecondName { get; set; }


    [DisplayName("Person Position ")]
    [Required(ErrorMessage = "Person Position is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person Position must be between 3 and 50 characters")]
    [ConcurrencyCheck]
    public string? Position { get; set; }

    [ConcurrencyCheck]
    [DateLessThanOrEqualToToday]
    public DateTime? DateOfBirthday { get; set; }


    [DisplayName("Person Password")]
    [Required(ErrorMessage = "Person Password is requerid")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Person Password must be between 3 and 50 characters")]
    public string? Password { get; set; }

    public int? NumberOfCome { get; set; }

    public virtual ICollection<Useful> Usefuls { get; } = new List<Useful>();
}
