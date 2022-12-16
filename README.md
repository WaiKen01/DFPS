# Digital File Protection System (DFPS)

DFPS is a software that secure digital file through various method such as encryption and steganography and it is built to run on Windows environment.

## For developers
Developers are welcome to refer, download and modify this system as it is an open source software. This system is developed using Windows Forms of .NET framework.

### To modify/continue development
1. Download this project.
2. Use Visual Studio to open the DFPS.sln as a project.
3. Modify the code.

## For users
Users are welcome to download this system and use it for your own benefit. 

### Steps to download and use this system
1. Download the .NETcoreapp folder from this 
2. Locate the downloaded folder
3. Double click on the DFPS.exe
4. Allow to run (If prompted)

All the file encrypted, hidden and commpressed using this system can only be decrypt, extract, decompress using the same system. **Encrypted file, compressed file and stego file from other system would not work in this system and vice versa**

| Function | Usage recommendations |
| --- | --- |
| File encryption | All files are allowed **except .aes**. |
| File decryption | Only file with **.aes** is able to be decrypted. |
| File steganography | Video file, Image file, Audio file are allowed as **cover file** such as **.mp4, .mov, .pdf, .gif, .bmp, .jpg, .jpeg, .png, .mp3, .wav** while there are no restriction on the secret file type. |
| File extraction | Only file **with embedded content** and provided the correct password would be extracted successfully. |
| File compression | **Most efficient** file type : .txt, **Least efficient** file type : video files, image files, audio files |
| File decompression | Only file with **.dfl** can be selected |
