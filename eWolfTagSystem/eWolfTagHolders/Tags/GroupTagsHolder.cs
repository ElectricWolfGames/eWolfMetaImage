using eWolfTagHolders.Services;
using System;
using System.Collections.Generic;

namespace eWolfTagHolders.Tags
{
    public class GroupTagsHolder
    {
        public GroupTagsHolder()
        {
            GroupTagCollection = new List<GroupTags>();
        }

        public static GroupTagsHolder GetGroupTagsHolder
        {
            get
            {
                return ServiceLocator.Instance.GetService<GroupTagsHolder>();
            }
        }

        public List<GroupTags> GroupTagCollection { get; set; }

        public void AdjustTags(TagHolders tagHolder)
        {
            var groups = GroupTagCollection;

            foreach (var group in groups)
            {
                var tagsToReplace = group.IndedifiableTags;
                bool addGroupTag = false;
                foreach (var tag in tagsToReplace)
                {
                    if (tagHolder.HasTag(tag))
                    {
                        tagHolder.RemoveTag(tag);
                        addGroupTag = true;
                    }
                    else
                    {
                        if (tagHolder.HasTagInGroup(tag))
                        {
                            string groupName = tagHolder.GetTagFromPartGroup(tag);
                            tagHolder.RemoveTag(groupName);
                            addGroupTag = true;
                        }
                    }
                }
                if (addGroupTag)
                {
                    ApplyGroupTag(tagHolder, group);
                }
            }
        }

        public void ApplyGroupTag(TagHolders tagHolder, GroupTags group)
        {
            foreach (var tag in group.ClearableTags)
            {
                tagHolder.RemoveTag(tag);
            }

            tagHolder.AddTag(group.MasterTag);
        }
    }
}