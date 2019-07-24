﻿using System.Threading.Tasks;
using Qmmands;
using Volte.Commands.Checks;
using Volte.Commands.Results;

namespace Volte.Commands.Modules
{
    public partial class BotOwnerModule : VolteModule
    {
        [Command("SetGame")]
        [Description("Sets the bot's game (presence).")]
        [Remarks("Usage: |prefix|setgame {game}")]
        [RequireBotOwner]
        public async Task<ActionResult> SetGameAsync([Remainder] string game)
        {
            await Context.Client.SetGameAsync(game);
            return Ok($"Set the bot's game to **{game}**.");
        }
    }
}