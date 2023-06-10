using Xunit;
using ReceiptReaderDemo;

public class ReceiptReaderTests
{
    [Theory]
    [InlineData("Images/Receipt1.jpg", "Rp197.200")]
        [InlineData("Images/srisai.jpg", "Rp279")]
    [InlineData("Images/klm.jpg", "Rp1000")]
    [InlineData("Images/Dmart.jpg", "Rp5992.71")]
    [InlineData("Images/zudio.jpg", "Rp4780")]

    public async Task Should_ReadReceipt(string image, string expected)
    {
        ReceiptReader reader = new ReceiptReader();
        string result = await reader.Read(image);

        Assert.Contains(expected, result);
    }
}
