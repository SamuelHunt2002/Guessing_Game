using NSubstitute;

namespace Guessing_Game
{

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void testWordChooserContainsADictionary()
        {
            WordChooser wordchooser = new WordChooser();
            Assert.IsNotEmpty(wordchooser.GetRandomWordFromDictionary());
        }


        [Test]
        public void testGuessLetter()
        {
            Game game = new Game();
            game.targetWord = "Test";
            Assert.IsTrue(game.GuessLetter('e'));
            Assert.IsFalse(game.GuessLetter('u'));
        }

        [Test]
        public void testGetsMutatedLetter()
        {
            Game game = new Game();
            game.targetWord = "Test";
            Assert.AreEqual("T___", game.GetTargetWord(game.targetWord));
        }

        [Test]
        public void testWrongGuessLowersCounter()
        {
            Game game = new Game();
            Assert.AreEqual(10, game.counter);
            game.targetWord = "Test";
            game.GuessLetter('p');
            Assert.AreEqual(9, game.counter);

        }

        [Test]
        public void testCorrectResponseAddsWordToList()
        {
            Game game = new Game();
            game.targetWord = "Test";
            game.GuessLetter('e');
            Assert.Contains('e', game.guessList);
        }

        [Test]
        public void testCorrectResponseAddsMultipleWordsToList()
        {
            Game game = new Game();
            game.targetWord = "Test";
            game.GuessLetter('e');
            game.GuessLetter('s');
            Assert.Contains('e', game.guessList);
            Assert.Contains('s', game.guessList);
        }

        [Test]
        public void testIncorrectLetterNotAddedToGuessList()
        {
            Game game = new Game();
            game.targetWord = "Test";
            game.GuessLetter('q');
            Assert.IsEmpty(game.guessList);
        }

        [Test]
        public void testCorrectGuessWillAffectTheOutputtedStringThisIsAShitTestName()
        {
            Game game = new Game();
            game.targetWord = "Test";
            Assert.AreEqual("T___", game.GetTargetWord(game.targetWord));
            game.GuessLetter('e');
            Assert.AreEqual("Te__", game.GetTargetWord(game.targetWord));
            game.GuessLetter('t');
            Assert.AreEqual("Te_t", game.GetTargetWord(game.targetWord));
            game.GuessLetter('q');
            Assert.AreEqual("Te_t", game.GetTargetWord(game.targetWord));
            Assert.AreEqual(9, game.counter);


        }

        [Test]
        public void testCorrectGuessWillAffectTheOutputtedStringButWithMultipleInstancesOfTheSameLetter()
        {
            Game game = new Game();
            game.targetWord = "Teset";
            Assert.AreEqual("T____", game.GetTargetWord(game.targetWord));
            game.GuessLetter('e');
            Assert.AreEqual("Te_e_", game.GetTargetWord(game.targetWord));
            Assert.AreEqual(10, game.counter);
        }

    }

}
