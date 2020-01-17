
using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;
using Microsoft.Win32;
using OpcConfigurationCreator;
using OptiCipAdministratorHelper2.Models;

using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.Areas;
using OptiCipAdministratorHelper2.Areas.OpcConfig.Model;
using OptiCipAdministratorHelper2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OptiCipAdministratorHelper2.Services.UIServiceService.ViewModel
{
    public class MessageListInfoViewModel : ViewModelBase
    {
        private Window _window;
        public MessageListInfoViewModel(Window window, string message)
        {
            _window = window;
            Message = message;
        }
        
        public bool IsSuccess { get; private set; } = false;
        public string Message { get; set; }


        private RelayCommand successCommand;
        public RelayCommand SuccessCommand
        {
            get
            {
                return successCommand ??
                  (successCommand = new RelayCommand(obj =>
                  {
                      IsSuccess = true;
                      _window.Close();
                  }));
            }
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                  (cancelCommand = new RelayCommand(obj =>
                  {
                      IsSuccess = false;
                      _window.Close();
                  }));
            }
        }

    }
}
