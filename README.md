# RTP Video Streaming Server

This is a simple RTP video streaming server that uses VLC to stream a given video file over the network using RTP (Real-time Transport Protocol).

## Prerequisites
- **VLC Media Player** must be installed on the machine running the server.
  - Download and install VLC from: [https://www.videolan.org/vlc/](https://www.videolan.org/vlc/)
- **Windows Operating System** (Tested on Windows 10/11)
- **C# .NET Runtime** (if compiling the source code)

## Setup
1. **Ensure VLC is Installed**  
   Verify VLC installation by running:
   ```sh
   "C:\Program Files\VideoLAN\VLC\vlc.exe" --version
   ```
   If VLC is installed in a different location, update the `vlcPath` variable in the source code.

2. **Configure the Server**  
   Edit the following variables in the source code before running:
   - `videoPath`: Path to the video file to be streamed.
   - `rtpAddress`: IP address to stream to (default: `127.0.0.1`).
   - `rtpPort`: Port for RTP streaming (default: `5004`).

## Running the Server
### **Option 1: Executable File**
1. **Compile the Code (If Needed)**  
   If you have the source code, compile it using .NET:
   ```sh
   dotnet build -c Release
   ```
   The compiled `.exe` will be in `bin/Release/netX.X/` (depending on your .NET version).

2. **Run the Executable**  
   ```sh
   RTPServer.exe
   ```

### **Option 2: Running from Source Code**
1. Open a terminal (Command Prompt or PowerShell).
2. Navigate to the project directory.
3. Run the application:
   ```sh
   dotnet run
   ```

## Expected Output
Once running, the console should display:
```
Streaming D:\VlcVideoLibrary\video1.mp4 over RTP to 127.0.0.1:5004
Press Enter to stop streaming...
```
This means the server is streaming successfully.

## Stopping the Server
- **Press `Enter`** in the terminal to stop the stream.
- If running in the background, terminate the VLC process manually.

## Testing the Stream
To test the RTP stream, use VLC on the client side:
1. Open VLC Media Player.
2. Click **Media** > **Open Network Stream...**
3. Enter the network URL:
   ```
   rtp://@127.0.0.1:5004
   ```
4. Click **Play**.

If the video plays, the RTP stream is working.

## Troubleshooting
### **No Video on Client**
- Ensure VLC is installed and correctly set up.
- Verify the correct RTP address and port are used.
- Try a different video file format (e.g., `.mp4`, `.avi`).

### **VLC Closes Unexpectedly**
- Make sure the `--sout-keep` flag is included in the arguments.
- Run VLC manually with the same streaming command to check for errors.

### **Firewall Issues**
- If streaming over a network, allow VLC through the firewall:
  ```sh
  netsh advfirewall firewall add rule name="VLC RTP" dir=in action=allow protocol=UDP localport=5004
  ```
- Check router and firewall settings to ensure RTP traffic is not blocked.

## Notes
- The server currently supports only **one** video file per session.
- This implementation is for **local testing**; for network streaming, configure the correct IP address.
- You may need to adjust network buffer settings in VLC for smoother playback.

---
### **Author**
Developed by kirFish with great assistance of chat.openai 
Feel free to contribute or modify based on your needs!

