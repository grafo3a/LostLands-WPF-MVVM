using LostLands22WPF.Models;
using System;
using System.Windows;

namespace LostLands22WPF.ViewModels;


internal class Gamelogic
{
    public ILostDictionary lostDictionary { get; set; } = new LostDictionaryArrayImple();

    public int RoundNumber { get; set; } = 0;
    public int PlayerPoints { get; set; } = 0;
    public int PlayedGamesNumber { get; set; } = 0;
    public int MaxNumberOfGames { get; set; } = 0;

    public GameDisplay DisplayObject { get; set; } = new GameDisplay();
    public string RandomWord { get; set; } = "";
    public string MaskedRandomWord { get; set; } = "";
    public string GuessedWord { get; set; } = "";
    public string[] GuessedWordAsArray { get; set; } = Array.Empty<string>();


    public void ProcessGame(string playedCharacter)
    {
        PlayedGamesNumber++;
        RandomWord = RandomWord.ToUpper();

        int randomWordLength = RandomWord.Length;
        MaxNumberOfGames = randomWordLength * 2;

        if (String.IsNullOrEmpty(playedCharacter))
        {
            playedCharacter = "Empty";        // additional security
        }
        else
        {
            playedCharacter = playedCharacter.ToUpper();
        }

        for (int k = 0; k < randomWordLength; k++)
        {
            if (Convert.ToString(RandomWord[k]) == playedCharacter)
            {
                GuessedWordAsArray[k] = playedCharacter;
            }
        }

        GuessedWord = ConvertArrayToString(GuessedWordAsArray);

        if (GuessedWord.Contains(playedCharacter))
        {
            DisplayComment($"\"{playedCharacter}\" is present!");
        }
        else
        {
            DisplayComment($"\"{playedCharacter}\" is absent!");
        }

        if (GuessedWord == RandomWord)
        {
            PlayerPoints++;
            PlayedGamesNumber = MaxNumberOfGames;

            MessageBox.Show($"Bravo!\nThe word is:\n\n{RandomWord}");
        }

        DisplayObject.UpdateGuessedWord(GuessedWord);
        UpdatePlayedGamesNumber(PlayedGamesNumber);

        if (PlayedGamesNumber == MaxNumberOfGames)
        {
            PlayedGamesNumber = 0;
            RoundNumber++;

            if (GuessedWord != RandomWord)
            {
                MessageBox.Show($"Sorry, you didn't find the word after {MaxNumberOfGames} games." +
                    $"\nThe lost word was:\n\n{RandomWord}");
            }
        }

        UpdateStats();
    }


    public void GenerateSetRandomWord()
    {
        RandomWord = lostDictionary.GetRandomWord();
    }


    public void UpdateMaxNumberOfGames()
    {
        MaxNumberOfGames = RandomWord.Length * 2;
    }


    public void MaskRandomWord()
    {
        SetGuessedWordAsArray();

        string newResultWord = "";

        foreach (string s in GuessedWordAsArray)
        {
            newResultWord += s;
        }

        MaskedRandomWord = newResultWord;
    }


    public void SetGuessedWordAsArray()
    {
        int randomWordLength = RandomWord.Length;

        GuessedWordAsArray = new string[randomWordLength];

        for (int i = 0; i < randomWordLength; i++)      //On peuple le tableau guessedWordAsArray
        {
            GuessedWordAsArray[i] = "*";
        }
    }


    public void InitializeGuessedWord()
    {
        GuessedWord = MaskedRandomWord;
        DisplayObject.UpdateGuessedWord(GuessedWord);
    }


    static string ConvertArrayToString(string[] guessedWordAsArray)
    {
        string newString = "";

        foreach (string s in guessedWordAsArray)
        {
            newString += s;
        }

        return newString;
    }


    public void GenerateSetMaskInitializeLostWord()
    {
        GenerateSetRandomWord();
        UpdateMaxNumberOfGames();
        MaskRandomWord();
        InitializeGuessedWord();
        SetGuessedWordAsArray();
    }


    public void UpdatePlayedGamesNumber(int playedGamesNumber)
    {
        DisplayObject.UpdatePlayedGamesNumber(playedGamesNumber, MaxNumberOfGames);
    }


    public void UpdateStats()
    {
        DisplayObject.UpdateStats(PlayerPoints, RoundNumber);
    }


    public void ResetStats()
    {
        RoundNumber = 0;
        PlayerPoints = 0;
    }


    public void DisplayComment(string comment)
    {
        DisplayObject.UpdateComment(comment);
    }
}
