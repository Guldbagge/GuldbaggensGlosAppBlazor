using static GlosApp.Components.Pages.Home;

public class PhotoTests
{
    [Fact]
    public void Photo_UrlsProperty_ShouldBeSetAndGetCorrectly()
    {
        // Arrange
        var photo = new Photo();
        var expectedUrl = new PhotoUrls { regular = "https://example.com/image.jpg" };

        // Act
        photo.urls = expectedUrl;

        // Assert
        Assert.NotNull(photo.urls); 
        Assert.Equal(expectedUrl, photo.urls); 
        Assert.Equal(expectedUrl.regular, photo.urls?.regular); 
    }

    [Fact]
    public void Photo_UrlsProperty_ShouldBeNullByDefault()
    {
        // Arrange
        var photo = new Photo();

        // Act & Assert
        Assert.Null(photo.urls); 
    }

    [Fact]
    public void PhotoUrls_RegularProperty_ShouldBeSetAndGetCorrectly()
    {
        // Arrange
        var photoUrls = new PhotoUrls();
        var expectedRegularUrl = "https://example.com/image.jpg";

        // Act
        photoUrls.regular = expectedRegularUrl;

        // Assert
        Assert.Equal(expectedRegularUrl, photoUrls.regular); 
    }
    [Fact]
    public void PhotoUrls_RegularProperty_ShouldBeNullByDefault()
    {
        // Arrange
        var photoUrls = new PhotoUrls();

        // Act & Assert
        Assert.Null(photoUrls.regular); 
    }
}
