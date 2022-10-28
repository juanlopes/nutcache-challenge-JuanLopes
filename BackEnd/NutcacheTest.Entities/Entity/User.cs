﻿using NutcacheTest.Entities.Interfaces;
using NutcacheTest.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NutcacheTest.Entities.Entity;

public class User : IUser
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public char Gender { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string CPF { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public Team? Team { get; set; }
}
