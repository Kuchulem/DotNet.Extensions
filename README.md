# Kuchulem.DotNet.Extensions

![UnitTests](https://github.com/Kuchulem/DotNet.Extensions/workflows/UnitTests/badge.svg)

Various extension methods for DotNet standard


# How to install

Choose the method you prefere.

## Kuchulem.DotNet.Extensions.IEnumerable

### Package Manager

```sh
Install-Package Kuschulem.DotNet.Extensions.IEnumerables -Version 1.0.0.1
```

### .Net CLI

```sh
dotnet add package Kuschulem.DotNet.Extensions.IEnumerables --version 1.0.0.1
```

### Package reference

```xml
<PackageReference Include="Kuschulem.DotNet.Extensions.IEnumerables" Version="1.0.0.1" />
```

### Paket CLI

```sh
paket add Kuschulem.DotNet.Extensions.IEnumerables --version 1.0.0.1
```

## Kuchulem.DotNet.Extensions.String

### Package Manager

```sh
Install-Package Kuschulem.DotNet.Extensions.Strings -Version 1.0.0.1
```

### .Net CLI

```sh
dotnet add package Kuschulem.DotNet.Extensions.Strings --version 1.0.0.1
```

### Package reference

```xml
<PackageReference Include="Kuschulem.DotNet.Extensions.Strings" Version="1.0.0.1" />
```

### Paket CLI

```sh
paket add Kuschulem.DotNet.Extensions.Strings --version 1.0.0.1
```

# Documentation

coming soon

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
