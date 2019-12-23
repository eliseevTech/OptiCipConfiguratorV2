
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
using EntityAccessOnFramework.Services;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Shared.GetUserText;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Main.Resources;

namespace OptiCipAdministratorHelper2.View.OptiCipConfig.Main.ViewModel
{
    class OptiCipConfigMainViewModel : ViewModelBase
    {
        AccessContext _context;

        public string ConfigurationName { get; set; }
        public List<Group> ConfigGroup { get; set; }
        public List<Station> ConfigStations { get; set; }
        public List<Line> ConfigLines { get; set; }
        public List<LineTag> ConfigLineTags { get; set; }


        public ConfigurationFacade _configurationFacade;


        public OptiCipConfigMainViewModel(AccessContextService accessContextService, ConfigurationFacade configurationFacade)
        {
            _configurationFacade = configurationFacade;
            _context = accessContextService.Context;
            ConfigurationName = accessContextService.FilePath;

            ConfigGroup =  _context.Groups.ToList();           
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

        private Station selectedStation;
        public Station SelectedStation
        {
            get { return selectedStation; }
            set
            {
                selectedStation = value;
                ConfigLines = _context.Lines.Where(S => S.GroupId == SelectedStation.GroupId && S.StationId == SelectedStation.Id).ToList();
                ///Уведомляем что данные свойство обновили
                OnPropertyChanged("ConfigLines");
            }
        }


        private Line selectedLine;
        public Line SelectedLine
        {
            get { return selectedLine; }
            set
            {
                selectedLine = value;
                ConfigLineTags = _context.LineTags.Where(S => S.GroupId == SelectedLine.GroupId && S.StationId == SelectedLine.StationId && S.LineId == SelectedLine.Id).ToList();
                ///Уведомляем что данные свойство обновили
                OnPropertyChanged("ConfigLineTags");                
            }
        }



        // команда добавления нового объекта
        private RelayCommand addNewGroup;
        public RelayCommand AddNewGroup
        {
            get
            {
                return addNewGroup ?? (addNewGroup = new RelayCommand(obj =>
                {
                    GetUserTextWindow getUserTextWindow = new GetUserTextWindow();
                    getUserTextWindow.ShowDialog();
                    if (getUserTextWindow.IsSuccess)
                    {
                        _configurationFacade.GroupManager.AddGroup(getUserTextWindow.InputText);
                    }
                    GC.SuppressFinalize(getUserTextWindow);
                }));
            }
        }


        // команда добавления нового объекта
        private RelayCommand addNewStation;
        public RelayCommand AddNewStation
        {
            get
            {
                return addNewStation ?? (addNewStation = new RelayCommand(obj =>
                {
                    if (selectedGroup == null)
                    {
                        MessageBox.Show(Local.GroupIsNotSelected);
                        return;
                    }                    
                    GetUserTextWindow getUserTextWindow = new GetUserTextWindow();
                    getUserTextWindow.ShowDialog();
                    if (getUserTextWindow.IsSuccess)
                    {
                        _configurationFacade.StationManager.AddStation(getUserTextWindow.InputText, selectedGroup);
                    }
                    GC.SuppressFinalize(getUserTextWindow);
                }));
            }
        }

        // команда добавления нового объекта
        private RelayCommand addNewLine;
        public RelayCommand AddNewLine
        {
            get
            {
                return addNewLine ?? (addNewLine = new RelayCommand(obj =>
                {
                if (selectedGroup == null)
                    {
                        MessageBox.Show(Local.GroupIsNotSelected);
                        return;
                    }
                else if (selectedStation == null)
                    {
                        MessageBox.Show(Local.StationIsNotSelected);
                        return;
                    }
                    GetUserTextWindow getUserTextWindow = new GetUserTextWindow();
                    getUserTextWindow.ShowDialog();
                    if (getUserTextWindow.IsSuccess)
                    {
                        _configurationFacade.StationManager.AddStation(getUserTextWindow.InputText, selectedGroup);
                    }
                    GC.SuppressFinalize(getUserTextWindow);
                }));
            }
        }






    }
}
