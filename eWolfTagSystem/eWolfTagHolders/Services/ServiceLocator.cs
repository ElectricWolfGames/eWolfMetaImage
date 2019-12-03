using eWolfCommon.Services;
using eWolfTagHolders.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWolfTagHolders.Services
{
    public class ServiceLocator : ServiceLocatorBase
    {
        private ServiceLocator()
        {
            _services = new Dictionary<Type, object>
            {
                { typeof(GroupTagsHolder), new GroupTagsHolder() },
            };
        }

        public static ServiceLocatorBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceLocator();
                }
                return _instance;
            }
        }
    }
}