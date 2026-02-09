class Word
{
    private string _text;
    private string _hiddenText;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _hiddenText = new string('_', text.Length);
        _isHidden = false;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return _hiddenText;
        }
        else
        {
            return _text;
        }
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
}
