// 
// Copyright (c) 2004-2016 Jaroslaw Kowalski <jaak@jkowalski.net>, Kim Christensen, Julian Verdurmen
// 
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// * Redistributions of source code must retain the above copyright notice, 
//   this list of conditions and the following disclaimer. 
// 
// * Redistributions in binary form must reproduce the above copyright notice,
//   this list of conditions and the following disclaimer in the documentation
//   and/or other materials provided with the distribution. 
// 
// * Neither the name of Jaroslaw Kowalski nor the names of its 
//   contributors may be used to endorse or promote products derived from this
//   software without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.
// 



namespace NLog.LayoutRenderers.Wrappers
{
    using System;
    using System.ComponentModel;
    using NLog.Config;

    /// <summary>
    /// Substring the result
    /// </summary>
    /// <remarks>
    /// Same behavior as <see cref="string.Substring(int)"/> / <see cref="string.Substring(int, int)"/></remarks>
    /// <example>
    /// ${substring:${level}:Start=2:Length=2} //[DefaultParameter]
    /// ${substring:Inner=${level}:Start=2:Length=2} 
    /// </example>
    [LayoutRenderer("substring")]
    [AmbientProperty("Substring")]
    [ThreadAgnostic]
    public sealed class SubstringLayoutRendererWrapper : WrapperLayoutRendererBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UppercaseLayoutRendererWrapper" /> class.
        /// </summary>
        public SubstringLayoutRendererWrapper()
        {
            Start = 0;
        }

        /// <summary>
        /// Gets or sets the start index. 
        /// </summary>
        /// <value>Index</value>
        /// <docgen category='Transformation Options' order='10' />
        [DefaultValue(0)]
        public int Start { get; set; }

        /// <summary>
        /// Gets or sets the length in characters. If <c>null</c>, then the whole string
        /// </summary>
        /// <value>Index</value>
        /// <docgen category='Transformation Options' order='10' />
        [DefaultValue(null)]
        public int? Length { get; set; }

        /// <summary>
        /// Post-processes the rendered message. 
        /// </summary>
        /// <param name="text">The text to be post-processed.</param>
        /// <returns>Substringed.</returns>
        protected override string Transform(string text)
        {
            if (text == null)
            {
                return null;
            }

            if (Length <= 0)
            {
                return String.Empty;
            }

            if (Length.HasValue)
            {
                return text.Substring(Start, Length.Value);
            }
            return text.Substring(Start);
        }
    }
}