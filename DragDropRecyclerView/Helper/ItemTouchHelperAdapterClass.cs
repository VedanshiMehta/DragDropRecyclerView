﻿using Android.App;
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
    public interface ItemTouchHelperAdapterClass
    {
       bool OnItemMove(int fromPostion, int toPostion);
        void OnItemDismiss(int position);

    }
}