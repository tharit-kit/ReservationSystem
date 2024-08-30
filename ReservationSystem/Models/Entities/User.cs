using System;
using System.Collections.Generic;

namespace ReservationSystem.Models.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int RoleId { get; set; }

    public string Email { get; set; } = null!;

    public string? EncryptedPassword { get; set; }

    public byte[]? GeneratedSalt { get; set; }

    public virtual Role Role { get; set; } = null!;
}
