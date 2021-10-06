using System;
using System.Collections.Generic;
using System.Drawing;

namespace DataMaster.Types.RichTextBox
{
    public class RichTextBoxScriptingHighlights : System.Windows.Forms.RichTextBox
    {
        private LanguageHighlight languageHighlight { get; }
        //TODO - Return language string
        private List<string> GetSintax() =>
        languageHighlight switch
        {
            LanguageHighlight.SQL => Consts.SQL_SINTAX_HIGHLIGHT,
            _ => Consts.SQL_SINTAX_HIGHLIGHT
        };

        public RichTextBoxScriptingHighlights(LanguageHighlight languageHighlight)
        {
            this.languageHighlight = languageHighlight;

            TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object? sender, EventArgs e)
        {
            GetSintax().ForEach(keyword =>
            {
                if(SelectionStart < keyword.Length || !Text.Substring(Text.Length - keyword.Length).Equals(keyword)) return;

                SelectionStart = Text.Length - keyword.Length;
                SelectionLength = keyword.Length;
                SelectionColor = Color.CornflowerBlue;
                
                SelectionStart = Text.Length;
                SelectionLength = 0;
                SelectionColor = Color.Black;
            });
        }
    }
}