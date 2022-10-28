using NutcacheTest.Entities.Enums;

namespace NutcacheTest.Entities.Interfaces;

public interface IUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public char Gender { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public DateTime StartDate { get; set; }
    public Team? Team { get; set; }
}