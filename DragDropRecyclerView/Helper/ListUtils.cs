using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragDropRecyclerView.Helper
{
    public static class ListUtils
    {
        public static void Swap<T>(List<T> list, int from, int to)
        {
            T temp = list[from];
            list[from] = list[to];
            list[to] = temp;
        }
    }
}