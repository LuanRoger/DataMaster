using System;
using System.Collections.Generic;
using System.Drawing;

namespace DataMaster.Types.Components.RichTextBox
{
    public class RichTextBoxScriptingHighlights : System.Windows.Forms.RichTextBox
    {
        private readonly Color HIGHLIGHT_COLOR = Color.CornflowerBlue;

        private LanguageHighlight languageHighlight { get; set; }
        public string languageSyntax =>
            languageHighlight switch
            {
                LanguageHighlight.SQL => "SQL",
                _ => "NaN"
            };
        public void SetSyntax(string fileExtension)
        {
            if(Consts.SQL_FILE_EXTENSIONS.Contains(fileExtension)) languageHighlight = LanguageHighlight.SQL;
            else languageHighlight = LanguageHighlight.SQL;
        }

        public RichTextBoxScriptingHighlights(LanguageHighlight languageHighlight)
        {
            this.languageHighlight = languageHighlight;

            TextChanged += OnTextChanged;
        }
        private List<string> GetSintaxFromConsts() =>
            languageHighlight switch
            {
                LanguageHighlight.SQL => Consts.SQL_SINTAX_HIGHLIGHT,
                _ => Consts.SQL_SINTAX_HIGHLIGHT
            };
        
        private void OnTextChanged(object? sender, EventArgs e)
        {
            int cursorPosition = SelectionStart;
            GetSintaxFromConsts().ForEach(keyword =>
            {
                List<string> keywordsFormated = new() { keyword.ToLower(), keyword };
                foreach (string sqlKeyword in keywordsFormated)
                {
                    if(Text.Length < sqlKeyword.Length  || !Text.Contains(sqlKeyword)) return;
                
                    for(int indexInspector = 0; indexInspector <= Text.Length;)
                    {
                        if(indexInspector + sqlKeyword.Length <= Text.Length &&
                           Text.Substring(indexInspector, sqlKeyword.Length) == sqlKeyword &&
                           !HasHighlighted(indexInspector, sqlKeyword.Length, cursorPosition))
                        {
                            HighlightSelection(indexInspector, sqlKeyword.Length, cursorPosition);
                            indexInspector += sqlKeyword.Length;
                            if(indexInspector >= TextLength) break;
                        }
                        else indexInspector++;
                    }
                }
            });
        }
        private void HighlightSelection(int start, int end, int cursorPosition)
        {
            SelectionStart = start;
            SelectionLength = end;
            SelectionColor = Color.CornflowerBlue;
            
            ReturnSelectionPossition(cursorPosition);
        }
        private bool HasHighlighted(int start, int end, int cursorPosition)
        {
            SelectionStart = start;
            SelectionLength = end;
            bool hasBeenHighlighted = SelectionColor == HIGHLIGHT_COLOR;
            
            ReturnSelectionPossition(cursorPosition);
            
            return hasBeenHighlighted;
        }
        private void ReturnSelectionPossition(int cursorPosition)
        {
            SelectionStart = cursorPosition;
            SelectionLength = 0;
            SelectionColor = Color.Black;
        }
    }
}