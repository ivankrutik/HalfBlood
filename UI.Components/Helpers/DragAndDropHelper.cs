// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragAndDropHelper.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   The drag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    using GongSolutions.Wpf.DragDrop;

    /// <summary>
    /// The drag.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class DragAndDropHelper<T> : IDropTarget
    {
        private readonly Action<T> _dropAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="DragAndDropHelper{T}"/> class.
        /// </summary>
        /// <param name="dropAction">
        /// The drop action.
        /// </param>
        public DragAndDropHelper(Action<T> dropAction)
        {
            if (dropAction == null)
            {
                throw new ArgumentNullException("dropAction");
            }

            this._dropAction = dropAction;
        }

        /// <summary>
        /// The drag over.
        /// </summary>
        /// <param name="dropInfo">
        /// The drop info.
        /// </param>
        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = DragDropEffects.Move;
        }

        /// <summary>
        /// The drop.
        /// </summary>
        /// <param name="dropInfo">
        /// The drop info.
        /// </param>
        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is IList<T>)
            {
                foreach (var elem in (IList<T>)dropInfo.Data)
                {
                    //((IList)dropInfo.DragInfo.SourceCollection).Remove(elem);
                    this._dropAction(elem);
                }
            }
            else
            {
                if (!(dropInfo.Data is T))
                {
                    return;
                }
                var pupil = (T)dropInfo.Data;

                //((IList)dropInfo.DragInfo.SourceCollection).Remove(pupil);
                this._dropAction(pupil);
            }
        }
    }
}