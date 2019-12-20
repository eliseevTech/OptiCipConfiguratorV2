using EntityAccessOnFramework.Data;
using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityAccessOnFramework.Services
{
    public class LineTagManager
    {
        AccessContext _accessContext;
        public LineTagManager(AccessContext accessContext)
        {
            _accessContext = accessContext;
        }

        public LineTag AddLineTag(Tag tag, Line line)
        {          
            LineTag newLineTag = new LineTag()
            {
                GroupId = line.GroupId,
                ProjectId = line.ProjectId,
                StationId = line.StationId,
                LineId = line.Id,
                TagId = tag.Id,
                IsDigital = TagTypeExtensions.IsDigital(tag.Type),               
                ObjectId = -1
            };

            _accessContext.LineTags.Add(newLineTag);
            _accessContext.SaveChanges();
            return newLineTag;
        }


    }




}
