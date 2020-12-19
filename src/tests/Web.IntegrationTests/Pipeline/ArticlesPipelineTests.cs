﻿using EnduranceContestManager.Application.Articles.Commands;
using EnduranceContestManager.Gateways.Persistence.Providers;
using EnduranceContestManager.Gateways.Web.Areas.Api;
using MyTested.AspNetCore.Mvc;
using Shouldly;
using System.Linq;
using Xunit;

namespace Blog.Web.IntegrationTests.Pipeline
{
    public class ArticlesPipelineTests
    {
        [Theory]
        [InlineData(1)]
        public void ChangeVisibilityShouldBeRoutedCorrectlyAndShouldReturnNoContent(int id)
            => MyPipeline
                .Configuration()
                .ShouldMap(request =>
                    request
                        .WithMethod(HttpMethod.Put)
                        .WithLocation("api/Articles/ChangeVisibility")
                        .WithJsonBody(new { Id = id }))
                .To<ArticlesController>(c => c
                    .ChangeVisibility(new ChangeArticleVisibility { Id = id }))
                .Which(controller =>
                    controller.WithData(data => data
                        .WithEntities<ContestDbContext>(TestData.Articles)))
                .ShouldHave()
                .Data(data => data
                    .WithEntities<ContestDbContext>(entities => entities
                        .Articles
                        .FirstOrDefault(a =>
                            a.Id == id && a.IsPublic)
                        .ShouldNotBeNull()))
                .AndAlso()
                .ShouldReturn()
                .NoContent();
    }
}
