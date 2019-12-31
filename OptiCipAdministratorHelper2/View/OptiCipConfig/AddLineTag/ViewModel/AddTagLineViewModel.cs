
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
using OptiCipAdministratorHelper2.View.OptiCipConfig.Main.Models;
using System.Data.Entity;
using OptiCipAdministratorHelper2.View.OptiCipConfig.Services;

namespace OptiCipAdministratorHelper2.View.OptiCipConfig.AddLineTag.ViewModel
{
    class AddLineTagViewModel : ViewModelBase
    {
        AccessContext _context;

        private ExcelReader _excelReader;

        private Line _line;


        public AddLineTagViewModel(
            AccessContextService accessContextService,
           // ConfigurationFacade configurationFacade,
            ExcelReader excelReader
            )
        {
            //_configurationFacade = configurationFacade;
            _context = accessContextService.Context;
            _excelReader = excelReader;
        }



        public void SetLine(Line line)
        {
            _line = line;
        }

        #region properties
        public string TagAliasColumnName { get; set; } = "Variable RUS";
        public string TagColorColumnName { get; set; } = "Color";
        public string TagNameColumnName { get; set; } = "Variable ENG";

        public string FilterNameColumnName { get; set; } = "Filter";
        public string FilterValue { get; set; } = "CIP1_1";


        public string TagTypeColumnName { get; set; } = "Type";
        public string TagUnitsColumnName { get; set; } = "Units";
        public int WorksheetNumber { get; set; } = 2;

        public string OpcShortLinkName { get; set; } = "shortLink";

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
                        SelectedFile =  openFileDialog.FileName;
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
                return getTags ?? ( getTags = new RelayCommand(obj =>
                {
                    var excelTags = GetTagFromExcel();
                    
                    foreach(var T in excelTags)
                    {
                        var tag = _context.Tags.Add(T.Tag);
                        ///нужно записать тег и взять его id, потом id задать в линию
                        T.LineTag.TagId = tag.Id;
                        _context.LineTags.Add(T.LineTag);
                            
                        
                    }

                }));
            }
        }


        private List<LineTagFacade> GetTagFromExcel()
        {
            _excelReader.ExcelPath = SelectedFile;
            _excelReader.TagAliasColumnName = TagAliasColumnName;
            _excelReader.TagColorColumnName = TagColorColumnName;
            _excelReader.TagNameColumnName = TagNameColumnName;
            _excelReader.FilterNameColumnName = FilterNameColumnName;
            _excelReader.FilterValue = FilterValue;
            _excelReader.TagTypeColumnName = TagTypeColumnName;
            _excelReader.TagUnitsColumnName = TagUnitsColumnName;

            _excelReader.WorksheetNumber = WorksheetNumber;
            return _excelReader.GetTagsForLine(_line, OpcShortLinkName);
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
