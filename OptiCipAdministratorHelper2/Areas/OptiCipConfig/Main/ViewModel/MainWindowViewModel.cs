﻿using EntityAccessOnFramework.Data;
using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using EntityAccessOnFramework.Models;
using EntityAccessOnFramework.Services;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.Shared.GetUserText;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.Main.Resources;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.Main.Models;
using System.Data.Entity;


namespace OptiCipAdministratorHelper2.View.OptiCipConfig.Main.ViewModel
{
    class OptiCipConfigMainViewModel : ViewModelBase
    {
        AccessContext _context;

        public string ConfigurationName { get; set; }
        public List<Group> ConfigGroup { get; set; }
        public List<Station> ConfigStations { get; set; }
        public List<Line> ConfigLines { get; set; }
        //public List<LineTag> ConfigLineTags { get; set; }
        public List<LineTagFacade> LineTagFacades { get; set; }


        public ConfigurationFacade _configurationFacade;
        public WindowLocator _windowService;


        public OptiCipConfigMainViewModel(
            AccessContextService accessContextService,
            ConfigurationFacade configurationFacade,
            WindowLocator windowService)
        {
            _configurationFacade = configurationFacade;
            _context = accessContextService.Context;
            ConfigurationName = accessContextService.FilePath;
            _windowService = windowService;
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
                UpdateLineTag();
            }
        }

        private void UpdateLineTag()
        {

            ClearContextChanges();
            if (SelectedLine == null)
            {
                LineTagFacades = null;
            }
            else
            {
                var lineTags = _context.LineTags.Where(S => S.GroupId == SelectedLine.GroupId && S.StationId == SelectedLine.StationId && S.LineId == SelectedLine.Id).ToList();
                LineTagFacades = GetLineFacadeTags(lineTags);
            }

            ///Уведомляем что данные свойство обновили
            OnPropertyChanged("LineTagFacades");
        }


        List<LineTagFacade> GetLineFacadeTags(ICollection<LineTag> lineTags)
        {
            List<LineTagFacade> lineTagFacades = new List<LineTagFacade>();
            foreach (var L in lineTags)
            {
                var tag = _context.Tags.FirstOrDefault(T => T.Id == L.TagId);
                if (tag == null)
                {
                    continue;
                }
                lineTagFacades.Add(new LineTagFacade()
                {
                    LineTag = L,
                    Tag = tag
                });
            }
            return lineTagFacades;
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
                    GetUserTextWindow getUserTextWindow = new GetUserTextWindow(Local.AddStationTittle);
                    getUserTextWindow.ShowDialog();
                    if (getUserTextWindow.IsSuccess)
                    {
                        _configurationFacade.StationManager.AddStation(getUserTextWindow.InputText, selectedGroup);
                        OnPropertyChanged("ConfigStations");
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

                    GetUserTextWindow getUserTextWindow = new GetUserTextWindow(Local.AddLineTittle);
                    getUserTextWindow.ShowDialog();
                    if (getUserTextWindow.IsSuccess)
                    {
                       //_configurationFacade.LineManager.AddLine(getUserTextWindow.InputText, selectedStation);
                       MessageBox.Show("Function not yet implemented");
                    }
                    GC.SuppressFinalize(getUserTextWindow);
                }));
            }
        }


        // команда добавления нового объекта
        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {
                    UpdateLineTag();
                }));
            }
        }

        // команда добавления нового объекта
        private RelayCommand save;
        public RelayCommand Save
        {
            get
            {
                return save ?? (save = new RelayCommand(obj =>
                {                    
                    _context.SaveChanges();
                    OnPropertyChanged("LineTagFacades");
                }));
            }
        }


        // команда добавления нового объекта
        private RelayCommand addNewTagsToLineFromExcel;
        public RelayCommand AddNewTagsToLineFromExcel
        {
            get
            {
                return addNewTagsToLineFromExcel ?? (addNewTagsToLineFromExcel = new RelayCommand(obj =>
                {
                    if (selectedGroup == null || SelectedLine == null)
                    {
                        MessageBox.Show(Local.GroupIsNotSelected);
                        return;
                    }
                    _windowService.RunAddLineTagToOptiCipConfiguration(SelectedLine);
                    OnPropertyChanged("LineTagFacades");

                }));
            }
        }


        private void ClearContextChanges()
        {
            var changedEntries = _context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.CurrentValues.SetValues(entry.OriginalValues);
                    entry.State = EntityState.Unchanged;
                }
                if (entry.State == EntityState.Added)
                {
                    entry.State = EntityState.Detached;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Unchanged;
                }
            }
        }


    }
}
