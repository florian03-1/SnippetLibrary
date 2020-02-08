using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.ViewModel.Infrastructure
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        private bool _isBusy;
        public bool VMisBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }


        private static readonly List<string> HostProcesses = new List<string> { "XDesProc", "devenv", "WDExpress" };

        public bool IsInDesignMode
        {
            get
            {
                return HostProcesses.Contains(Process.GetCurrentProcess().ProcessName);
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        ///         ''' Prozedur wirft den INotifyPropertyChanged Event welcher in der WPF benötigt wird um die UI zu verständingen
        ///         ''' das eine Änderung an einem Property stattgefunden hat.
        ///         ''' </summary>
        ///         ''' <param name="prop">Das Propertie welche sich geändert hat. Ist Optional das der Parameter "CallerMemberName" verwendet</param>
        protected virtual void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        private bool _disposedValue; // Dient zur Erkennung redundanter Aufrufe.

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }
            }
            _disposedValue = true;
        }


        // Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(disposing As Boolean) weiter oben ein.

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
