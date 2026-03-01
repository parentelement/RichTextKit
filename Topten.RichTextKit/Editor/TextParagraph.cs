// RichTextKit
// Copyright © 2019-2020 Topten Software. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may 
// not use this product except in compliance with the License. You may obtain 
// a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
// License for the specific language governing permissions and limitations 
// under the License.

using SkiaSharp;
using System.Collections.Generic;
using System.Linq;

namespace ParentElement.Topten.RichTextKit.Editor
{
    /// <summary>
    /// Implements a text paragraph
    /// </summary>
    public class TextParagraph : Paragraph
    {
        const float kListIndentPerLevel = 30f;
        const float kBulletWidth = 20f;
        /// <summary>
        /// Constructs a new TextParagraph
        /// </summary>
        public TextParagraph(IStyle style)
        {
            _textBlock = new TextBlock();
            _textBlock.AddText("\u2029", style);
        }

        // Create a new textblock by copying the content of another
        public TextParagraph(TextParagraph source, int from, int length)
        {
            // Copy the text block
            _textBlock = source.TextBlock.Copy(from, length);

            // Copy styles
            CopyStyleFrom(source);
        }

        /// <summary>
        /// The 1-based item number for numbered list paragraphs (assigned by layout loop)
        /// </summary>
        internal int ListItemNumber;

        /// <inheritdoc />
        public override float ListExtraIndent =>
            ListType != ListType.None ? (ListLevel + 1) * kListIndentPerLevel : 0f;

        /// <inheritdoc />
        public override void Layout(TextDocument owner)
        {
            _textBlock.RenderWidth =
                    owner.PageWidth
                    - owner.MarginLeft - owner.MarginRight
                    - this.MarginLeft - this.MarginRight;

            if(TextBlock.Alignment != TextAlignment.Center )
            {
                _textBlock.RenderWidth -= BlockIndent;
            }

            if (ListType != ListType.None)
            {
                _textBlock.RenderWidth -= ListExtraIndent;
                _textBlock.FirstLineIndent = 0f;
            }
            else if (_textBlock.StyleRuns.Count > 0 && _textBlock.StyleRuns[0].InlineObject != null)
            {
                // Inline images always align to the left margin regardless of first-line indent.
                _textBlock.FirstLineIndent = 0f;
            }
            else
            {
                _textBlock.FirstLineIndent = owner.FirstLineIndent;
            }

            // For layout just need to set the appropriate layout width on the text block
            if (owner.LineWrap)
            {
                _textBlock.MaxWidth = _textBlock.RenderWidth;
            }
            else
                _textBlock.MaxWidth = null;
        }

        static string GetBulletChar(int level) => level switch
        {
            0 => "\u2022",   // •
            1 => "\u25E6",  // ◦
            _ => "\u25AA",  // ▪
        };

        /// <inheritdoc />
        public override void Paint(SKCanvas canvas, TextPaintOptions options)
        {
            _textBlock.Paint(canvas, new SKPoint(ContentXCoord, ContentYCoord), options);

            if (ListType != ListType.None && _textBlock.Lines.Count > 0)
            {
                var firstLine = _textBlock.Lines[0];
                var baseline = ContentYCoord + firstLine.BaseLine;

                var firstStyle = _textBlock.StyleRuns?.FirstOrDefault()?.Style;
                var fontFamily = firstStyle?.FontFamily ?? "Arial";
                var fontSize = (float)(firstStyle?.FontSize ?? 14f);
                var textColor = firstStyle?.TextColor ?? SKColors.Black;

                var bulletText = ListType == ListType.Bullet
                    ? GetBulletChar(ListLevel)
                    : $"{ListItemNumber}.";

                using var skFont = new SKFont(SKTypeface.FromFamilyName(fontFamily), fontSize);
                using var skPaint = new SKPaint { Color = textColor, IsAntialias = true };

                var bulletWidth = skFont.MeasureText(bulletText, skPaint);
                var bulletX = ContentXCoord - 4f - bulletWidth;
                canvas.DrawText(bulletText, bulletX, baseline, skFont, skPaint);
            }
        }
        
        /// <inheritdoc />
        public override CaretInfo GetCaretInfo(CaretPosition position) => _textBlock.GetCaretInfo(position);

        /// <inheritdoc />
        public override HitTestResult HitTest(float x, float y) => _textBlock.HitTest(x, y);

        /// <inheritdoc />
        public override HitTestResult HitTestLine(int lineIndex, float x) => _textBlock.HitTestLine(lineIndex, x);

        /// <inheritdoc />
        public override IReadOnlyList<int> CaretIndicies => _textBlock.CaretIndicies;

        /// <inheritdoc />
        public override IReadOnlyList<int> WordBoundaryIndicies => _textBlock.WordBoundaryIndicies;

        /// <inheritdoc />
        public override IReadOnlyList<int> LineIndicies => _textBlock.LineIndicies;

        /// <inheritdoc />
        public override int Length => _textBlock.Length;

        /// <inheritdoc />
        public override float ContentWidth => _textBlock.MeasuredWidth;

        /// <inheritdoc />
        public override float ContentHeight => _textBlock.MeasuredHeight;

        /// <inheritdoc />
        public override TextBlock TextBlock => _textBlock;

        /// <inheritdoc />
        public override void CopyStyleFrom(Paragraph other)
        {
            base.CopyStyleFrom(other);
            _textBlock.Alignment = other.TextBlock.Alignment;
            _textBlock.BaseDirection = other.TextBlock.BaseDirection;
            if (other is TextParagraph tp)
            {
                ListItemNumber = tp.ListItemNumber;
            }
        }

        // Private attributes
        TextBlock _textBlock;
    }
}
