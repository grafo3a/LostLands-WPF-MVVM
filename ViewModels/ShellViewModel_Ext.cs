using Caliburn.Micro;

namespace LostLands_WPF_MVVM.ViewModels;


public partial class ShellViewModel : Screen
{
    // === PROPERTIES START ===
    public string VisibilityOfZone01
    {
        get { return _visibilityOfZone01; }
        set
        {
            _visibilityOfZone01 = value;
            NotifyOfPropertyChange(() => VisibilityOfZone01);
        }
    }


    public string VisibilityOfZone02
    {
        get { return _visibilityOfZone02; }
        set
        {
            _visibilityOfZone02 = value;
            NotifyOfPropertyChange(() => VisibilityOfZone02);
        }
    }


    public string VisibilityOfZone03
    {
        get { return _visibilityOfZone03; }
        set
        {
            _visibilityOfZone03 = value;
            NotifyOfPropertyChange(() => VisibilityOfZone03);
        }
    }


    public string VisibilityOfZone04
    {
        get { return _visibilityOfZone04; }
        set
        {
            _visibilityOfZone04 = value;
            NotifyOfPropertyChange(() => VisibilityOfZone04);
        }
    }


    public string VisibilityOfZone05
    {
        get { return _visibilityOfZone05; }
        set
        {
            _visibilityOfZone05 = value;
            NotifyOfPropertyChange(() => VisibilityOfZone05);
        }
    }


    public BindableCollection<string> Strings
    {
        get
        {
            return new BindableCollection<string>(languageList);
        }
    }


    public string LabelStats
    {
        get { return _labelStats; }
        set
        {
            _labelStats = value;
            NotifyOfPropertyChange(() => LabelStats);
        }
    }


    public string SelectedString
    {
        get { return _selectedString; }
        set
        {
            // Action of combobox value selection
            _selectedString = value;
            NotifyOfPropertyChange(() => GameDictionaryInfo);
        }
    }


    public string GameDictionaryInfo
    {
        get { return $"[{SelectedString}] LostLands22WPF"; }
    }


    public string LabelGuessedWord
    {
        get { return _labelGuessedWord; }
        set
        {
            _labelGuessedWord = value;
            NotifyOfPropertyChange(() => LabelGuessedWord);
        }
    }


    public string LabelGameNumber
    {
        get { return _labelGameNumber; }
        set
        {
            _labelGameNumber = value;
            NotifyOfPropertyChange(() => LabelGameNumber);
        }
    }


    public string LabelLetterPrompt
    {
        get { return _labelLetterPrompt; }
        set
        {
            _labelLetterPrompt = value;
            NotifyOfPropertyChange(() => LabelLetterPrompt);
        }
    }


    public string LabelGameComments
    {
        get { return _labelGameComments; }
        set
        {
            _labelGameComments = value;
            NotifyOfPropertyChange(() => LabelGameComments);
        }
    }


    public string CommentColor
    {
        get { return _commentColor; ; }
        set
        {
            _commentColor = value;
            NotifyOfPropertyChange(() => CommentColor);
        }
    }


    public string TextboxTypedLetter
    {
        get { return _textboxTypedLetter; }
        set
        {
            _textboxTypedLetter = value;
            NotifyOfPropertyChange(() => TextboxTypedLetter);
        }
    }


    public bool IsGameEnabled
    {
        get { return _isGameEnabled; }
        set
        {
            _isGameEnabled = value;
            NotifyOfPropertyChange(() => IsGameEnabled);
        }
    }


    public bool IsNextGamePlayable
    {
        get { return _isNextGamePlayable; }
        set
        {
            _isNextGamePlayable = value;
            NotifyOfPropertyChange(() => IsNextGamePlayable);
        }
    }


    public bool IsNextRoundReady
    {
        get { return _isNextRoundReady; }
        set
        {
            _isNextRoundReady = value;
            NotifyOfPropertyChange(() => IsNextRoundReady);
        }
    }
    //=== PROPERTIES END ===
}
