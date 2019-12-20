using EntityAccessOnFramework.Data;
using EntityAccessOnFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityAccessOnFramework.Services
{
    public class TagManager
    {
        AccessContext _accessContext;
        public TagManager(AccessContext accessContext)
        {
            _accessContext = accessContext;
        }

        public enum TagType
        {
            analog,
            digital
        }


        public Tag AddNewTag(string name, string label, string alias, TagType tagType, int projectId, string opcItem, string opcShortLinkName)
        {
            Tag newTag = new Tag()
            {
                Name = name,
                ProjectId = projectId,

                Label = label,
                Alias = alias,
                Type = tagType.ToStrings(),
        
                OpcShortLinkName = opcShortLinkName,
                OpcItem = opcItem
            };
            _accessContext.Tags.Add(newTag);
            _accessContext.SaveChanges();
            return newTag;
        }


    }




}
