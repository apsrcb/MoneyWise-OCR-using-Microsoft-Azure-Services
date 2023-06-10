# ImageToTextDemo
Reading text from images is getting easier these days. With special software it's fairly easy. This repository shows you how to convert image to text with Azure Computer Vision and C#.

Follow the complete tutorial at [https://kenslearningcurve.com/tutorials/azure-computer-vision-convert-image-to-text-with-azure/](https://kenslearningcurve.com/tutorials/azure-computer-vision-convert-image-to-text-with-azure/)

# How it works

Create a Computer Vision resource in Azure Cloud. Get the subscription key and endpoint. Enter those in the ReceiptReader.cs, lines 9 and 10.

Start the console application with an argument. This argument needs to be a path to an image with text. You can use the images in the test-project, which is included in the solution.

> ReceiptReaderDemo.exe "c:\some\path\to\an_image.jpg"

The text that is in the image should appear.


