using Challenges.challenges;

bool result = MatchPattern.Match("[([]])", new (char, char)[] { ('{', '}'), ('[', ']'), ('(', ')') });
Console.WriteLine(result);