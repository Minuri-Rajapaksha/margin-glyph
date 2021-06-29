using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.ComponentModel.Composition;

namespace TestClassifier
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(InfoTag))]
    class InfoTaggerProvider : ITaggerProvider
    {
        [Import]
        internal IClassifierAggregatorService AggregatorService;

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            return new InfoTagger(AggregatorService.GetClassifier(buffer)) as ITagger<T>;
        }
    }
}
