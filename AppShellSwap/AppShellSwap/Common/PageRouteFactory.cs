using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShellSwap.Common
{
    public class PageRouteFactory<T> : RouteFactory where T : Page
    {
        #region Members

        readonly IServiceProvider locator;

        #endregion

        #region Constructors

        public PageRouteFactory(IServiceProvider locator)
        {
            this.locator = locator;
        }

        #endregion

        #region Methods

        public override Element GetOrCreate()
        {
            return (T)locator.GetService(typeof(T));
        }
        public override bool Equals(object obj)
        {
            if (obj is PageRouteFactory<T> typeRouteFactory)
                return typeRouteFactory.locator == locator;

            return false;
        }

        public override int GetHashCode()
        {
            return typeof(T).GetHashCode();
        }

        #endregion
    }
}
