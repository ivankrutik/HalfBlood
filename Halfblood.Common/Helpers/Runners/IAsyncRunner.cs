// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAsyncRunner.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the IAsyncRunner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Helpers.Runners
{
    using System;
    using System.Reactive;

    /// <summary>
    /// The AsyncRunner interface.
    /// </summary>
    public interface IAsyncRunner
    {
        /// <summary>
        /// Gets a value indicating whether is busy.
        /// </summary>
        bool IsBusy { get; }

        /// <summary>
        /// The theRunner.
        /// </summary>
        /// <param name="theRunner">
        /// The theRunner.
        /// </param>
        /// <param name="callback">
        /// The callback.
        /// </param>
        void Run(Action theRunner, Action<Unit> callback);

        /// <summary>
        /// The theRunner.
        /// </summary>
        /// <param name="theRunner">
        /// The theRunner.
        /// </param>
        /// <param name="callback">
        /// The callback.
        /// </param>
        /// <typeparam name="TRet">
        /// </typeparam>
        void Run<TRet>(Func<TRet> theRunner, Action<TRet> callback);
    }
}