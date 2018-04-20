using BenTurkia.NumbersConverter.Business.Contracts;
using BenTurkia.NumbersConverter.Business.Implementations;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenTurkia.NumbersConverter.Business
{
    /// <summary>
    /// Business Factory Class
    /// </summary>
    public class BusinessFactory
    {
        private Container container;
        private static BusinessFactory instance;
        private static readonly object syncRoot = new Object();

        private BusinessFactory()
        {
            RegisterBusinessImplementations();
        }

        private void RegisterBusinessImplementations()
        {
            container = new Container();

            #region Roman Numbers
            container.Register<IRomanBO, RomanBO>(Lifestyle.Singleton);
            #endregion

            container.Verify();
        }

        public static BusinessFactory Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BusinessFactory();
                    }
                }

                return instance;
            }
        }

        public T GetService<T>()
        {
            return (T)container.GetInstance(typeof(T));
        }

        public static T Service<T>()
        {
            return Instance.GetService<T>();
        }
    }
}
