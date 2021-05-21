// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModernDialog.cs" company="VZ">
//   maratoss && offan && kesar && icesun
// </copyright>
// <summary>
//   Represents a Modern UI styled dialog window.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UI.Components.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using MahApps.Metro.Controls;

    using ReactiveUI;

    /// <summary>
    /// Represents a Modern UI styled dialog window.
    /// </summary>
    public class ModernDialog : MetroWindow
    {
        /// <summary>
        /// Identifies the BackgroundContent dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register("BackgroundContent", typeof(object), typeof(ModernDialog));

        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons", typeof(IEnumerable<Button>), typeof(ModernDialog));

        private ICommand closeTrueCommand;
        private ICommand closeFalseCommand;
        private ICommand closeCommand;

        private Button okButton;
        private Button cancelButton;
        private Button yesButton;
        private Button noButton;
        private Button closeButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModernDialog"/> class.
        /// </summary>
        public ModernDialog()
        {
            this.DefaultStyleKey = typeof(ModernDialog);
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.closeTrueCommand = new ReactiveCommand(Observable.Return(true));
            ((ReactiveCommand)this.closeTrueCommand).Subscribe(
                o =>
                    {
                        this.DialogResult = true;
                        Close();
                    });
            this.closeFalseCommand = new ReactiveCommand(Observable.Return(true));
            ((ReactiveCommand)this.closeFalseCommand).Subscribe(o =>
            {
                this.DialogResult = false;
                Close();
            });
            this.closeCommand = new ReactiveCommand(Observable.Return(true));
            ((ReactiveCommand)this.closeCommand).Subscribe(o => this.Close());

            this.Buttons = new Button[] { this.CloseButton };

            // set the default owner to the app main window (if possible)
            if (Application.Current != null && Application.Current.MainWindow != this)
            {
                this.Owner = Application.Current.MainWindow;
            }
        }

        private Button CreateDialogButton(string content, bool isDefault, bool isCancel, ICommand command)
        {
            return new Button
            {
                Content = content,
                Command = command,
                IsDefault = isDefault,
                IsCancel = isCancel,
                MinHeight = 21,
                MinWidth = 65,
                Margin = new Thickness(4, 0, 0, 0)
            };
        }

        /// <summary>
        /// Gets the close window command that sets the dialog result to True.
        /// </summary>
        public ICommand CloseTrueCommand
        {
            get { return this.closeTrueCommand; }
        }

        /// <summary>
        /// Gets the close window command that sets the dialog result to false.
        /// </summary>
        public ICommand CloseFalseCommand
        {
            get { return this.closeFalseCommand; }
        }

        /// <summary>
        /// Gets the close window command that sets the dialog result to a null value.
        /// </summary>
        public ICommand CloseCommand
        {
            get { return this.closeCommand; }
        }

        /// <summary>
        /// Gets the Ok button.
        /// </summary>
        public Button OkButton
        {
            get
            {
                if (this.okButton == null)
                {
                    this.okButton = CreateDialogButton("Ok", true, false, this.closeTrueCommand);
                }
                return this.okButton;
            }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public Button CancelButton
        {
            get
            {
                if (this.cancelButton == null)
                {
                    this.cancelButton = CreateDialogButton("Отмена", false, true, this.closeCommand);
                }
                return this.cancelButton;
            }
        }

        /// <summary>
        /// Gets the Yes button.
        /// </summary>
        public Button YesButton
        {
            get
            {
                if (this.yesButton == null)
                {
                    this.yesButton = CreateDialogButton("Да", true, false, this.closeTrueCommand);
                }
                return this.yesButton;
            }
        }

        /// <summary>
        /// Gets the No button.
        /// </summary>
        public Button NoButton
        {
            get
            {
                if (this.noButton == null)
                {
                    this.noButton = CreateDialogButton("Нет", false, true, this.closeFalseCommand);
                }
                return this.noButton;
            }
        }

        /// <summary>
        /// Gets the Close button.
        /// </summary>
        public Button CloseButton
        {
            get
            {
                if (this.closeButton == null)
                {
                    this.closeButton = CreateDialogButton("Закрыть", true, false, this.closeCommand);
                }
                return this.closeButton;
            }
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public object BackgroundContent
        {
            get { return GetValue(BackgroundContentProperty); }
            set { SetValue(BackgroundContentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the dialog buttons.
        /// </summary>
        public IEnumerable<Button> Buttons
        {
            get { return (IEnumerable<Button>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <param name="button">The button.</param>
        /// <returns></returns>
        public static bool? ShowMessage(string text, string title, MessageBoxButton button)
        {
            var dlg = new ModernDialog
            {
                Title = title,
                Content = new TextBlock { Text = text, Margin = new Thickness(0, 0, 0, 8) },
                MinHeight = 0,
                MinWidth = 0,
                MaxHeight = 480,
                MaxWidth = 640,
            };

            dlg.Buttons = GetButtons(dlg, button);

            return dlg.ShowDialog();
        }

        private static IEnumerable<Button> GetButtons(ModernDialog owner, MessageBoxButton button)
        {
            if (button == MessageBoxButton.OK)
            {
                yield return owner.OkButton;
            }
            else if (button == MessageBoxButton.OKCancel)
            {
                yield return owner.OkButton;
                yield return owner.CancelButton;
            }
            else if (button == MessageBoxButton.YesNo)
            {
                yield return owner.YesButton;
                yield return owner.NoButton;
            }
            else if (button == MessageBoxButton.YesNoCancel)
            {
                yield return owner.YesButton;
                yield return owner.NoButton;
                yield return owner.CancelButton;
            }
        }
    }
}
