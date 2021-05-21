// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisposableObject.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Defines the DisposableObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;

    public class DisposableObject : IDisposable
    {
        private readonly IList<IDisposable> _disposables = new List<IDisposable>();

        public void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
            OnAdd();
        }
        public void Add(Action disposableAction)
        {
            Add(Disposable.Create(disposableAction));
        }
        public void Add(IEnumerable<IDisposable> disposables)
        {
             disposables.DoForEach(_disposables.Add);
        }
        public void Dispose()
        {
            _disposables.DoForEach(disposable => disposable.Dispose());
            _disposables.Clear();
            OnDispose();
        }

        protected virtual void OnDispose()
        {
        }
        protected virtual void OnAdd()
        {
        }
    }
}
