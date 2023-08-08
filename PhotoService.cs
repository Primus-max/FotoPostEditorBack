
public class ImageService
{
    static List<string> _photos = new List<string>();

    public ImageService()
    {


    }

    public static List<string> GetAllImages()
    {
        // ���� �� ���� ���������
        var imageDirectory = @"Z:\Images";

        // �������� ���������� ���������� ��� ���������
        var extensions = new string[] { "*.jpg", "*.png", "*.gif", "*.bmp", "*.jpeg" };

        // ��������� ������������� ���������� ����� ���������� ������
        if (Directory.Exists(imageDirectory))
        {
            // ������� ��� ��������
            _photos = extensions.SelectMany(ext => Directory.EnumerateFiles(imageDirectory, ext)).ToList();
        }

        Console.WriteLine("��� ������, ����� ��� ��������");

        return _photos;
    }

    public static void RemoveImage(string imageName)
    {
        // �������� ������ ���� �����������
        var photos = GetAllImages();

        // ����� ���������� �� �����
        var imageFilePath = photos.FirstOrDefault(photo => Path.GetFileName(photo) == imageName);

        if (imageFilePath != null)
        {
            // �������� �����
            File.Delete(imageFilePath);
            Console.WriteLine($"���� {imageName} ������� �������.");
        }
        else
        {
            Console.WriteLine($"���� {imageName} �� �������.");
        }
    }


    public static void MoveImage(string imageName)
    {
        // ���������� ����������, ���� �� ����� ����������� ����
        string destinationDirectory = @"Z:\Images\ForPosting";

        // ��������� ���� � ������ ����� � ���������� ����������
        string destinationPath = Path.Combine(destinationDirectory, imageName);

        try
        {
            // �������� ������ ���� �����������
            var photos = GetAllImages();

            // ����� ���������� �� �����
            var imageFilePath = photos.FirstOrDefault(photo => Path.GetFileName(photo) == imageName);

            if (imageFilePath == null)
            {
                Console.WriteLine("���� �� ������.", imageName);
            }

            // ���������� ���� � ����� ����������
            File.Move(imageFilePath, destinationPath);

            // ���������� �������� ��������� �������
            Console.WriteLine("���������� ������� ����������.");
        }
        catch (Exception ex)
        {
            // ���������� ������, ���� �������� ������ �������� � ������������ �����
            Console.WriteLine($"������ ��� ����������� ����������: {ex.Message}");
        }
    }


}