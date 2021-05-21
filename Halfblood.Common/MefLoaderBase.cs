// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MefLoaderBase.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The mef loader base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    using Halfblood.Common.Helpers;

    using JetBrains.Annotations;

    /// <summary>
    /// The MEF loader base.
    /// </summary>
    /// <typeparam name="TImport">
    /// The type of import.
    /// </typeparam>
    /// <typeparam name="TImportMetadata">
    /// The type of metadata.
    /// </typeparam>
    /// <typeparam name="TKey">
    /// The type of key of dictionary.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of value.
    /// </typeparam>
    public abstract class MefLoaderBase<TImport, TImportMetadata, TKey, TValue> : IPartImportsSatisfiedNotification, IDisposable
    {
        /// <summary>
        /// The contents.
        /// </summary>
        protected Dictionary<TKey, TValue> Contents;

        /// <summary>
        /// Initializes a new instance of the <see cref="MefLoaderBase{TImport,TImportMetadata,TKey,TValue}"/> class. 
        /// </summary>
        protected MefLoaderBase()
        {
            this.Contents = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Gets or sets the lazy imports.
        /// </summary>
        [NotNull, ImportMany]
        private Lazy<TImport, TImportMetadata>[] LazyImports { get; set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="content">
        /// The content.
        /// </param>
        public void Add(TKey key, TValue content)
        {
            this.Contents.Add(key, content);
        }

        /// <summary>
        /// The get content.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        /// The key not found
        /// </exception>
        public TValue GetContent(TKey key)
        {
            if (this.Contents.ContainsKey(key))
            {
                return this.Contents[key];
            }

            throw new KeyNotFoundException("key name: {0}".StringFormat(key));
        }

        /// <summary>
        /// The try get content.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="TValue"/>.
        /// </returns>
        public TValue TryGetContent(TKey key)
        {
            if (this.Contents.ContainsKey(key))
            {
                return this.Contents[key];
            }

            return default(TValue);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Contents.Clear();
            this.LazyImports = null;
        }

        /// <summary>
        /// The on imports satisfied.
        /// </summary>
        void IPartImportsSatisfiedNotification.OnImportsSatisfied()
        {
            foreach (Lazy<TImport, TImportMetadata> import in this.LazyImports)
            {
                this.Imports(import);
            }

            this.LazyImports = null;
        }

        /// <summary>
        /// The imports.
        /// </summary>
        /// <param name="lazy">
        /// The lazy.
        /// </param>
        protected abstract void Imports([NotNull] Lazy<TImport, TImportMetadata> lazy);
    }
}