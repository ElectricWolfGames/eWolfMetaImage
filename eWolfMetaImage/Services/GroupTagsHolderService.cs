using eWolfTagHolders.Services;
using eWolfTagHolders.Tags;

namespace eWolfMetaImage.Data
{
    public class GroupTagsHolderService : GroupTagsHolder
    {
        public static GroupTagsHolderService GetGroupTagsHolder
        {
            get
            {
                return ServiceLocator.Instance.GetService<GroupTagsHolderService>();
            }
        }
    }
}