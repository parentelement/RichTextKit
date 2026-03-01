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

namespace ParentElement.Topten.RichTextKit
{
    /// <summary>
    /// Interface for objects that can be embedded inline within text flow.
    /// Inline objects are represented by the Unicode Object Replacement Character
    /// (U+FFFC) in the code point stream and are sized/painted independently.
    /// </summary>
    public interface IInlineObject
    {
        /// <summary>The display width of this inline object in pixels.</summary>
        float Width { get; }

        /// <summary>The display height of this inline object in pixels.</summary>
        float Height { get; }

        /// <summary>
        /// Paints the inline object.
        /// </summary>
        /// <param name="canvas">The canvas to paint on.</param>
        /// <param name="origin">The top-left origin of the object's bounding box.</param>
        void Paint(SKCanvas canvas, SKPoint origin);
    }
}
