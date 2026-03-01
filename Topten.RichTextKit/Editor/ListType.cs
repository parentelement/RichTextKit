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

namespace ParentElement.Topten.RichTextKit.Editor
{
    /// <summary>
    /// Specifies the list style for a paragraph
    /// </summary>
    public enum ListType
    {
        /// <summary>No list formatting</summary>
        None,
        /// <summary>Bullet list (•, ◦, ▪ per level)</summary>
        Bullet,
        /// <summary>Numbered list (1., 2., 3. ...)</summary>
        Numbered,
    }
}
