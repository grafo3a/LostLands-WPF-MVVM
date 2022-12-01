using System;
using System.Windows;

namespace LostLands22WPF.Models;


public class LostDictionaryArrayImple : ILostDictionary
{
    public virtual string[] ListOfWords { get; } = { "none" };

    public string GetRandomWord()
    {
        string randomWord = "none";

        try
        {
            Random randomObject = new();
            int randomNumber = randomObject.Next(ListOfWords.Length);
            randomWord = ListOfWords[randomNumber];
        }
        catch (Exception ex)
        {
            MessageBox.Show($"ERROR!\nType: {ex.GetType}\nMessage: {ex.Message}");
        }

        return randomWord;
    }
}
