﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Volte.Core.Utils;
using Volte.Core.Services;
using Qmmands;
using Volte.Core.Extensions;

namespace Volte.Core.Commands
{
    /// <inheritdoc />
    public sealed class VolteContext : ICommandContext
    {
        private readonly EmojiService _emojiService;

        public VolteContext(IDiscordClient client, IUserMessage msg, IServiceProvider provider)
        {
            _emojiService = provider.GetRequiredService<EmojiService>();
            Client = client as DiscordSocketClient;
            ServiceProvider = provider;
            Guild = (msg.Channel as ITextChannel)?.Guild;
            Channel = msg.Channel as ITextChannel;
            User = msg.Author as IGuildUser;
            Message = msg;
        }

        public DiscordSocketClient Client { get; }
        public IServiceProvider ServiceProvider { get; }
        public IGuild Guild { get; }
        public ITextChannel Channel { get; }
        public IGuildUser User { get; }
        public IUserMessage Message { get; }

        public Task ReactFailureAsync() => Message.AddReactionAsync(new Emoji(_emojiService.X));
        public Task ReactSuccessAsync() => Message.AddReactionAsync(new Emoji(_emojiService.BALLOT_BOX_WITH_CHECK));
        public Embed CreateEmbed(string content) => Util.CreateEmbed(this, content);
        public EmbedBuilder CreateEmbedBuilder(string content = null) => Util.CreateEmbed(this, content ?? "").ToEmbedBuilder();
        public Task ReplyAsync(string content) => Channel.SendMessageAsync(content);
        public Task ReplyAsync(Embed embed) => embed.SendToAsync(Channel);
        public Task ReplyAsync(EmbedBuilder embed) => embed.SendToAsync(Channel);
        public Task ReactAsync(string unicode) => Message.AddReactionAsync(new Emoji(unicode));
    }
}