using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace InfoClassifier
{
    [Export(typeof(IGlyphFactoryProvider))]
    [Name("InfoGlyph")]
    [Order(After = "EditorMargin2")]
    [ContentType("code")]
    [TagType(typeof(InfoTag))]
    [MarginContainer(PredefinedMarginNames.VerticalScrollBar)]
    internal sealed class InfoGlyphFactoryProvider : IGlyphFactoryProvider
    {
        public IGlyphFactory GetGlyphFactory(IWpfTextView view, IWpfTextViewMargin margin)
        {
            return new InfoGlyphFactory();
        }
    }
}
