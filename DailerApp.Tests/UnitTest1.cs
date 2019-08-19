using System;
using Xunit;
using DailerApp.Models;
using DailerApp.Services;

namespace DailerApp.Tests
{
    public class ServiceTests
    {
        [Fact]
        public void Test1()
        {
            IDbWriter<Trait> dbWriter = new DbWriterFake<Trait>();
            ITraitService traitService = new TraitService(dbWriter);
            var trait = traitService.CreateTrait("hello1", "this is my trait");
            Assert.True(trait.Title == "hello");
        }
    }
}
