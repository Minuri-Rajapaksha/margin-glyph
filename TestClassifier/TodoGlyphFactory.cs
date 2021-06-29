using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestClassifier
{
    class TodoGlyphFactory : IGlyphFactory
    {
        const double m_glyphSize = 16.0;

        public UIElement GenerateGlyph(IWpfTextViewLine line, IGlyphTag tag)
        {
            // Ensure we can draw a glyph for this marker.
            if (tag == null || !(tag is TodoTag))
            {
                return null;
            }

            Ellipse ellipse = new Ellipse();
            ellipse.Fill = Brushes.LightBlue;
            ellipse.StrokeThickness = 2;
            ellipse.Stroke = Brushes.DarkBlue;
            ellipse.Height = m_glyphSize;
            ellipse.Width = m_glyphSize;

            ellipse.MouseEnter += GlyphIcon_MouseEnter;
            ellipse.MouseLeave += ToolTipPopup_MouseLeave;
            ellipse.ToolTip = "Tooltip from Test glyph";

            return ellipse;
        }

        private void GlyphIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            var glyph = sender as Ellipse;
            glyph.ToolTip = "Mouse Entered to Test Glyph";
        }

        private void ToolTipPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            var glyph = sender as Ellipse;
            glyph.ToolTip = "Mouse Left from Test Glyph";
        }
    }
}
