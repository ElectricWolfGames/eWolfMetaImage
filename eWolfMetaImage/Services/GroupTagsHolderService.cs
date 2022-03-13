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

        public void AddDefaultGroups()
        {
            GroupTags groupTags = new GroupTags("92214,LeicesterCity,Class9F,2-10-0");
            groupTags.Add("92214");
            groupTags.AddClearTags("LeicesterCity");
            groupTags.AddClearTags("Class9F");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("92134,Class9F,2-10-0");
            groupTags.Add("92134");
            groupTags.AddClearTags("Class9F");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D6535,Class33");
            groupTags.Add("D6535");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("3802,Class2884,2-8-0");
            groupTags.Add("3802");
            groupTags.AddClearTags("Class2884");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("48305,LMS,Class8F,2-8-0");
            groupTags.Add("48305");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("6990,WitherslackHall,4-6-0");
            groupTags.Add("6990");
            groupTags.AddClearTags("WitherslackHall");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("47406,Jinty,Class3F,0-6-0");
            groupTags.Add("47406");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("73156,BRStandardClass5,4-6-0");
            groupTags.Add("73156");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("78018,BRStandardClass2,2-6-0");
            groupTags.Add("78018");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("13101,Clas08");
            groupTags.Add("13101");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D3690,Class08");
            groupTags.Add("D3690");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D4137,Class08");
            groupTags.Add("D4137");
            groupTags.Add("4137");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08694,Class08");
            groupTags.Add("08694");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08784,Class08");
            groupTags.Add("08784");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("10119,Class10");
            groupTags.Add("10119");
            groupTags.AddClearTags("Class10");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("12077,Class11");
            groupTags.Add("12077");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D8098,Class20");
            groupTags.Add("D8098");
            groupTags.AddClearTags("Class20");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D5185,Class25,SulzerType2");
            groupTags.Add("D5185");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37714,Class37,CardiffCanton");
            groupTags.Add("37714");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37009,Class37");
            groupTags.Add("37009");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D123,Class45,LeicestershireAndDerbyshireYeomanry");
            groupTags.Add("D123");
            groupTags.AddClearTags("LeicestershireAndDerbyshireYeomanry");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("50017,Class50,RoyalOak ");
            groupTags.Add("50017");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("55019,Class55,RoyalHighlandFusilier ");
            groupTags.Add("55019");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("926,Repton,4-4-0,SchoolsClass");
            groupTags.Add("Repton");
            groupTags.AddClearTags("926");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("45305,Alderman_A_E_Draper,4-6-0,LMSClass5");
            groupTags.Add("45305");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("48305,2-8-0,LMSClass8F");
            groupTags.Add("48305");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("46521,2-6-0,LMSClass2");
            groupTags.Add("46521");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("68067,0-6-0,Austerity");
            groupTags.Add("68067");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08694,Class08");
            groupTags.Add("08694");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08220,Class08");
            groupTags.Add("08220");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("8274,2-8-0,LMSClass8");
            groupTags.Add("8274");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("60163,Class A1,LNER Peppercorn,Tornado");
            groupTags.Add("60163");
            groupTags.Add("Tornado");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("34072,Battle of Britain,257 Squadron,4-6-2");
            groupTags.Add("34072");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("80080,BRStandard 4MT,2-6-4T");
            groupTags.Add("80080");
            GroupTagCollection.Add(groupTags);


            groupTags = new GroupTags("43044,Class43,HST");
            groupTags.Add("43044");
            groupTags.AddClearTags("Class43");
            GroupTagCollection.Add(groupTags);
        }
    }
}