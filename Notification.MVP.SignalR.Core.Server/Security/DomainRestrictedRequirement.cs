﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.MVP.SignalR.Core.Server.Security
{
    public class DomainRestrictedRequirement :
    AuthorizationHandler<DomainRestrictedRequirement, HubInvocationContext>,
    IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            DomainRestrictedRequirement requirement,
            HubInvocationContext resource)
        {
            if (IsUserAllowedToDoThis(resource.HubMethodName, context.User.Identity.Name) &&
                context.User.Identity.Name.EndsWith("@microsoft.com"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

        private bool IsUserAllowedToDoThis(string hubMethodName,
            string currentUsername)
        {
            return !(currentUsername.Equals("asdf42@microsoft.com") &&
                hubMethodName.Equals("banUser", StringComparison.OrdinalIgnoreCase));
        }
    }
}
