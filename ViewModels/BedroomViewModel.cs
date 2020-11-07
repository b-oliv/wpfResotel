using ProjetRESOTEL.Entities;
using ProjetRESOTEL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetRESOTEL.ViewModels
{
    class BedroomViewModel : ViewModelBase
    {
        //l'entité du modèle
        private Bedroom bedroom;

        //Accesseur sur le modèle (Property en lecture seule)
        public Bedroom Bedroom
        {
            get { return bedroom; }
        }

        //Initialisation de la vue modèle avec l'entité modèle
        public BedroomViewModel(Bedroom bedroom)
        {
            if (bedroom == null)
            {
                throw new NullReferenceException("Bedroom");
            }
            this.bedroom = bedroom;
        }


    }
}
