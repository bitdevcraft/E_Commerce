using Application.Models;

namespace UnitTest.Application.Model
{
    public class ModelTest
    {
        public ModelTest() { }

        [Fact]
        public async void ListHandlerTest()
        {
            // Arrange
            var context = await Mock.MockData.SetupContext();

            var handler = new List.Handler(context);
            var request = new List.Query();

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(3, result.Value.Count);
        }
    }
}
