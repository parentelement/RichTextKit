namespace ParentElement.Topten.RichTextKit.Styles
{
    public static class StyleExtensions
    {
        /// <summary>
        /// Updates the destination style with any non-null values from the source style.
        /// </summary>
        /// <param name="result">The style to update</param>
        /// <param name="source">The style to copy</param>
        /// <returns></returns>
        public static IStyle Merge<T>(this IStyle destination, IStyle source)
        {
            if (source == null)
                return destination;

            if (destination == null)
                return source;

            var result = new Style()
            {
                BackgroundColor = source.BackgroundColor ?? destination.BackgroundColor,
                FontFamily = source.FontFamily ?? destination.FontFamily,
                FontItalic = source.FontItalic ?? destination.FontItalic,
                FontSize = source.FontSize ?? destination.FontSize,
                FontWeight = source.FontWeight ?? destination.FontWeight,
                FontWidth = source.FontWidth ?? destination.FontWidth,
                FontVariant = source.FontVariant ?? destination.FontVariant,
                HaloBlur = source.HaloBlur ?? destination.HaloBlur,
                HaloColor = source.HaloColor ?? destination.HaloColor,
                HaloWidth = source.HaloWidth ?? destination.HaloWidth,
                LetterSpacing = source.LetterSpacing ?? destination.LetterSpacing,
                LineHeight = source.LineHeight ?? destination.LineHeight,
                StrikeThrough = source.StrikeThrough ?? destination.StrikeThrough,
                TextColor = source.TextColor ?? destination.TextColor,
                TextDirection = source.TextDirection ?? destination.TextDirection,
                Underline = source.Underline ?? destination.Underline,
                ReplacementCharacter = source.ReplacementCharacter ?? destination.ReplacementCharacter
            };

            return result;
        }

        public static StyleInfo AsStyleInfo(this IStyle source) => new StyleInfo(source);
    }
}