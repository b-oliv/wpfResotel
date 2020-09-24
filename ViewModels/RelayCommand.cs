using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.ViewModels
{
    public class RelayCommand : System.Windows.Input.ICommand
    {
        private readonly Action execute;
        private readonly Action<object> executeP;

        private readonly Func<bool> canExecute = null;
        public void Execute(object parameter)
        {
            if (execute != null) execute();
            else executeP?.Invoke(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null) return true; //toujours autorisé dans ce cas
            return canExecute();
        }

        // Evenement customisé pour gérer les abonnements à _canExecute  
        // (sinon les commandes client ne seront pas alertés !)
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                {
                    System.Windows.Input.CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (canExecute != null)
                {
                    System.Windows.Input.CommandManager.RequerySuggested -= value;
                }
            }
        }
        // Initialisation de la commande avec les fonctions à appeller
        public RelayCommand(Action pexecute)
        {
            execute = pexecute;
        }
        public RelayCommand(Action pexecute, Func<bool> pcanExecute)
        {
            execute = pexecute;
            canExecute = pcanExecute;
        }

        // Initialisation de la commande avec les fonctions à appeller, avec paramètres
        public RelayCommand(Action<object> pexecuteP)
        {
            executeP = pexecuteP;
        }
        public RelayCommand(Action<object> pexecuteP, Func<bool> pcanExecute)
        {
            executeP = pexecuteP;
            canExecute = pcanExecute;
        }
    }
}
