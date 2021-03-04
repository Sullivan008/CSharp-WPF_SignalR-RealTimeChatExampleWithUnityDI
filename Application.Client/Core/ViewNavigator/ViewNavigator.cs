using System;
using System.Collections.Generic;
using Application.Client.Core.ViewNavigator.Exceptions;
using Application.Client.Core.ViewNavigator.Interfaces;
using Application.Client.Core.ViewNavigator.StaticValues;
using Application.Client.Core.ViewNavigator.StaticValues.Enums;

namespace Application.Client.Core.ViewNavigator
{
    public static class ViewNavigator
    {
        private static readonly IDictionary<string, Action<object>> Subscriptions;

        static ViewNavigator()
        {
            Subscriptions = new Dictionary<string, Action<object>>();
        }

        public static void Subscribe(PageViewKey key, Action callbackMethod)
        {
            string viewName = PageViews.GetViewName(key);

            if (!Subscriptions.ContainsKey(viewName))
            {
                Subscriptions[viewName] = o => callbackMethod();
            }
            else
            {
                throw new AlreadySubscribeToTheViewNavigationException($"Have already subscribe to the view navigation! Key: {key}");
            }
        }

        public static void Subscribe<TCallbackMethodParameter>(PageViewKey key, Action<TCallbackMethodParameter> callbackMethod) where TCallbackMethodParameter : ICallbackMethodParameter
        {
            string viewName = PageViews.GetViewName(key);

            if (!Subscriptions.ContainsKey(viewName))
            {
                Subscriptions[viewName] = o => callbackMethod((TCallbackMethodParameter)o);
            }
            else
            {
                throw new AlreadySubscribeToTheViewNavigationException($"Have already subscribe to the view navigation! Key: {key}");
            }
        }
        
        public static void Unsubscribe(PageViewKey key)
        {
            string viewName = PageViews.GetViewName(key);

            if (!Subscriptions.ContainsKey(viewName))
            {
                throw new SubscriptionToTheViewNavigationNotFoundException($"The subscription to the view navigation not found! Key: {key}");
            }

            Subscriptions.Remove(viewName);
        }

        public static void Navigate(PageViewKey key)
        {
            string viewName = PageViews.GetViewName(key);

            if (!Subscriptions.ContainsKey(viewName))
            {
                throw new SubscriptionToTheViewNavigationNotFoundException($"The subscription to the view navigation not found! Key: {key}");
            }

            Subscriptions[viewName].Invoke(default);
        }

        public static void Navigate<TCallbackMethodParameter>(PageViewKey key, TCallbackMethodParameter args) where TCallbackMethodParameter : ICallbackMethodParameter
        {
            string viewName = PageViews.GetViewName(key);

            if (!Subscriptions.ContainsKey(viewName))
            {
                throw new SubscriptionToTheViewNavigationNotFoundException($"The subscription to the view navigation not found! Key: {key}");
            }

            Subscriptions[viewName].Invoke(args);
        }
    }
}
