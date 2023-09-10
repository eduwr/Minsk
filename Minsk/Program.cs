﻿// See https://aka.ms/new-console-template for more information
using Minsk.mc;

Console.WriteLine("Hello, Minsk Compiler!");


while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();
    if (string.IsNullOrEmpty(line)) return;


    var parser = new Parser(line);
    var expression = parser.Parse();

    var color = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.DarkGray;
    PrettyPrint(expression);
    Console.ForegroundColor = color;

       if (parser.Diagnostics.Any())
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;

        foreach(var diagnostic in parser.Diagnostics)
        {
            Console.WriteLine(diagnostic);
        }

        Console.ForegroundColor = color;
    }

}


void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
{
    var marker = isLast ? "└──" : "├──";

    Console.Write(indent);
    Console.Write(marker);
    Console.Write(node.Kind);
    if (node is SyntaxToken t && t.Value != null)
    {
        Console.Write(" ");
        Console.Write(t.Value);
    }

    Console.WriteLine();

    indent += isLast ? "    " : "│   ";


    var lastChild = node.GetChildren().LastOrDefault();

    foreach (var child in node.GetChildren())
    {
        PrettyPrint(child, indent, child == lastChild);
    }

}