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


    }
}
