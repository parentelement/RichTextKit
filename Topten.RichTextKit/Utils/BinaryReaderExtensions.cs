﻿// RichTextKit
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

using System;
using System.IO;

namespace Topten.RichTextKit
{
    static class BinaryReaderExtensions
    {
        public static int ReadInt32BE(this BinaryReader reader)
        {
            var bytes = reader.ReadBytes(4);
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static uint ReadUInt32BE(this BinaryReader reader)
        {
            var bytes = reader.ReadBytes(4);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static void WriteBE(this BinaryWriter writer, int value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            writer.Write(bytes);
        }

        public static void WriteBE(this BinaryWriter writer, uint value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            writer.Write(bytes);
        }

    }
}
