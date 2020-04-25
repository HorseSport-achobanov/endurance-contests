namespace Blog.Application.UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Application.Infrastructure.Interfaces;
    using AutoMapper;
    using Blog.Common.Mappings;
    using Gateways.Persistence;
    using Moq;
    using Xunit;

    public sealed class QueryTestFixture : IDisposable
    {
        public QueryTestFixture()
        {
            this.Context = ApplicationDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            this.Mapper = configurationProvider.CreateMapper();

            var identityMock = new Mock<IIdentity>();

            identityMock
                .Setup(i => i.GetUserName(It.IsAny<string>()))
                .Returns(Task.FromResult("Test User"));

            this.Identity = identityMock.Object;
        }

        public BlogDbContext Context { get; }

        public IMapper Mapper { get; }

        public IIdentity Identity { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}