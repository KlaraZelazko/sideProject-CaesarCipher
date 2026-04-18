var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/encrypt", (CipherRequest request) =>
{
    var service = new CaesarService();
    var result = service.Encrypt(request.Message, request.Shift);
    return Results.Ok(result);
});

app.MapFallbackToFile("index.html");

app.Run();


// -------- DTO --------
public class CipherRequest
{
    public string Message { get; set; } = "";
    public int Shift { get; set; }
}


// -------- LOGIKA --------
public class CaesarService
{
    private char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public string Encrypt(string message, int shift)
    {
        char[] msgArray = message.ToCharArray();
        char[] encryptedMessage = new char[msgArray.Length];

        for (int i = 0; i < msgArray.Length; i++)
        {
            char currentChar = msgArray[i];
            char lowerChar = char.ToLower(currentChar);

            int index = Array.IndexOf(alphabet, lowerChar);
            if (index == -1)
            {
                encryptedMessage[i] = currentChar;
                continue;
            }

            int shiftedIndex = (index + shift) % 26;
            encryptedMessage[i] = alphabet[shiftedIndex];
        }

        return new string(encryptedMessage);
    }
}