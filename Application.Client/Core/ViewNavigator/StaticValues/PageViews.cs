using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Application.Client.Core.ViewNavigator.StaticValues.Enums;
using Application.Client.Views.Chat;
using Application.Client.Views.SignIn;

namespace Application.Client.Core.ViewNavigator.StaticValues
{
    public static class PageViews
    {
        private static readonly ReadOnlyDictionary<PageViewKey, string> PageViewNames;

        static PageViews()
        {
            PageViewNames = new ReadOnlyDictionary<PageViewKey, string>(new Dictionary<PageViewKey, string>
            {
                { PageViewKey.SignIn, nameof(SignInView) },
                { PageViewKey.Chat, nameof(ChatView) }
            });
        }

        public static string GetViewName(PageViewKey key)
        {
            PageViewNames.TryGetValue(key, out string result);

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result), $@"The following Page View Key does not exist with this key. {nameof(key).ToUpper()}: {key}");
            }

            return result;
        }
    }
}
