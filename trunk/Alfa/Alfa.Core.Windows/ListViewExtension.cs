using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alfa.Core.Entity;

namespace Alfa.Core.Windows.Extension
{
    public static class ListViewExtended
    {
        public static void DataBind<T>(this ListView List, List<T> DataSource) where T : EntityBase
        {
            if (DataSource == null || DataSource.Count == 0)
                return;

            DataBind(List, DataSource, true);
        }
        public static void DataBind<T>(this ListView List, List<T> DataSource, bool primitiveTypesOnly) where T : EntityBase
        {
            if (DataSource == null || DataSource.Count == 0)
                return;

            List<String> properties = DataSource[0].Properties(primitiveTypesOnly);

            List.Clear();

            foreach (String property in properties)
                List.Columns.Add(property);

            foreach (T item in DataSource)
            {
                string[] values = new string[properties.Count];
                for (int index = 0; index < values.Length; index++)
                    values[index] = item.ValueFrom(properties[index]);

                List.Items.Add(new ListViewItem(values));
            }
        }
    }
}
