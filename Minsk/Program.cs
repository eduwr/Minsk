// See https://aka.ms/new-console-template for more information
using Minsk.Lexer;

Console.WriteLine("Hello, Minsk Compiler!");


while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();
    if (string.IsNullOrEmpty(line)) return;

    var lexer = new Lexer(line);
    while (true)
    {
        var token = lexer.NextToken();
        if (token.Kind == SyntaxKind.EnfOfFileToken) break;

        Console.WriteLine($"{token.Kind}: '{token.Text}'");
        if (token.Value != null)
            Console.Write($" {token.Value}");

        Console.WriteLine();
    }

}