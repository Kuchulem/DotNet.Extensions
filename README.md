# Kuchulem.DotNet.Extensions

[![NuGet Version](https://img.shields.io/nuget/v/Kuchulem.DotNet.Extensions?label=Nuget%20version&logo=nuget)](https://www.nuget.org/packages/Kuchulem.DotNet.Extensions/)

[![Unit tests](https://github.com/Kuchulem/DotNet.Extensions/actions/workflows/tests.yml/badge.svg?branch=main)](https://github.com/Kuchulem/DotNet.Extensions/actions/workflows/tests.yml) [![CodeQL](https://github.com/Kuchulem/DotNet.Extensions/actions/workflows/codeql.yml/badge.svg?branch=main)](https://github.com/Kuchulem/DotNet.Extensions/actions/workflows/codeql.yml)

Various extension methods for .net8

# How to install

Choose the method you prefer.

## Package Manager

```sh
Install-Package Kuchulem.DotNet.Extensions -Version 3.0.0
```

## .Net CLI

```sh
dotnet add package Kuchulem.DotNet.Extensions --version 3.0.0
```

## Package reference

```xml
<PackageReference Include="Kuchulem.DotNet.Extensions" Version="3.0.0" />
```

## Paket CLI

```sh
paket add Kuchulem.DotNet.Extensions --version 2.0.0
```

# Usage

## IEnumerable.ForEach

Applies an action to all element of the enumerable.

```csharp
// Lets initialize a random byte array
var input = new byte[100];
var randomizer = new Random();
randomizer.NextBytes(input);
// Use the .ForEach extension method to apply an action to all elements
input.ForEach(b => Console.WriteLine($"Got value {b}"));
```

## String.ToChunks

Splits a string in chunks of the same size. Can preserve words.

```csharp
var input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce dictum dictum orci, et placerat quam egestas vitae. Duis sed nisi.";

// split in chunks of 20 characters
var chunks = input.ToChunks(20);
// Split in chunks of 20 characters, preserve words
var chunksWholeWords = input.ToChunks(20, true);
```

## String.RemoveDiacritics

Removes diacritics (accents) from characters

```csharp
var input = "Rédaction d'une chaîne de charactères accentuée";
var result = input.RemoveDiacritics();
// result = "Redaction d'une chaine de characteres accentuee";
```

## String.ToSlug

Converts a string to a slug (a string that can be used as-is in urls, without url encoding)

```csharp
var input = "Rédaction d'une chaîne de charactères accentuée !";
var result = input.ToSlug();
// result = "redaction-d-une-chaine-de-characteres-accentuee--";
```
