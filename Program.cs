using System.Diagnostics;

class Program
{
    static void Main()
    {
        string vlcPath = @"C:\Program Files\VideoLAN\VLC\vlc.exe"; // Change if VLC is installed elsewhere
        string videoPath = @"D:\VlcVideoLibrary\video1.mp4"; // Change to your video file path
        string rtpAddress = "127.0.0.1"; // Target IP (localhost)
        int rtpPort = 5004; // RTP port

        // VLC command-line arguments for RTP streaming
        string arguments = $"\"{videoPath}\" --sout \"#rtp{{dst={rtpAddress},port={rtpPort},mux=ts}}\" --loop --sout-keep";

        try
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = vlcPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process vlcProcess = new Process { StartInfo = psi };
            vlcProcess.Start();

            Console.WriteLine($"Streaming {videoPath} over RTP to {rtpAddress}:{rtpPort}");
            Console.WriteLine("Press Enter to stop streaming...");
            Console.ReadLine();

            vlcProcess.Kill();
            vlcProcess.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error starting VLC: " + ex.Message);
        }
    }
}