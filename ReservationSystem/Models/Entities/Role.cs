﻿using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
