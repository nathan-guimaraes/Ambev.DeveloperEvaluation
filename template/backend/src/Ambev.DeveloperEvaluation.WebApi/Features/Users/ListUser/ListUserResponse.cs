using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class ListUserResponse
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's name
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The user's full name
    /// </summary>
    public FullName Name => new(Username);

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// The current status of the user
    /// </summary>
    public string Status { get; set; }
}
