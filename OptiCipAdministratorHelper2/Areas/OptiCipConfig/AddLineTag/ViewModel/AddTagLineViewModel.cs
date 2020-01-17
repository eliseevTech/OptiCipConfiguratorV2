﻿using EntityAccessOnFramework.Data;
using Microsoft.Win32;
using OptiCipAdministratorHelper2.Services;
using OptiCipAdministratorHelper2.ViewModel;
using System.Collections.Generic;
using System.Linq;
using EntityAccessOnFramework.Models;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.Main.Models;
using System.Data.Entity;
using OptiCipAdministratorHelper2.Areas.OptiCipConfig.Services;
using NLog;
using System.Text;
using System.Windows;

namespace OptiCipAdministratorHelper2.Areas.OptiCipConfig.AddLineTag.ViewModel
{
    class AddLineTagViewModel : ViewModelBase
    {
        AccessContext _context;

        private ExcelReader _excelReader;

        private Line _line;

        private ILogger _logger;
        private UIMessageService _uIMessageService;


        public AddLineTagViewModel(
            AccessContextService accessContextService,
            // ConfigurationFacade configurationFacade,
            ExcelReader excelReader,
           ILogger logger,
           UIMessageService uIMessageService
            )
        {
            //_configurationFacade = configurationFacade;
            _context = accessContextService.Context;
            _excelReader = excelReader;
            _logger = logger;
            _uIMessageService = uIMessageService;

            OpcShortLinkNames = _context.OpcShortLinks.Select(S => S.Name).ToList();
            OnPropertyChanged("OpcShortLinkNames");
        }

        public void SetLine(Line line)
        {
            _line = line;
        }

        #region properties
        public string TagAliasColumnName { get; set; } = "Alias";

        public string TagLabelColumnName { get; set; } = "Label";

        public string TagColorColumnName { get; set; } = "Color";
        public string TagNameColumnName { get; set; } = "Name";

        public string FilterNameColumnName { get; set; } = "FilterName";
        public string FilterValue { get; set; } = "CIP1_1";

        public string TagTypeColumnName { get; set; } = "Type";
        public string TagUnitsColumnName { get; set; } = "Units";
        public int WorksheetNumber { get; set; } = 2;

        public List<string> OpcShortLinkNames { get; set; }
        public string OpcShortLinkName { get; set; }

        public string MinValueColumnName { get; set; } = "Min";
        public string MaxValueColumnName { get; set; } = "Max";

        public bool IsEnableButtonGetFile { get; set; } = false;
        public string SelectedFile { get; set; }

        #endregion

        // команда добавления нового объекта
        private RelayCommand selectFile;
        public RelayCommand SelectFile
        {
            get
            {
                return selectFile ?? (selectFile = new RelayCommand(obj =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Opticip config file (*.xlsx)|*.xlsx| All files (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        SelectedFile = openFileDialog.FileName;
                        IsEnableButtonGetFile = true;
                        OnPropertyChanged("SelectedFile");
                        OnPropertyChanged("IsEnableButtonGetFile");
                    }
                }));
            }
        }

        // команда добавления нового объекта
        private RelayCommand getTags;
        public RelayCommand GetTags
        {
            get
            {
                return getTags ?? (getTags = new RelayCommand(obj =>
                {
                    var excelTags = GetTagFromExcel();

                    var logMessage = TagLinesToString(excelTags);


                    MessageBoxResult result = MessageBox.Show(logMessage,"",           
                              MessageBoxButton.OK);
                    _logger.Warn("------------------------------------------");
                    _logger.Warn(logMessage);

                    //if (result != MessageBoxResult.OK)
                    //{
                    //    return;
                    //}

                    if (_uIMessageService.ShowMessageListInfo(logMessage) == false)
                    {
                        return;
                    }

                    _logger.Warn("--------------------------------");
                    _logger.Warn("Write tags to tags and tags line");

                    foreach (var T in excelTags)
                    {
                        var tag = _context.Tags.Add(T.Tag);
                        _context.SaveChanges();
                        ///нужно записать тег и взять его id, потом id задать в линию
                        T.LineTag.TagId = tag.Id;
                        _context.LineTags.Add(T.LineTag);
                        _context.SaveChanges();
                    }
                }));
            }
        }

        private List<LineTagFacade> GetTagFromExcel()
        {
            _excelReader.ExcelPath = SelectedFile;
            _excelReader.TagLabelColumnName = TagLabelColumnName;
            _excelReader.TagAliasColumnName = TagAliasColumnName;
            _excelReader.TagColorColumnName = TagColorColumnName;
            _excelReader.TagNameColumnName = TagNameColumnName;
            _excelReader.FilterNameColumnName = FilterNameColumnName;
            _excelReader.FilterValue = FilterValue;
            _excelReader.TagTypeColumnName = TagTypeColumnName;
            _excelReader.TagUnitsColumnName = TagUnitsColumnName;
            _excelReader.MinValueColumnName = MinValueColumnName;
            _excelReader.MaxValueColumnName = MaxValueColumnName;
            _excelReader.WorksheetNumber = WorksheetNumber;

            var lineTagFacades = _excelReader.GetTagsForLine(_line, OpcShortLinkName);

            return lineTagFacades;
        }

        private string TagLinesToString(List<LineTagFacade> lineTagFacades)
        {
            StringBuilder result = new StringBuilder(lineTagFacades.Count * 100);
            result.AppendLine($"Get {lineTagFacades.Count} tags");
            foreach (var l in lineTagFacades)
            {
                result.AppendLine(l.Tag.ToString());
            }
            return result.ToString();
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