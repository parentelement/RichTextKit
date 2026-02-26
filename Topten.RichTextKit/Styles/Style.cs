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
using System;

namespace Topten.RichTextKit.Styles
{
    /// <summary>
    /// A basic implementation of IStyle interface provides styling 
    /// information for a run of text.
    /// </summary>
    public class Style : IStyle
    {
        public Style() { }

        public Style(IStyle baseStyle) : this(baseStyle, null) { }

        public Style(string name)
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                IsNamedStyle = true;
                StyleKey = name;
            }
        }

        public Style(IStyle baseStyle, string name) : this(name)
        {
            BackgroundColor = baseStyle.BackgroundColor;
            FontFamily = baseStyle.FontFamily;
            FontItalic = baseStyle.FontItalic;
            FontSize = baseStyle.FontSize;
            FontVariant = baseStyle.FontVariant;
            FontWeight = baseStyle.FontWeight;
            FontWidth = baseStyle.FontWidth;
            HaloBlur = baseStyle.HaloBlur;
            HaloColor = baseStyle.HaloColor;
            HaloWidth = baseStyle.HaloWidth;
            LetterSpacing = baseStyle.LetterSpacing;
            LineHeight = baseStyle.LineHeight;
            TextColor = baseStyle.TextColor;
            ReplacementCharacter = baseStyle.ReplacementCharacter;
            StrikeThrough = baseStyle.StrikeThrough;
            TextDirection = baseStyle.TextDirection;
            Underline = baseStyle.Underline;
        }

        public bool IsNamedStyle { get; private set; } = false;

        private string _styleKey;

        /// <summary>
        /// The key that uniquely identifies this style.
        /// </summary>
        public string StyleKey
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_styleKey))
                    _styleKey = GenerateKey();

                return _styleKey;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    IsNamedStyle = false;
                    _styleKey = GenerateKey();
                }
                else
                {
                    IsNamedStyle = true;
                    _styleKey = value;
                }
            }
        }

        /// <summary>
        /// The font family for text this text run (defaults to "Arial").
        /// </summary>
        public string FontFamily { get; init; }

        /// <summary>
        /// The font size for text in this run (defaults to 16).
        /// </summary>
        public float? FontSize { get; init; }

        /// <summary>
        /// The font weight for text in this run (defaults to 400).
        /// </summary>
        public int? FontWeight { get; init; }

        /// <summary>
        /// The font width for text in this run (defaults to WidthStyle.Normal).
        /// </summary>
        public SKFontStyleWidth? FontWidth { get; init; }

        /// <summary>
        /// True if the text in this run should be displayed in an italic
        /// font; otherwise False (defaults to false).
        /// </summary>
        public bool? FontItalic { get; init; }

        /// <summary>
        /// The underline style for text in this run (defaults to None).
        /// </summary>
        public UnderlineStyle? Underline { get; init; }

        /// <summary>
        /// The strike through style for the text in this run (defaults to None).
        /// </summary>
        public StrikeThroughStyle? StrikeThrough { get; init; }

        /// <summary>
        /// The line height for text in this run as a multiplier (defaults to 1.0).
        /// </summary>
        public float? LineHeight { get; init; }

        /// <summary>
        /// The text color for text in this run (defaults to black).
        /// </summary>
        public SKColor? TextColor { get; init; }

        /// <summary>
        /// The background color of this run (no background is painted by default).
        /// </summary>
        public SKColor? BackgroundColor { get; init; }

        /// <summary>
        /// Color of the halo
        /// </summary>
        public SKColor? HaloColor { get; init; }

        /// <summary>
        /// Width of halo
        /// </summary>
        public float? HaloWidth { get; init; }

        /// <summary>
        /// Blur of halo
        /// </summary>
        public float? HaloBlur { get; init; }

        /// <summary>
        /// The character spacing for text in this run (defaults to 0).
        /// </summary>
        public float? LetterSpacing { get; init; }

        /// <summary>
        /// The font variant (ie: super/sub-script) for text in this run.
        /// </summary>
        public FontVariant? FontVariant { get; init; }

        /// <summary>
        /// Text direction override for this span
        /// </summary>
        public TextDirection? TextDirection { get; init; }

        /// <inheritdoc />
        public char? ReplacementCharacter { get; init; }

        private string GenerateKey() => $"{FontFamily}_{FontSize}_{FontWeight}_{FontWidth}_{FontItalic}_{Underline}_{StrikeThrough}_{LineHeight}_{TextColor}_{BackgroundColor}_{HaloColor}_{HaloWidth}_{HaloBlur}_{LetterSpacing}_{FontVariant}_{TextDirection}_{ReplacementCharacter}";

        private Action _onCollect;
        internal void OnCollect(Action onCollect) => _onCollect = onCollect;

        ~Style() => _onCollect?.Invoke();
    }
}