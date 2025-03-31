using MAVI.Application.Authentication.Dtos;
using MediatR;

namespace MAVI.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<RegisterResult>;
