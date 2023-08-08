
public class ImageService
{
    static List<string> _photos = new List<string>();

    public ImageService()
    {


    }

    public static List<string> GetAllImages()
    {
        // Путь ко всем картинкам
        var imageDirectory = @"Z:\Images";

        // Указываю допустимые расширения для картнинок
        var extensions = new string[] { "*.jpg", "*.png", "*.gif", "*.bmp", "*.jpeg" };

        // Проверяем существование директории перед получением файлов
        if (Directory.Exists(imageDirectory))
        {
            // Получаю все картинки
            _photos = extensions.SelectMany(ext => Directory.EnumerateFiles(imageDirectory, ext)).ToList();
        }

        Console.WriteLine("Был запрос, отдал все картинки");

        return _photos;
    }

    public static void RemoveImage(string imageName)
    {
        // Получаем список всех изображений
        var photos = GetAllImages();

        // Поиск фотографии по имени
        var imageFilePath = photos.FirstOrDefault(photo => Path.GetFileName(photo) == imageName);

        if (imageFilePath != null)
        {
            // Удаление файла
            File.Delete(imageFilePath);
            Console.WriteLine($"Фото {imageName} успешно удалено.");
        }
        else
        {
            Console.WriteLine($"Фото {imageName} не найдено.");
        }
    }


    public static void MoveImage(string imageName)
    {
        // Директория назначения, куда мы хотим переместить файл
        string destinationDirectory = @"Z:\Images\ForPosting";

        // Формируем путь к новому файлу в директории назначения
        string destinationPath = Path.Combine(destinationDirectory, imageName);

        try
        {
            // Получаем список всех изображений
            var photos = GetAllImages();

            // Поиск фотографии по имени
            var imageFilePath = photos.FirstOrDefault(photo => Path.GetFileName(photo) == imageName);

            if (imageFilePath == null)
            {
                Console.WriteLine("Файл не найден.", imageName);
            }

            // Перемещаем файл в новую директорию
            File.Move(imageFilePath, destinationPath);

            // Возвращаем успешный результат клиенту
            Console.WriteLine("Фотография успешно перемещена.");
        }
        catch (Exception ex)
        {
            // Возвращаем ошибку, если возникли другие проблемы с перемещением файла
            Console.WriteLine($"Ошибка при перемещении фотографии: {ex.Message}");
        }
    }


}