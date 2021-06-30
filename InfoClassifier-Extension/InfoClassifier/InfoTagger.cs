using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;

namespace InfoClassifier
{
    internal class InfoTagger : ITagger<InfoTag>
    {
        private IClassifier m_classifier;
        private const string m_searchText = "info";

        internal InfoTagger(IClassifier classifier)
        {
            m_classifier = classifier;
        }

        IEnumerable<ITagSpan<InfoTag>> ITagger<InfoTag>.GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (SnapshotSpan span in spans)
            {
                //look at each classification span \
                foreach (ClassificationSpan classification in m_classifier.GetClassificationSpans(span))
                {
                    //if the classification is a comment
                    if (classification.ClassificationType.Classification.ToLower().Contains("comment"))
                    {
                        //if the word "info" is in the comment,
                        //create a new InfoTag TagSpan
                        int index = classification.Span.GetText().ToLower().IndexOf(m_searchText);
                        if (index != -1)
                        {
                            yield return new TagSpan<InfoTag>(new SnapshotSpan(classification.Span.Start + index, m_searchText.Length), new InfoTag());
                        }
                    }
                }
            }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
    }

    internal class InfoTag : IGlyphTag
    {

    }
}
