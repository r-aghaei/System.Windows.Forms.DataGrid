using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public static class CurrencyManagerExtensions
    {
        public static string GetListName(this CurrencyManager manager)
        {
            return (string)manager.GetType().GetMethod("GetListName", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null)
                  .Invoke(manager, null);
        }
        public static bool AllowAdd(this CurrencyManager manager)
        {
            return (bool)manager.GetType().GetProperty("AllowAdd", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager, new object[] { });
        }
        public static bool AllowEdit(this CurrencyManager manager)
        {
            return (bool)manager.GetType().GetProperty("AllowEdit", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager, new object[] { });
        }
        public static bool AllowRemove(this CurrencyManager manager)
        {
            return (bool)manager.GetType().GetProperty("AllowRemove", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(manager, new object[] { });
        }
        public static PropertyDescriptor GetSortProperty(this CurrencyManager manager)
        {
            return (PropertyDescriptor)manager.GetType().GetMethod("GetSortProperty", BindingFlags.NonPublic | BindingFlags.Instance)
                      .Invoke(manager, new object[] { });
        }
        public static ListSortDirection GetSortDirection(this CurrencyManager manager)
        {
            return (ListSortDirection)manager.GetType().GetMethod("GetSortDirection", BindingFlags.NonPublic | BindingFlags.Instance)
                 .Invoke(manager, new object[] { });
        }
        public static object Items(this CurrencyManager manager, int index)
        {
            return manager.GetType().GetProperty("Item", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(manager, new object[] { index });
        }

        public static void SetSort(this CurrencyManager manager, PropertyDescriptor property, ListSortDirection sortDirection)
        {
            manager.GetType().GetMethod("SetSort", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(manager, new object[] { property, sortDirection });
        }
    }
}
