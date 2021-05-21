// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationMetadata.cs" company="VZ">
//   maratoss && offan
// </copyright>
// <summary>
//   Defines the AuthorizationMetadata type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Halfblood.Common.Connection
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Halfblood.Common.Helpers;

    using JetBrains.Annotations;

    /// <summary>
    /// The authorization metadata.
    /// </summary>
    public class AuthorizationMetadata : INotifyPropertyChanged
    {
        private string _login;
        private string _password;
        private string _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationMetadata"/> class.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="database">
        /// The database.
        /// </param>
        public AuthorizationMetadata(string login, string password, string database)
        {
            Login = login;
            Password = password;
            Database = database;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationMetadata"/> class.
        /// </summary>
        public AuthorizationMetadata()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login
        {
            get
            {
                return this._login;
            }
            set
            {
                this._login = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        public string Database
        {
            get
            {
                return this._database;
            }
            set
            {
                if (value == this._database)
                {
                    return;
                }
                this._database = value;
                this.OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return "login:{0};password:{1};database:{2}".StringFormat(Login, Password, Database);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}