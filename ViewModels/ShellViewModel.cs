using Caliburn.Micro;
using LostLands22WPF.Models;
using LostLands22WPF.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace LostLands_WPF_MVVM.ViewModels;


public partial class ShellViewModel : Screen
{
    private static readonly string visibleVisibility = Visibility.Visible.ToString();
    private static readonly string hiddenVisibility = Visibility.Hidden.ToString();
    private static readonly string blackColor = Brushes.Black.ToString();
    private static readonly string letterPromptMessage = "Type 1 letter ->";
    private static readonly string defaultDictionary = "World_Countries";
    private readonly string[] languageList = { "World_Countries", "Europe_Cities", "USA_States" };       // Combobox options
    private readonly Gamelogic gameLogic = new();
    private readonly GameDisplay gameDisplay = new();        // Default = English

    // === PROPERTIES START ===
    private string _visibilityOfZone01 = visibleVisibility;
    private string _visibilityOfZone02 = hiddenVisibility;
    private string _visibilityOfZone03 = hiddenVisibility;
    private string _visibilityOfZone04 = hiddenVisibility;
    private string _visibilityOfZone05 = hiddenVisibility;
    private bool _isNextGamePlayable = false;
    private bool _isNextRoundReady = false;
    private bool _isGameEnabled = true;
    private string _labelGameNumber = String.Empty;
    private string _labelGameComments = String.Empty;
    private string _labelStats = String.Empty;
    private string _labelGuessedWord = String.Empty;
    private string _labelLetterPrompt = letterPromptMessage;
    private string _textboxTypedLetter = "0";      // Any-non-alphabetical character
    private string _commentColor = blackColor;
    private string _selectedString = defaultDictionary;     // CaliburnMicro naming convention: _selectedString
                                                            // (don't change the name!)
    // The content of ShellViewModel_Ext.cs was here
    //=== PROPERTIES END ===


    public void EnableOrResetGame(string action)
    {
        string newVisibility = hiddenVisibility;
        LabelGuessedWord = String.Empty;        // we reset the value
        LabelStats = String.Empty;
        LabelGameNumber = String.Empty;
        LabelLetterPrompt = String.Empty;
        LabelGameComments = String.Empty;
        IsNextRoundReady = false;

        if (action.ToLower() == "enable")
        {
            newVisibility = visibleVisibility;
        }

        VisibilityOfZone02 = newVisibility;
        VisibilityOfZone03 = newVisibility;

        if (newVisibility == visibleVisibility)
        {
            // We define the dictionary to be used
            if (GameDictionaryInfo.Contains("World_Countries"))
            {
                gameLogic.lostDictionary = new LostDictionaryArrayWorldCountries();
            }
            else if (GameDictionaryInfo.Contains("Europe_Cities"))
            {
                gameLogic.lostDictionary = new LostDictionaryArrayEuropeCities();
            }
            else if (GameDictionaryInfo.Contains("USA_States"))
            {
                gameLogic.lostDictionary = new LostDictionaryArrayUSAStates();
            }

            //The 1st time
            gameLogic.DisplayObject = gameDisplay;
            gameDisplay.ViewModel = this;

            gameLogic.ResetStats();
            gameLogic.UpdateStats();
            gameLogic.GenerateSetMaskInitializeLostWord();
            gameLogic.UpdatePlayedGamesNumber(0);

            LabelLetterPrompt = letterPromptMessage;
        }
    }


    public void ButtonConfirmLanguage()
    {
        VisibilityOfZone01 = hiddenVisibility;
        EnableOrResetGame("ENABLE");
    }


    public void ButtonPlay()
    {
        if (String.IsNullOrEmpty(TextboxTypedLetter))
        {
            MessageBox.Show("ERROR: Empty value played.\nPlay again!");
        }
        else
        {
            gameLogic.ProcessGame(TextboxTypedLetter);
            DisableCurrentGame();       // disables buttonPlay & textBoxPlayerChoice & clears LabelLetterPrompt
                                        // IsNextGamePlayable = true; 
                                        // Enables buttonContinue
            if (IsNextRoundReady)
            {
                IsNextGamePlayable = false;
                VisibilityOfZone04 = visibleVisibility;
                VisibilityOfZone05 = visibleVisibility;
            }
            else
            {
                IsNextGamePlayable = true;
            }
        }
    }


    public void ButtonContinue()
    {

        EnableNextGame();       // enables buttonPlay & textBoxPlayerChoice & clears LabelLetterPrompt
        IsNextGamePlayable = false;     // Disables buttonContinue
        LabelGameComments = String.Empty;
    }


    public void ButtonResetGame()
    {
        EnableOrResetGame("DISABLE");
        EnableNextGame();

        VisibilityOfZone04 = hiddenVisibility;
        VisibilityOfZone05 = hiddenVisibility;
        VisibilityOfZone01 = visibleVisibility;
    }


    public void DisableCurrentGame()
    {
        IsGameEnabled = false;      // disables buttonPlay & textBoxPlayerChoice
        LabelLetterPrompt = String.Empty;       // Clears the field
    }


    public void EnableNextGame()
    {
        LabelLetterPrompt = letterPromptMessage;
        TextboxTypedLetter = String.Empty;
        IsGameEnabled = true;
    }


    public void ButtonStartNewRound()
    {
        VisibilityOfZone04 = hiddenVisibility;
        VisibilityOfZone05 = hiddenVisibility;
        LabelGameComments = String.Empty;
        IsNextRoundReady = false;
        EnableNextGame();

        gameLogic.UpdateStats();
        gameLogic.GenerateSetMaskInitializeLostWord();
        gameLogic.PlayedGamesNumber = 0;
        gameLogic.UpdatePlayedGamesNumber(0);
    }
}
