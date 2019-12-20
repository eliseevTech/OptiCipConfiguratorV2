
using ConfigurationDataCollector;
using ConfigurationDataCollector.Excel;
using EntityAccessOnFramework.Data;
using Microsoft.Win32;
using OpcConfigurationCreator;
using OptiCipAdministratorHelper2.Models;

using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.View;
using OptiCipAdministratorHelper2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EntityAccessOnFramework.Models;

namespace OptiCipAdministratorHelper2.View.OptiCipConfig.Main.ViewModel
{
    class OptiCipConfigMainViewModel : ViewModelBase
    {
        AccessContext _context;

        public string ConfigurationName { get; set; }
        public List<Group> ConfigGroup { get; set; }
        public List<Station> ConfigStations { get; set; }

        public OptiCipConfigMainViewModel(AccessContextService accessContextService)
        {
            _context = accessContextService.Context;
            ConfigurationName = accessContextService.FilePath;
            ConfigGroup = _context.Groups.ToList();           
        }




        private Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                ConfigStations = _context.Stations.Where(S => S.GroupId == SelectedGroup.Id).ToList();    
                ///Уведомляем что данные свойство обновили
                OnPropertyChanged("ConfigStations");
            }
        }



    }
}
