using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace InfoClassifier
{
    class InfoGlyphFactory : IGlyphFactory
    {
        const double m_glyphSize = 16.0;

        public UIElement GenerateGlyph(IWpfTextViewLine line, IGlyphTag tag)
        {
            // Ensure we can draw a glyph for this marker.
            if (tag == null || !(tag is InfoTag))
            {
                return null;
            }

            Ellipse ellipse = new Ellipse
            {
                Fill = Brushes.LightGreen,
                StrokeThickness = 2,
                Stroke = Brushes.DarkGreen,
                Height = m_glyphSize,
                Width = m_glyphSize
            };

            ellipse.MouseEnter += GlyphIcon_MouseEnter;
            ellipse.MouseLeave += ToolTipPopup_MouseLeave;
            ellipse.ToolTip = "info glyph tooltip";

            return ellipse;
        }

        private void GlyphIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            var glyph = sender as Ellipse;
            glyph.ToolTip = "Mouse Entered to Info Glyph";
        }

        private void ToolTipPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            var glyph = sender as Ellipse;
            glyph.ToolTip = "Mouse Left from Info Glyph";
        }
    }
}
