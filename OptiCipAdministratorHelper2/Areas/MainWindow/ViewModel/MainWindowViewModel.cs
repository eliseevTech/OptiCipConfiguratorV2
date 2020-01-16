
using OptiCipAdministratorHelper2.Models;
using OptiCipAdministratorHelper2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCipAdministratorHelper2.Areas.MainWindow.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }



        #region Commands


        #endregion


    }
}
