using ParentElement.Topten.RichTextKit.Editor;

namespace ParentElement.Topten.RichTextKit
{
    public readonly struct SelectionInfo
    {
        public StyleInfo StyleInfo { get; }
        public TextAlignment? ParagraphAlignment { get; }
        public float? LineSpacing { get; }
        public ListType? ParagraphListType { get; }

        public SelectionInfo(StyleInfo styleInfo, TextAlignment? paragraphAlignment, float? lineSpacing, ListType? paragraphListType = null)
        {
            StyleInfo = styleInfo;
            ParagraphAlignment = paragraphAlignment;
            LineSpacing = lineSpacing;
            ParagraphListType = paragraphListType;
        }
    }
}
