using LostLands_WPF_MVVM.ViewModels;
using System.Windows;
using System.Windows.Media;

namespace LostLands22WPF.ViewModels;


internal class GameDisplay
{
    public ShellViewModel ViewModel { get; set; }


    public void UpdatePlayedGamesNumber(int playedGamesNumber, int MaxNumberOfGames)
    {
        ViewModel.LabelGameNumber = $"Games played: {playedGamesNumber}/{MaxNumberOfGames}";

        if (playedGamesNumber == MaxNumberOfGames)
        {
            ViewModel.IsNextGamePlayable = false;
            ViewModel.VisibilityOfZone04 = Visibility.Visible.ToString();
            ViewModel.IsNextRoundReady = true;
        }
    }


    public void UpdateComment(string comment)
    {
        ViewModel.LabelGameComments = comment;

        if (comment.ToLower().Contains("present"))
        {
            ViewModel.CommentColor = Brushes.Green.ToString();
        }
        else
        {
            ViewModel.CommentColor = Brushes.Red.ToString();
        }
    }


    public void UpdateGuessedWord(string guessedWord)
    {
        ViewModel.LabelGuessedWord = guessedWord;
    }


    public void UpdateStats(int playerPoints, int roundNumber )
    {
        int successRate = 0;

        if (roundNumber > 0)
        {
            successRate = (int)(playerPoints * 100) / roundNumber;
        }
        
        string statsMessage = $"STATS" +
            $"\nRounds____ \t{roundNumber}" +
            $"\nPoints____ \t{playerPoints}" +
            $"\nSuccess___ \t{successRate} %";
        ViewModel.LabelStats = statsMessage;
    }
}
