using System;
using System.Collections.Generic;

namespace DB_course.Models.DBModels;

public partial class Place
{
    public int Id { get; set; }

    public int? NumberStay { get; set; }

    public int? NumberLayer { get; set; }

    public int? Size { get; set; }

    public virtual ICollection<PlaceofObject> PlaceofObjects { get; } = new List<PlaceofObject>();
}
