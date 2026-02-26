using SkiaSharp;

namespace Topten.RichTextKit.Styles
{
    public struct StyleInfo : IStyle
    {
        public StyleInfo(IStyle initial)
        {
            BackgroundColor = initial.BackgroundColor;
            FontFamily = initial.FontFamily;
            FontItalic = initial.FontItalic;
            FontSize = initial.FontSize;
            FontVariant = initial.FontVariant;
            FontWeight = initial.FontWeight;
            FontWidth = initial.FontWidth;
            HaloBlur = initial.HaloBlur;
            HaloColor = initial.HaloColor;
            HaloWidth = initial.HaloWidth;
            LetterSpacing = initial.LetterSpacing;
            LineHeight = initial.LineHeight;
            TextColor = initial.TextColor;
            ReplacementCharacter = initial.ReplacementCharacter;
            StrikeThrough = initial.StrikeThrough;
            StyleKey = initial.StyleKey;           
            Underline = initial.Underline;
            TextDirection = initial.TextDirection;
        }

        public string FontFamily { get; init; }

        public float? FontSize { get; init;}

        public int? FontWeight { get; init;}

        public SKFontStyleWidth? FontWidth { get; init;}

        public bool? FontItalic { get; init;}

        public UnderlineStyle? Underline { get; init;}

        public StrikeThroughStyle? StrikeThrough { get; init;}

        public float? LineHeight { get; init;}

        public SKColor? TextColor { get; init;}

        public SKColor? BackgroundColor { get; init;}

        public SKColor? HaloColor { get; init;}

        public float? HaloWidth { get; init;}

        public float? HaloBlur { get; init;}

        public float? LetterSpacing { get; init;}

        public FontVariant? FontVariant { get; init;}

        public TextDirection? TextDirection { get; init;}

        public char? ReplacementCharacter { get; init;}

        public string StyleKey { get; init;}

        public StyleInfo Union(IStyle otherStyle)
        {
            return new StyleInfo()
            {
                BackgroundColor = BackgroundColor != otherStyle.BackgroundColor ? null : BackgroundColor,
                FontFamily = FontFamily != otherStyle.FontFamily ? null : FontFamily,
                FontWeight = FontWeight != otherStyle.FontWeight ? null : FontWeight,
                FontItalic = FontItalic != otherStyle.FontItalic ? null : FontItalic,
                FontSize = FontSize != otherStyle.FontSize ? null : FontSize,
                FontVariant = FontVariant != otherStyle.FontVariant ? null : FontVariant,
                FontWidth = FontWidth != otherStyle.FontWidth ? null : FontWidth,
                HaloBlur = HaloBlur != otherStyle.HaloBlur ? null : HaloBlur,
                HaloColor = HaloColor != otherStyle.HaloColor ? null : HaloColor,
                HaloWidth = HaloWidth != otherStyle.HaloWidth ? null : HaloWidth,
                LetterSpacing = LetterSpacing != otherStyle.LetterSpacing ? null : LetterSpacing,
                LineHeight = LineHeight != otherStyle.LineHeight ? null : LineHeight,
                ReplacementCharacter = ReplacementCharacter != otherStyle.ReplacementCharacter ? null : ReplacementCharacter,
                TextDirection = TextDirection != otherStyle.TextDirection ? null : TextDirection,
                Underline = Underline != otherStyle.Underline ? null : Underline,
                StrikeThrough = StrikeThrough != otherStyle.StrikeThrough ? null : StrikeThrough,
                TextColor = TextColor != otherStyle.TextColor ? null : TextColor
            };
        }

        public StyleInfo Difference(IStyle otherStyle)
        {
            return new StyleInfo()
            {
                BackgroundColor = BackgroundColor == otherStyle.BackgroundColor ? null : otherStyle.BackgroundColor,
                FontFamily = FontFamily == otherStyle.FontFamily ? null : otherStyle.FontFamily,
                FontWeight = FontWeight == otherStyle.FontWeight ? null : otherStyle.FontWeight,
                FontItalic = FontItalic == otherStyle.FontItalic ? null : otherStyle.FontItalic,
                FontSize = FontSize == otherStyle.FontSize ? null : otherStyle.FontSize,
                FontVariant = FontVariant == otherStyle.FontVariant ? null : otherStyle.FontVariant,
                FontWidth = FontWidth == otherStyle.FontWidth ? null : otherStyle.FontWidth,
                HaloBlur = HaloBlur == otherStyle.HaloBlur ? null : otherStyle.HaloBlur,
                HaloColor = HaloColor == otherStyle.HaloColor ? null : otherStyle.HaloColor,
                HaloWidth = HaloWidth == otherStyle.HaloWidth ? null : otherStyle.HaloWidth,
                LetterSpacing = LetterSpacing == otherStyle.LetterSpacing ? null : otherStyle.LetterSpacing,
                LineHeight = LineHeight == otherStyle.LineHeight ? null : otherStyle.LineHeight,
                ReplacementCharacter = ReplacementCharacter == otherStyle.ReplacementCharacter ? null : otherStyle.ReplacementCharacter,
                TextDirection = TextDirection == otherStyle.TextDirection ? null : otherStyle.TextDirection,
                Underline = Underline == otherStyle.Underline ? null : otherStyle.Underline,
                StrikeThrough = StrikeThrough == otherStyle.StrikeThrough ? null : otherStyle.StrikeThrough,
                TextColor = TextColor == otherStyle.TextColor ? null : otherStyle.TextColor
            };
        }

        public bool HasProperties()
        {
            return BackgroundColor.HasValue ||
                FontFamily != null ||
                FontWeight.HasValue ||
                FontItalic.HasValue ||
                FontSize.HasValue ||
                FontVariant.HasValue ||
                FontWidth.HasValue ||
                HaloBlur.HasValue ||
                HaloColor.HasValue ||
                HaloWidth.HasValue ||
                LetterSpacing.HasValue ||
                LineHeight.HasValue ||
                ReplacementCharacter.HasValue ||
                TextDirection.HasValue ||
                Underline.HasValue ||
                StrikeThrough.HasValue ||
                TextColor.HasValue;
        }
    }
}
