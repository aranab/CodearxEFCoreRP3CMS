using CodearxEFCoreRP3CMS.Areas.Admin.Pages.Posts;
using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using Xunit;

namespace Tests.Admin.PageModels
{
    public class PostPageModelsTests
    {
        [Fact]
        public async Task EditModel_GetRequestSendsPostToPage()
        {
            // Arrange
            var id = "test-post";
            var repo = Mock.Create<IPostRepository>();
            var pageModel = new EditModel(repo);

            // Act
            await pageModel.OnGetAsync(id);

            // Assert
            var result = Assert.IsAssignableFrom<Post>(pageModel.Post);
            Assert.Equal(id, result.ID);
        }
    }
}
