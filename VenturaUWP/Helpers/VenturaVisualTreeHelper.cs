using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Ventura.Helpers
{
    public static class VenturaVisualTreeHelper
    {

        public static void FindChildren<T>(List<T> results, DependencyObject startNode) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(startNode);

            for (int i = 0; i < count; i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(startNode, i);

                if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
                {
                    T asType = (T)current;
                    results.Add(asType);
                }
                FindChildren<T>(results, current);
            }
        }

        /// <summary>
        /// Finds the parent element of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the parent element to return.</typeparam>
        /// <param name="child">The child to find the element for.</param>
        /// <returns></returns>
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            T parent = null;
            DependencyObject currParent;

            currParent = VisualTreeHelper.GetParent(child);
            while (currParent != null)
            {
                if (currParent is T)
                {
                    parent = (T)currParent;
                    break;
                }

                // find the next parent
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            return (parent);
        }

        /// <summary>
        /// Find first descendant control of a specified type.
        /// </summary>
        /// <typeparam name="T">Type to search for.</typeparam>
        /// <param name="element">Parent element.</param>
        /// <returns>Descendant control or null if not found.</returns>
        public static T FindDescendant<T>(DependencyObject element) where T : DependencyObject
        {
            T retValue = null;
            var childrenCount = VisualTreeHelper.GetChildrenCount(element);

            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                var type = child as T;
                if (type != null)
                {
                    retValue = type;
                    break;
                }

                retValue = FindDescendant<T>(child);

                if (retValue != null)
                {
                    break;
                }
            }

            return retValue;
        }

        public static FrameworkElement FindAscendantByName(DependencyObject element, string name)
        {
            if (element == null || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var parent = VisualTreeHelper.GetParent(element);

            if (parent == null)
            {
                return null;
            }

            if (name.Equals((parent as FrameworkElement)?.Name, StringComparison.OrdinalIgnoreCase))
            {
                return parent as FrameworkElement;
            }

            return FindAscendantByName(parent, name);
        }

    }
}
