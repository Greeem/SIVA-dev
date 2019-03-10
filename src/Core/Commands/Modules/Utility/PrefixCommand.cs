﻿using System.Threading.Tasks;
using Qmmands;
using Volte.Core.Extensions;

namespace Volte.Core.Commands.Modules.Utility
{
    public partial class UtilityModule : VolteModule
    {
        [Command("Prefix")]
        [Description("Shows the command prefix for this guild.")]
        [Remarks("Usage: |prefix|prefix")]
        public async Task PrefixAsync()
        {
            await Context.CreateEmbed($"The prefix for this server is **{Db.GetConfig(Context.Guild).CommandPrefix}**.")
                .SendToAsync(Context.Channel);
        }
    }
}