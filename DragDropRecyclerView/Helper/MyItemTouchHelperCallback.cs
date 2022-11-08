using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragDropRecyclerView.Helper
{
    public class MyItemTouchHelperCallback : ItemTouchHelper.Callback
    {
        public static float Alpha_Full = 1.0f;
        ItemTouchHelperAdapterClass helperAdapterClass;

        public MyItemTouchHelperCallback(ItemTouchHelperAdapterClass helperAdapterClass)
        {
            this.helperAdapterClass = helperAdapterClass;
        }

        public override bool IsLongPressDragEnabled => true;
        public override bool IsItemViewSwipeEnabled => true;
        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
           if(recyclerView.GetLayoutManager() is GridLayoutManager)
            {
                var dragFlags = ItemTouchHelper.Up | ItemTouchHelper.Down | ItemTouchHelper.Right | ItemTouchHelper.Left;
                var swipeFlags = 0;
                return MakeMovementFlags(dragFlags, swipeFlags);
            }
           else
            {
                var dragFlags = ItemTouchHelper.Up | ItemTouchHelper.Down ;
                var swipeFlags = ItemTouchHelper.Start | ItemTouchHelper.End;
                return MakeMovementFlags(dragFlags, swipeFlags);
            }
        }

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder1, 
            RecyclerView.ViewHolder viewHolder2)
        {
           if(viewHolder1.ItemViewType != viewHolder2.ItemViewType)
           {
                return false;
           }
           else
            {
                helperAdapterClass.OnItemMove(viewHolder1.AdapterPosition, viewHolder2.AdapterPosition);
                return true;
            }
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int p1)
        {
            helperAdapterClass.OnItemDismiss(viewHolder.AdapterPosition);
        }

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, float dX, float dY, int actionState, bool isCurrentlyActive)
        {
            if(actionState == ItemTouchHelper.ActionStateSwipe)
            {
                var aplha = Alpha_Full - Math.Abs(dX) / (float)viewHolder.ItemView.Width;
                viewHolder.ItemView.Alpha = aplha;
                viewHolder.ItemView.TranslationX = dX;
            }
            else
            {
                base.OnChildDraw(c, recyclerView, viewHolder, dX, dY, actionState, isCurrentlyActive);
            }
           
        }
        public override void ClearView(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            base.ClearView(recyclerView, viewHolder);
            viewHolder.ItemView.Alpha = Alpha_Full;
            if(viewHolder is ItemTouchHelperViewHolderClass)
            {
                var itemViewHolder = viewHolder as ItemTouchHelperViewHolderClass;
                itemViewHolder.OnItemClear();
            }
        }
        public override void OnSelectedChanged(RecyclerView.ViewHolder viewHolder, int actionState)
        {
          
            if(actionState != ItemTouchHelper.ActionStateIdle)
            {
                if (viewHolder is ItemTouchHelperViewHolderClass)
                {
                    var itemViewHolder = viewHolder as ItemTouchHelperViewHolderClass;
                    itemViewHolder.OnItemSelected();
                }
            }
            base.OnSelectedChanged(viewHolder, actionState);
        }
    }
}