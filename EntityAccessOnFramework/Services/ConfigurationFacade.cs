using EntityAccessOnFramework.Data;
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
    public class ConfigurationFacade
    {
        public AccessContext _accessContext;

        public StationManager StationManager { get { return _stationManager; } }
        StationManager _stationManager;

        public LineManager LineManager { get { return _lineManager; } }
        LineManager _lineManager;

        public TagManager TagManager { get { return _tagManager; } }
        TagManager _tagManager;

        public LineTagManager LineTagManager { get { return _lineTagManager; } }
        LineTagManager _lineTagManager;

        public GroupManager GroupManager { get { return _groupManager; } }
        GroupManager _groupManager;

        public ConfigurationFacade(AccessContext accessContext) 
        {
            _accessContext = accessContext;
            _stationManager = new StationManager(accessContext);
            _lineManager = new LineManager(accessContext);
            _tagManager = new TagManager(accessContext);
            _lineTagManager = new LineTagManager(accessContext);
            _groupManager = new GroupManager(accessContext);
        }


        public void AddNewTagToLine(Line line, Tag tag, int color )
        {
            _accessContext.LineTags.Add(new LineTag()
            {
                GroupId = line.GroupId,
                StationId = line.StationId,
                ProjectId = line.ProjectId,
                ObjectId = -1,
                LineId = line.Id,
                TagId = tag.Id,
                IsDigital = (tag.Type == "TOR"), 
                Color = color               
            });;
        }

        //public void AddNewTag(int projectId, string opcShortLink, string opcItem, string label, string name)
        //{
        //    Tag tag = new Tag();

        //    tag.OpcItem = opcItem;
        //    tag.ProjectId = projectId;
        //    tag.Unit

        //    tag.Name = name;
        //    tag.Label = label;
        //    tag.OpcShortLinkName = opcShortLink;
        //    //_accessContext.Tags.Add)
        //}

        


    }
}
