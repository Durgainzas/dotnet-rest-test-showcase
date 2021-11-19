using System.Collections.Generic;
using Tests.Helpers;
using Tests.Models;
using Xunit;
using FluentAssertions;
using Tests;
using Tests.Enums;

namespace dotnet_rest_test_showcase
{
    public class TestClass
    {
        ApiHelper apiHelper;
        private List<LogicalServer> logicalServerList;
        
        public TestClass()
        {
            apiHelper = new ApiHelper();
            logicalServerList = apiHelper.GetVPNServerResponse();
        }

        [Fact]
        public void TestResponseValidation_Expect_DataAreValid()
        {
            Assert.All<LogicalServer>(logicalServerList, 
            Server => TestHelper.ValidateLogicalServerObject(Server));
        }

        [Fact]
        public void TestSecureCoreSErver_Expect_SecureCoreServerPresent()
        {
            var coreServers = logicalServerList.FindAll(ls => ls.Features == Features.SecureCoreServer);
            coreServers.Should().NotBeNullOrEmpty("There should be at least one CORE server present");
            coreServers.Find(ls => ls.Status == Status.On).Should().NotBeNull("At least one CORE server should be running");
        }

        [Fact]
        public void TestBasicServer_Expect_BasicServerPresent() 
        {
            var basicServers = logicalServerList.FindAll(ls => ls.Features == Features.BasicServer);
            basicServers.Should().NotBeNullOrEmpty("There should be at least one Basic server present");
            basicServers.Find(ls => ls.Status == Status.On).Should().NotBeNull("At least one Basic server should be running");
        }

        [Fact]
        public void TestFreeSErver_Expect_FreeServerPresent() 
        {
            var freeServers = logicalServerList.FindAll(ls => ls.Domain.Contains("-free"));
            freeServers.Should().NotBeNullOrEmpty("There should be at least one Basic server present");
            freeServers.Find(ls => ls.Status == Status.On).Should().NotBeNull("At least one Basic server should be running");
        }

        [Fact]
        public void TestServerLoad_Expect_LoadNotHigh()
        {
            Assert.All<LogicalServer>(logicalServerList, 
            Server => Server.Load.Should().BeLessThan(90, $"Server {Server.Name} Load should be in acceptable range"));
        }

    }
}
