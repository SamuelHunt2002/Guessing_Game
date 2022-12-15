using System;
using System.Text;

namespace Guessing_Game
{
    public class Game
    {
        public string targetWord { get; set; }
        public int counter { get; set; }

        public List<char> guessList { get; set; }

        public string mutatedTargetWord { get; set; }

        // Constructor
        public Game()
        {
            counter = 10;
            guessList = new List<char>();
            targetWord = "";
            mutatedTargetWord = "";
        }

        public int GetCounter()
        {
            return counter;
        }

        public string GetTargetWord(string funcTargetWord)
        {

            StringBuilder output = new StringBuilder(funcTargetWord[0].ToString());
            // Add _ characters to the StringBuilder for the remaining letters in the input string
            output.Append('_', funcTargetWord.Length - 1);
            // Save the modified string in the targetWord property
            mutatedTargetWord = output.ToString();
            foreach (char letter in guessList)
            {
                // Check if the input string contains the current letter
                if (funcTargetWord.Contains(letter))
                {
                    // If the input string contains the letter, find the first
                    // occurrence of the letter in the input string
                    int index = funcTargetWord.IndexOf(letter);

                    // Use a while loop to find all occurrences of the letter
                    // in the input string and replace the corresponding
                    // characters in the output string
                    while (index >= 0)
                    {
                        // Replace the underscore at the same position in the
                        // output string with the matching letter from the
                        // input string
                        mutatedTargetWord = mutatedTargetWord.Substring(0, index) + letter + mutatedTargetWord.Substring(index + 1);

                        // Find the next occurrence of the letter in the input
                        // string, starting from the position after the current
                        // occurrence
                        index = funcTargetWord.IndexOf(letter, index + 1);
                    }
                }
            }
            return mutatedTargetWord;
        }



        public bool GuessLetter(char letter)
        {
            bool correctGuess = false;
            // Convert the letter and targetWord to lowercase
            char lowercaseLetter = char.ToLower(letter);
            string lowercaseTargetWord = this.targetWord.ToLower();

            // Check if the target word contains the guessed letter
            if (lowercaseTargetWord.Contains(lowercaseLetter))
            {
                correctGuess = true;
                this.guessList.Add(letter);

                // Call the GetTargetWord method to update the mutatedTargetWord property
                this.GetTargetWord(this.targetWord);
            }
            else
            {
                counter -= 1;
            }
            return correctGuess;
        }

        public bool isGameWonInProgressOrFalse() {
            if (this.mutatedTargetWord.Contains('_') && counter > 0) 
            {
                return false;
            }
            else return true; 
            
        }

    }



    public class WordChooser
    {

        private readonly string[] dictionary = new string[] { "MAKERS", "CANDIES", "DEVELOPER", "LONDON" };
        // Implement the GetRandomWordFromDictionary method
        public virtual string GetRandomWordFromDictionary()
        {
            // Create a new Random object
            Random rand = new Random();

            // Generate a random index between 0 and the length of the DICTIONARY array
            int index = rand.Next(0, dictionary.Length);

            // Return the word at the generated index
            string targetWord = dictionary[index];
            return targetWord;
        }
    }
}



