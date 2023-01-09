# Digital File Protection System (DFPS)

DFPS is a software that secure digital file through various method such as encryption and steganography and it is built to run on Windows environment.

## For developers
Developers are welcome to refer, download and modify this system as it is an open source software. This system is developed using Windows Forms of .NET framework.

### To modify/continue development
1. Download and install Visual Studio 2019 or newer version.
2. Install .NET Desktop Development workload in Visual Studio. If the machine already has installed Visual Studio, user could install NET Desktop Development workload through Visual Studio Installer.
3. Access to the remote repository at https://github.com/WaiKen01/DFPS.
4. Click on the green color Code button.
5. Click to Download Zip.
6. Locate the downloaded zip file in local directory.
7. Extract the whole content from the downloaded zip.
8. Launch installed version of Visual Studio.
9. Select open a project or solution.
10. Locate the extracted file from downloaded zip.
11. Select DFPS.sln and click open.
12. Wait for the project to be opened and the source code could be modified.

## For users
Users are welcome to download this system and use it for your own benefit. 

### Steps to download and use this system
1. Access to the remote repository at https://github.com/WaiKen01/DFPS_App.
2. Click on the green color Code button
3. Click Download Zip
4. Locate the downloaded zip file
5. Extract all the content from the zip file
6. Download .NET Core 3.1 at https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-3.1.32-windows-x64-installer?cid=getdotnetcore
7. Run the downloaded installer
8. Locate DFPS.exe from the extracted file
9. Double click on the DFPS.exe
10. Allow the file to run if prompted warning by Windows
11. Digital File Protection System window will pop up and user can start interacting with it.

All the file encrypted, hidden and commpressed using this system can only be decrypt, extract, decompress using the same system. **Encrypted file, compressed file and stego file from other system would not work in this system and vice versa**

| Function | Usage recommendations |
| --- | --- |
| File encryption | All files are allowed **except .aes**. |
| File decryption | Only file with **.aes** is able to be decrypted. |
| File steganography | Video file, Image file, Audio file are allowed as **cover file** such as **.mp4, .mov, .pdf, .gif, .bmp, .jpg, .jpeg, .png, .mp3, .wav** while there are no restriction on the secret file type. |
| File extraction | Only file **with embedded content** and provided the correct password would be extracted successfully. |
| File compression | **Most efficient** file type : .txt, **Least efficient** file type : video files, image files, audio files |
| File decompression | Only file with **.dfl** can be selected |
