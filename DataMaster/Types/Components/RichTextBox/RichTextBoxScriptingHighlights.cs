using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataMaster.Types.Components.RichTextBox;

public class RichTextBoxScriptingHighlights : System.Windows.Forms.RichTextBox
{
    private Color highlightColor { get; }
        
    /// <summary>
    /// To change the syntax, call SetSyntaxByExtension.
    /// </summary>
    public LanguageHighlight languageHighlight
    {
        get => _languageHighlight;
        private set
        {
            _languageHighlight = value;
            UpdateSyntaxRegex();
        }
    }
    private LanguageHighlight _languageHighlight { get; set; }
    private string currentSyntaxRegex { get; set; }
        
    private void UpdateSyntaxRegex()
    {
        StringBuilder regexBuilder = new();
                
        regexBuilder.Append(@"\b(");
        switch(languageHighlight)
        {
            case LanguageHighlight.SQL:
                foreach (string keywords in Consts.SQL_SINTAX_HIGHLIGHT)
                {
                    regexBuilder.Append(keywords);
                    if(!Consts.SQL_SINTAX_HIGHLIGHT.Last().Equals(keywords))
                        regexBuilder.Append('|');
                }
                break;
        }
        regexBuilder.Append(@")\b");
            
        currentSyntaxRegex = regexBuilder.ToString();
    }
        

    public RichTextBoxScriptingHighlights(LanguageHighlight languageHighlight, Color highlightColor)
    {
        this.languageHighlight = languageHighlight;
        this.highlightColor = highlightColor;

        TextChanged += OnTextChanged;
    }

    private void OnTextChanged(object? sender, EventArgs e)
    {
        MatchCollection keywords = Regex.Matches(Text, currentSyntaxRegex);
        int currentPossition = SelectionStart;
        Color currentColor = ForeColor;
            
        Focus();

        foreach (Match keyword in keywords)
        {
            SelectionStart = keyword.Index;
            SelectionLength = keyword.Length;
            SelectionColor = highlightColor;
        }
            
        SelectionStart = currentPossition;
        SelectionLength = 0;
        SelectionColor = currentColor;
    }
        
    /// <summary>
    /// Only way to set the syntax
    /// </summary>
    /// <param name="extension">Syntax file extension</param>
    public void SetSyntaxByExtension(string? extension)
    {
        if(string.IsNullOrEmpty(extension))
        {
            languageHighlight = LanguageHighlight.SQL; // Default
            return;
        }

        if(Consts.SQL_FILE_EXTENSIONS.Contains(extension)) languageHighlight = LanguageHighlight.SQL;
    }
}