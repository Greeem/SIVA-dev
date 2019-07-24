﻿using System.Threading.Tasks;
using Discord.WebSocket;
using Qmmands;
using Volte.Commands.Checks;
using Volte.Commands.Results;

namespace Volte.Commands.Modules
{
    public partial class AdminModule : VolteModule
    {
        [Command("AdminRole")]
        [Description("Sets the role able to use Admin commands for the current guild.")]
        [Remarks("Usage: |prefix|adminrole {role}")]
        [RequireGuildAdmin]
        public Task<ActionResult> AdminRoleAsync([Remainder] SocketRole role)
        {
            var data = Db.GetData(Context.Guild);
            data.Configuration.Moderation.AdminRole = role.Id;
            Db.UpdateData(data);
            return Ok($"Set **{role.Name}** as the Admin role for this server.");
        }
    }
}