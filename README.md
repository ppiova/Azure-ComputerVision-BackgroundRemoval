## Azure Computer Vision Background Removal and Foreground Matting - (version 4.0 preview)

This repository contains a C# program that uses the Azure Computer Vision API to remove backgrounds or apply foreground matting to images.

## Prerequisites

1. An Azure account with an active subscription.
2. A Computer Vision resource created in the Azure portal.
3. Your Computer Vision API key and endpoint.
4. .NET 5.0 or higher installed on your system.

## Usage

1. Clone this repository and navigate to its directory.
2. Set the following environment variables with your Computer Vision API key and endpoint:
   - `COMPUTER_VISION_SUBSCRIPTION_KEY`
   - `COMPUTER_VISION_ENDPOINT`
3. Update the `InputFolder` and `OutputFolder` variables in the `Program.cs` file with the appropriate input and output folder paths on your system.
4. Build and run the program.
5. Select the desired operation: (1) Remove Background or (2) Foreground Matting.
6. The program will process all valid images in the input folder and save the results in the output folder.

## Code Overview

- `Program.cs`: Contains the main program logic, user input handling, and image processing using the Azure Computer Vision API. 
  Link API: https://centraluseuap.dev.cognitive.microsoft.com/docs/services/unified-vision-apis-public-preview-2023-02-01-preview/operations/63e6b6d9217d201194bbecbd
- `ProcessImageAsync()`: An async function that sends an image to the Azure Computer Vision API and saves the processed image to the specified output folder.
- `IsValidImage()`: A helper function that checks if a file is a valid JPEG or PNG image using the `System.Drawing.Image` class.

## 
![Example image](https://github.com/ppiova/Azure-ComputerVision-BackgroundRemoval/blob/main/readmeImages/CSharpCode.png "Code")
![Example image](https://github.com/ppiova/Azure-ComputerVision-BackgroundRemoval/blob/main/readmeImages/FolderInPut.png "FolderInput")
![Example image](https://github.com/ppiova/Azure-ComputerVision-BackgroundRemoval/blob/main/readmeImages/Console-Result.png "Console")
![Example image](https://github.com/ppiova/Azure-ComputerVision-BackgroundRemoval/blob/main/readmeImages/FolderOutPut.png "FolderOutput")

## Official Microsoft Learn Documentation
Link: https://bit.ly/computervisionbackgroundremoval

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
