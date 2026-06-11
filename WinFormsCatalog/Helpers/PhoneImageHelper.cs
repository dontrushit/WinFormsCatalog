using System.Drawing;
using WinFormsCatalog.Models;

namespace WinFormsCatalog.Helpers;

public static class PhoneImageHelper
{
    private const string PlaceholderFileName = "placeholder.png";

    public static void Load(PictureBox box, Phone phone)
    {
        box.Image?.Dispose();
        box.Image = null;

        string dataRoot = Path.Combine(Application.StartupPath, "Data");
        string dataImages = Path.Combine(dataRoot, "Images");
        string fileName = !string.IsNullOrWhiteSpace(phone.ImageUrl) ? phone.ImageUrl.Trim() : $"{phone.Id}.jpg";
        string baseName = Path.GetFileNameWithoutExtension(fileName);
        string[] paths =
        {
            Path.Combine(dataRoot, baseName + ".jpg"),
            Path.Combine(dataRoot, baseName + ".png"),
            Path.Combine(dataImages, baseName + ".jpg"),
            Path.Combine(dataImages, baseName + ".png")
        };

        foreach (string path in paths)
        {
            if (TryLoadImage(path, out var image))
            {
                box.Image = image;
                return;
            }
        }

        string placeholderPath = Path.Combine(dataRoot, PlaceholderFileName);
        if (TryLoadImage(placeholderPath, out var placeholder))
            box.Image = placeholder;
    }

    private static bool TryLoadImage(string path, out Image? image)
    {
        image = null;
        if (!File.Exists(path))
            return false;

        try
        {
            using var loaded = Image.FromFile(path);
            image = (Image)loaded.Clone();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
