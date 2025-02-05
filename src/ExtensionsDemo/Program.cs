// See https://aka.ms/new-console-template for more information
using Kuchulem.DotNet.Extensions;

Console.WriteLine("Enter the string from witch we will remove diacritics");
var input = Console.ReadLine();
var result = input?.RemoveDiacritics() ?? string.Empty;
Console.WriteLine(string.Format("Input: {0}", input));
Console.WriteLine(string.Format("Result: {0}", result));
