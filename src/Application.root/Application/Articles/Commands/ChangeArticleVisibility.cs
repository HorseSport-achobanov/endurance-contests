﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EnduranceContestManager.Application.Core.Handlers;
using EnduranceContestManager.Application.Interfaces.Blog.Articles;
using EnduranceContestManager.Core.Interfaces;

namespace EnduranceContestManager.Application.Articles.Commands
{
    public class ChangeArticleVisibility : IRequest
    {
        public int Id { get; set; }

        public class ChangeArticleVisibilityHandler : Handler<ChangeArticleVisibility>
        {
            private readonly IArticleCommands commands;

            public ChangeArticleVisibilityHandler(IArticleCommands commands, IDateTimeService dateTime)
            {
                this.commands = commands;
                this.DateTimeService = dateTime;
            }

            public IDateTimeService DateTimeService { get; }

            protected override async Task Handle(
                ChangeArticleVisibility request,
                CancellationToken cancellationToken)
            {
                var article = await this.commands.Find(request.Id);
                if (article == null)
                {
                    return;
                }

                article.IsPublic = !article.IsPublic;
                article.PublishedOn ??= this.DateTimeService.Now;

                await this.commands.Save(article, cancellationToken);
            }
        }
    }
}
