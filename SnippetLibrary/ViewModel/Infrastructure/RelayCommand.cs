using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnippetLibrary.ViewModel.Infrastructure
{
    /// <summary>
    /// Diese Klasse Implementiert das ICommand Interface, so muss man nicht in jeder Klasse eines ViewModel alles selbst implementieren.
    /// Einfach eine Command wie folgt Instanzieren:
    /// MyCommand = New RelayCommand(AddressOf MyCommand_Execute, AddressOf MyCommand_CanExecute)
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        /// <summary>
        ///     Erstellt einen neuen Command welcher NUR Executed werden kann.
        ///     </summary>
        ///      <param name="execute">The execution logic.</param>
        ///     <remarks></remarks>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
        /// <summary>
        ///      Erstellt einen neuen Command welcher sowohl die Execute als auch die CanExecute Logik beinhaltet.
        ///      </summary>
        ///      <param name="execute">Die Logik für Execute.</param>
        ///      <param name="canExecute">Die Logik für CanExecute.</param>
        ///      <remarks></remarks>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        /// <summary>
        ///      Setzt die CanExecute-Methode des ICommand-Interfaces auf True oder False
        ///      </summary>
        ///      <param name="parameter"></param>
        ///      <returns>Gibt zurück ob die Aktion ausgeführt werden kann oder nicht</returns>
        ///      <remarks>
        ///      Benutzt DebuggerStepThrough from System.Diagnostics
        ///      Der Debugger überspringt diese Prozedur also, es sei den es wird explizit ein Haltepunkt gesetzt.
        ///      </remarks>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        /// <summary>
        ///      Event welches geworfen wird wenn die Propertie CanExecuteChanged sich ändert.
        ///      </summary>
        ///      <remarks></remarks>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }
        void OnCanExecuteChanged(object sender, EventArgs e)
        {
        }
        /// <summary>
        ///      Führt die Prozedur Execute des ICommand.Execute aus
        ///      </summary>
        ///      <param name="parameter"></param>
        ///      <remarks></remarks>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
