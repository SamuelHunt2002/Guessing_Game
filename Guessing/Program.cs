namespace Guessing_Game;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        Game game = new Game();
        WordChooser wordChooser = new WordChooser();
        game.targetWord = wordChooser.GetRandomWordFromDictionary();
        game.mutatedTargetWord = game.GetTargetWord(game.targetWord);
        while (game.mutatedTargetWord.Contains('_') && game.counter > 0)
        {
            Console.WriteLine("");
            Console.WriteLine($"The target word is {game.GetTargetWord(game.mutatedTargetWord)}. You have {game.counter} guesses left");
            char guess = Console.ReadKey().KeyChar;
            guess = Char.ToUpper(guess);
            game.GuessLetter(guess);

        }

        if (game.mutatedTargetWord.Contains('_') && game.counter == 0)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"You ran out of guesses! The word was {game.targetWord}");
        }
        else if (!game.mutatedTargetWord.Contains('_'))
        {
            Console.WriteLine(" ");
            Console.WriteLine("You guessed correctly");
        }
    }
}