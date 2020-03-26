using CodearxEFCoreRP3CMS.Areas.Admin.Pages.Posts;
using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            Mock.Arrange(() => repo.Get(id)).Returns(Task.FromResult(new Post { ID = id}));

            // Act
            await pageModel.OnGetAsync(id);

            // Assert
            var result = Assert.IsAssignableFrom<Post>(pageModel.Post);
            Assert.Equal(id, result.ID);
        }

        [Fact]
        public async Task EditModel_GetRequestNotFoundResult()
        {
            // Arrange
            var id = "test-post";
            var repo = Mock.Create<IPostRepository>();
            var pageModel = new EditModel(repo);

            Mock.Arrange(() => repo.Get(id)).Returns(Task.FromResult((Post)null));

            // Act
            var result = await pageModel.OnGetAsync(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditModel_PostRequestNotFoundResult()
        {
            // Arrange
            var id = "test-post";
            var repo = Mock.Create<IPostRepository>();
            var pageModel = new EditModel(repo);

            Mock.Arrange(() => repo.Get(id)).Returns(Task.FromResult((Post)null));

            // Act
            var result = await pageModel.OnPostAsync(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditModel_PostRequestSendsPostToPage()
        {
            // Arrange
            var id = "test-post";
            var repo = Mock.Create<IPostRepository>();
            var pageModel = new EditModel(repo);

            Mock.Arrange(() => repo.Get(id)).Returns(Task.FromResult(new Post { ID = id }));
            pageModel.ModelState.AddModelError("key", "error message");

            // Act
            var result = await pageModel.OnPostAsync(id);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task EditModel_PostRequestCallsEditAndRedirects()
        {
            // Arrange 
            var repo = Mock.Create<IPostRepository>();
            var pageModel = new EditModel(repo);

            Mock.Arrange(() => repo.Edit(Arg.IsAny<string>(), Arg.IsAny<Post>())).MustBeCalled();

            // Act
            var result = await pageModel.OnPostAsync("foo");

            // Assert
            Mock.Assert(repo);
            Assert.IsType<RedirectToPageResult>(result);
        }
    }
}
