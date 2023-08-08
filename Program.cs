var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//ImageService.MoveImage("0ac149ca9b7b1478dd05b8e88d382f09.jpg");

// Получаю все картинки
app.MapGet("/allImage", () => ImageService.GetAllImages());

// Удаляю картинку по имени
app.MapDelete("removeImage/{path}", (string path) => ImageService.RemoveImage(path));

// Перемещаю картинку в другую директорию
app.MapPost("/moveImage", (string sourcePath) =>
{
    ImageService.MoveImage(sourcePath);

    // Возвращаем успешный результат клиенту
    return Results.Ok(new { Message = "Фотография успешно перемещена." });
});


// Запускаю приложение
app.Run();

