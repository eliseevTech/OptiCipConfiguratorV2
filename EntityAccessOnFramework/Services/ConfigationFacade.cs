using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityAccessOnFramework.Services.TagManager;

namespace EntityAccessOnFramework.Services
{
    /// <summary>
    /// Фасад для менеджеров и методы где нужны все менеджеры (например добавление тега сразу в линию)
    /// </summary>
    public class ConfigationFacade
    {
        public StationManager StationManager { get { return _stationManager; } }
        StationManager _stationManager;

        public LineManager LineManager { get { return _lineManager; } }
        LineManager _lineManager;

        public TagManager TagManager { get { return _tagManager; } }
        TagManager _tagManager;

        public LineTagManager LineTagManager { get { return _lineTagManager; } }
        LineTagManager _lineTagManager;

        public ConfigationFacade(
            StationManager stationManager,
            LineManager lineManager,
            TagManager tagManager,
            LineTagManager lineTagManager
            )
        {
            _stationManager = stationManager;
            _lineManager = lineManager;
            _tagManager = tagManager;
            _lineTagManager = lineTagManager;            
        }

        /// <summary>
        /// Добавляем новый тег в лингию
        /// (добавляем тег в теги, а потом его в линию)
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="label"></param>
        /// <param name="alias"></param>
        /// <param name="tagType">тип</param>
        /// <param name="line">линия</param>
        public void AddNewTagToLine(string name, string label, string alias, TagType tagType, Line line)
        {
            Tag newTag = TagManager.AddNewTag(name, label, alias, tagType, line.ProjectId);
            _lineTagManager.AddLineTag(newTag, line);
        }
    }
}
