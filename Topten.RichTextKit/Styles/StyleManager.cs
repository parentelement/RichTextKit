using System;
using System.Collections;
using System.Collections.Generic;
using Topten.RichTextKit.Styles;

namespace ParentElement.Topten.RichTextKit.Styles
{
    //TODO:  Consider ReaderWriterLockSlim since GC can trigger object removal while enumerating
    public class StyleManager : IEnumerable<StyleInfo>
    {
        public Style this[string styleKey]
        {
            get 
            {
                if(styleKey == null)
                    if (styleKey == null)
                        throw new ArgumentNullException(nameof(styleKey));

                if (Styles.TryGetValue(styleKey, out var styleRef) && styleRef.TryGetTarget(out var style))
                    return style;

                return null;
            }
        }

        public StyleManager(StyleInfo defaultStyle)
        {
            Styles = new Dictionary<string, WeakReference<Style>>();
        }

        public Dictionary<string, WeakReference<Style>> Styles { get; private set; }

        public Style AddOrReplace(Style style)
        {
            if(style == null)
                throw new ArgumentNullException(nameof(style));

            if(Styles.ContainsKey(style.StyleKey))
            {
                Styles[style.StyleKey].SetTarget(style);
            }                
            else
            {
                Styles.Add(style.StyleKey, new WeakReference<Style>(style));
                style.OnCollect(() => Remove(style.StyleKey));
            }

            return style;
        }

        public void Remove(string styleKey)
        {
            if (styleKey == null)
                throw new ArgumentNullException(nameof(styleKey));

            if(Styles.TryGetValue(styleKey, out var styleRef) && styleRef.TryGetTarget(out var style))
            {
                style.OnCollect(null);
                Styles.Remove(styleKey);
            }
            
        }

        public void Clear() => Styles.Clear();

        public IEnumerator<StyleInfo> GetEnumerator()
        {
            foreach(var (k, v) in Styles)
            {
                if (v.TryGetTarget(out var style))
                    yield return style.AsStyleInfo();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //TODO:  Store these differently so we're not regenerating StyleInfos every time.
        public IEnumerable<StyleInfo> NamedStyles
        {
            get
            {
                foreach (var (k, v) in Styles)
                {
                    if (v.TryGetTarget(out var style) && style.IsNamedStyle)
                        yield return style.AsStyleInfo();
                }
            }
            
        }
    }
}
