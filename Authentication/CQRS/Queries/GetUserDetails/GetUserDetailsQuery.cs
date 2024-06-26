﻿namespace AuthenticationService.CQRS.Queries.GetUserDetails;

public class GetUserDetailsQuery : IRequest<UserDto>
{
    public GetUserDetailsQuery(string userId)
    {
        UserId = userId;
    }
    public string UserId { get; }
}
