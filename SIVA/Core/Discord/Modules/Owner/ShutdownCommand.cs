﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using SIVA.Helpers;

namespace SIVA.Core.Discord.Modules.Owner {
    public class ShutdownCommand : SIVACommand {
        // I'm not sure how well this works.

        [Command("Shutdown")]
        public async Task Shutdown() {
            if (!UserUtils.IsBotOwner(Context.User)) {
                await Context.Message.AddReactionAsync(new Emoji("❌"));
                return;
            }

            await DiscordLogin.Client.LogoutAsync();
            await DiscordLogin.Client.StopAsync();
            Environment.Exit(0);
        }
    }
}