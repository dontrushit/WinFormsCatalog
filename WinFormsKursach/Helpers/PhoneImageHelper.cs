using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WinFormsKursach.Models;

namespace WinFormsKursach.Helpers
{
    public static class PhoneImageHelper
    {
        public static void Load(PictureBox box, Phones phone)
        {
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
                if (!File.Exists(path)) continue;
                try
                {
                    using var img = Image.FromFile(path);
                    box.Image = (Image)img.Clone();
                    break;
                }
                catch { }
            }
        }
    }
}
