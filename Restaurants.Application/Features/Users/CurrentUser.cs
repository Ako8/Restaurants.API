using Restaurants.Domain.Entities;

namespace Restaurants.Application.Features.Users;

public record class CurrentUser(string Id,
    string Email,
    IEnumerable<string> Roles,
    DateOnly? DateOfBirth,
    string? Nationality)
{
    public bool IsInRole(string role) => Roles.Contains(role);
}
