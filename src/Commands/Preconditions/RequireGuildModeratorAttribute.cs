using System;
using System.Threading.Tasks;
using Qmmands;
using Volte.Extensions;

namespace Volte.Commands.Preconditions
{
    public class RequireGuildModeratorAttribute : CheckBaseAttribute
    {
        public override async Task<CheckResult> CheckAsync(ICommandContext context, IServiceProvider provider)
        {
            var ctx = (VolteContext) context;
            if (ctx.User.IsModerator()) return CheckResult.Successful;

            await ctx.ReactFailureAsync();
            return CheckResult.Unsuccessful("Insufficient permission.");

        }
    }
}