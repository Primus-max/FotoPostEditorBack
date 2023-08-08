var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//ImageService.MoveImage("0ac149ca9b7b1478dd05b8e88d382f09.jpg");

// ������� ��� ��������
app.MapGet("/allImage", () => ImageService.GetAllImages());

// ������ �������� �� �����
app.MapDelete("removeImage/{path}", (string path) => ImageService.RemoveImage(path));

// ��������� �������� � ������ ����������
app.MapPost("/moveImage", (string sourcePath) =>
{
    ImageService.MoveImage(sourcePath);

    // ���������� �������� ��������� �������
    return Results.Ok(new { Message = "���������� ������� ����������." });
});


// �������� ����������
app.Run();

