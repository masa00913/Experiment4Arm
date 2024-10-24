using System.IO;
using UnityEngine;

public class Screenshot
{
    public static void Capture(string path)
    {
        string directory = Path.GetDirectoryName(path);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("フォルダ作る");
        }

        string extension = Path.GetExtension(path).ToLower();

        Debug.Log("extension" + extension);
        switch (extension)
        {
            case ".jpg":
            case ".jpeg":
                File.WriteAllBytes(path, ScreenCapture.CaptureScreenshotAsTexture().EncodeToJPG());
                break;
            case ".png":
                ScreenCapture.CaptureScreenshot(path);
                break;
            case ".tga":
                File.WriteAllBytes(path, ScreenCapture.CaptureScreenshotAsTexture().EncodeToTGA());
                break;
        }
        Debug.Log(directory + extension + "保存した");
    }
}