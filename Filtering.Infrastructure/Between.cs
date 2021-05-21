// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Between.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the Between type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Filtering.Infrastructure
{
    public class Between<T> : INotifyPropertyChanged
    {
        public Between()
        {
        }

        public Between(T from, T to)
        {
            this.From = from;
            this.To = to;
        }

        public T From { get; set; }
        public T To { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}