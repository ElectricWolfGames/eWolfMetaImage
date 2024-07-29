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

            groupTags = new GroupTags("78019,BRStandardClass2,2-6-0");
            groupTags.Add("78019");
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

            groupTags = new GroupTags("D4067,Class10,Margaret Ethel - Thomas Alfred Naylor");
            groupTags.Add("D4067");
            groupTags.AddClearTags("Class10");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("12077,Class11");
            groupTags.Add("12077");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("12139,Class11,Redcar");
            groupTags.Add("12139");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("12083,Class12");
            groupTags.Add("12083");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D8098,Class20");
            groupTags.Add("D8098");
            groupTags.AddClearTags("Class20");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D8110,Class20");
            groupTags.Add("D8110");
            groupTags.AddClearTags("Class20");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D8154,Class20");
            groupTags.Add("D8154");
            groupTags.AddClearTags("Class20");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D5185,Class25,SulzerType2");
            groupTags.Add("D5185");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D7628,Class25,Sybilla");
            groupTags.Add("D7628");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37714,Class37,CardiffCanton");
            groupTags.Add("37714");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37207,Class37");
            groupTags.Add("37207");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37419,Class37");
            groupTags.Add("37419");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37612,Class37");
            groupTags.Add("37612");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37009,Class37");
            groupTags.Add("37009");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D6700,Class37");
            groupTags.Add("D6700");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D6808,Class37");
            groupTags.Add("D6808");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37422,Class37");
            groupTags.Add("37422");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37558,Class37");
            groupTags.Add("37558");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37425,Class37");
            groupTags.Add("37425");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37402,Class37");
            groupTags.Add("37402");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("03066,Class03");
            groupTags.Add("03066");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("45105,Class45");
            groupTags.Add("45105");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D123,Class45,LeicestershireAndDerbyshireYeomanry");
            groupTags.Add("D123");
            groupTags.AddClearTags("LeicestershireAndDerbyshireYeomanry");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("46010,Class46");
            groupTags.Add("46010");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("50017,Class50,RoyalOak");
            groupTags.Add("50017");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("55019,Class55,RoyalHighlandFusilier,Deltic");
            groupTags.Add("55019");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("55009,Class55,Alycidon,Deltic");
            groupTags.Add("55009");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("55013,Class55,TheBlackWatch,Deltic");
            groupTags.Add("55013");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D9015,Class55,Tulyap,Deltic");
            groupTags.Add("D9015");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("926,Repton,4-4-0,SchoolsClass");
            groupTags.Add("Repton");
            groupTags.AddClearTags("926");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("45305,Alderman_A_E_Draper,4-6-0,LMSClass5");
            groupTags.Add("45305");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("45428,EricTreacy,4-6-0,LMSClass5");
            groupTags.Add("45428");
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

            groupTags = new GroupTags("08706,Class08");
            groupTags.Add("08706");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08114,Class08,Gotham");
            groupTags.Add("08114");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08220,Class08");
            groupTags.Add("08220");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08922,Class08");
            groupTags.Add("08922");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D6508,Class33");
            groupTags.Add("D6508");
            groupTags.AddClearTags("Class33");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("No.419,CaledonianRailway");
            groupTags.Add("No.419");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("46010,Class46");
            groupTags.Add("46010");
            groupTags.AddClearTags("Class46");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("47292,Class47");
            groupTags.Add("47292");
            groupTags.AddClearTags("Class47");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("47077,Class47,NorthStar");
            groupTags.Add("47077");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D5830,Class31");
            groupTags.Add("D5830");
            groupTags.AddClearTags("Class31");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("82008,Class82");
            groupTags.Add("82008");
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

            groupTags = new GroupTags("43025,Class43,HST");
            groupTags.Add("43025");
            groupTags.AddClearTags("Class43");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D2120,Class03");
            groupTags.Add("D2120");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D2868,Class02");
            groupTags.Add("D2868");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("02003,Class02");
            groupTags.Add("02003");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D2996,Class07");
            groupTags.Add("D2996");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("No31,Sir Robert McAlpine and Sons");
            groupTags.Add("No31");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("M79900,Lightweight,Iris");
            groupTags.Add("M79900");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("E51427,Class101,DMU");
            groupTags.Add("E51427");
            groupTags.AddClearTags("Class101");
            groupTags.AddClearTags("DMU");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("50203,Class101,DMU");
            groupTags.Add("50203");
            groupTags.AddClearTags("Class101");
            groupTags.AddClearTags("DMU");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("100036,Wagon,OAA");
            groupTags.Add("100036");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("1408,Tank,Wagon,OAA");
            groupTags.Add("1408");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("3711,Tank,Wagon");
            groupTags.Add("3711");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("5209,Tank,Wagon,OAA");
            groupTags.Add("5209");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("6581,Tank,Wagon,Shell");
            groupTags.Add("6581");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B740654,5-Plank,Wagon");
            groupTags.Add("B740654");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B439708,OreHopper,Wagon");
            groupTags.Add("B439708");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B385782,IronOreTippler,Wagon");
            groupTags.Add("B385782");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("A4513,Tank,Wagon,Shell");
            groupTags.Add("A4513");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("E87674,Box,Wagon,Insul-Fish");
            groupTags.Add("E87674");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("41312,LMSIvattClass2,2-6-2T");
            groupTags.Add("41312");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("65894,NERClassP3,LNERJ27,0-6-0");
            groupTags.Add("65894");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("3436,Tank,Wagon,Esso");
            groupTags.Add("3436");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("DB998926,Tank,Wagon,BR");
            groupTags.Add("DB998926");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("500817,Tank,Wagon");
            groupTags.Add("500817");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("506,UrieClass,S15,4-6-0");
            groupTags.Add("506");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("73082,Camelot,BRStandardClass5,4-6-0");
            groupTags.Add("73082");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("34039,Boscastle,WestCountry,4-6-2");
            groupTags.Add("34039");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B881987,Box,Wagon,Banana");
            groupTags.Add("B881987");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B777633,Box,Wagon");
            groupTags.Add("B777633");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B768248,Box,Wagon");
            groupTags.Add("B768248");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("DB992358,BallastHopper,Wagon");
            groupTags.Add("DB992358");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("Barabel,Sentinel");
            groupTags.Add("Barabel");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("DL83,LondonTransport,Sentinel");
            groupTags.Add("DL83");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("JacksGreen,1953,Hunslet,0-6-0");
            groupTags.Add("JacksGreen");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("60007,SirNigelGresley,4-6-2");
            groupTags.Add("60007");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D8568,Class17,Clayton");
            groupTags.Add("D8568");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("144003,Class144,Pacer");
            groupTags.Add("144003");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("21C127,WestCountryClass,TamValley");
            groupTags.Add("21C127");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("31466,Class31");
            groupTags.Add("31466");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("31466,Class31");
            groupTags.Add("31466");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D821,Class42,Warship");
            groupTags.Add("D821");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("319290,Ruston&Hornsby,0-4-0");
            groupTags.Add("319290");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("7714,GWR5700,Pannier");
            groupTags.Add("7714");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("E281882,OpenHigh");
            groupTags.Add("E281882");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("E212315,Plate");
            groupTags.Add("E212315");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B954546,Brakevan,20T");
            groupTags.Add("B954546");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("ADB975397,TestCar");
            groupTags.Add("ADB975397");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B916549,SingleBolster");
            groupTags.Add("B916549");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("DB461074,Medfit");
            groupTags.Add("DB461074");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B458484,Medfit");
            groupTags.Add("B458484");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("B425356,CoalHopper");
            groupTags.Add("B425356");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D5054,Class24");
            groupTags.Add("D5054");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("6988,SwithlandHall,4-6-0");
            groupTags.Add("6988");
            groupTags.AddClearTags("SwithlandHall");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("1705,Class47,SparrowHawk");
            groupTags.Add("1705");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D7076,Class35,Hymek");
            groupTags.Add("D7076");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D7029,Class35,Hymek");
            groupTags.Add("D7029");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D832,Class42,Warship,Onslaught");
            groupTags.Add("D832");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D1048,Class52,Western,WesternLady");
            groupTags.Add("D1048");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D182,Class46");
            groupTags.Add("D182");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("20189,Class20");
            groupTags.Add("20189");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("20302,Class20");
            groupTags.Add("20302");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("20311,Class20");
            groupTags.Add("20311");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D8001,Class20");
            groupTags.Add("D8001");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D821,Class42,Warship,GreyHound");
            groupTags.Add("D821");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D1013,Class52,Western,WesternRanger");
            groupTags.Add("D1013");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D1015,Class52,Western,WesternChampion");
            groupTags.Add("D1015");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D1062,Class52,Western,WesternCourier");
            groupTags.Add("D1062");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D9551,Class14");
            groupTags.Add("D9551");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("20048,Class20");
            groupTags.Add("20048");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("37263,Class37");
            groupTags.Add("37263");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("40106,Class40,Atlantic Conveyor");
            groupTags.Add("40106");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("50035,Class50,ArkRoyal");
            groupTags.Add("50035");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("33108,Class33");
            groupTags.Add("33108");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("48773,LMS,Class8F,2-8-0");
            groupTags.Add("48773");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D3586,Clas08");
            groupTags.Add("D3586");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("08571,Clas08");
            groupTags.Add("08571");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("600,GORDON");
            groupTags.Add("GORDON");
            groupTags.AddClearTags("Class08");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("2999,Lady of Legend");
            groupTags.Add("2999");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("No72,Austerity,0-6-0");
            groupTags.Add("No72");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("339,TankA,Wagon");
            groupTags.Add("339");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("ColinMcAndrew&Coy");
            groupTags.Add("ColinMcAndrew&Coy");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("75069,BRStandardClass4MT,4-6-0");
            groupTags.Add("75069");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("153371,Class153,SuperSprinter");
            groupTags.Add("153371");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("3170,1903Autocar");
            groupTags.Add("3170");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("52322,L&YClass27,0-6-0");
            groupTags.Add("52322");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("31210,Class31");
            groupTags.Add("31210");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("1264,LNER,Thompson,ClassB1");
            groupTags.Add("1264");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("47761,Class47");
            groupTags.Add("47761");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("141113,Class141");
            groupTags.Add("141113");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("L0262,Class108");
            groupTags.Add("L0262");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("L0262,Class108");
            groupTags.Add("L0262");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D9555,Class14");
            groupTags.Add("D9555");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("6233,DuchessOfSutherland,4-6-2");
            groupTags.Add("6233");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("31108,Class31");
            groupTags.Add("31108");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("31289,Class31,PHOENIX");
            groupTags.Add("31289");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("No.4,0-4-0ST,Swanscombe");
            groupTags.Add("No.4");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("47205,Class47");
            groupTags.Add("47205");
            GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("Butler-Henderson,Class11F,4-4-0");
            groupTags.Add("Butler-Henderson");
            GroupTagCollection.Add(groupTags);
        }
    }
}