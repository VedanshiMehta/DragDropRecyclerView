using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.RecyclerView.Widget;
using DragDropRecyclerView.Helper;
using DragDropRecyclerView.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DragDropRecyclerView.Adapter
{
    public class MyAdapter : RecyclerView.Adapter,ItemTouchHelperAdapterClass
    {
        private IDictionary<int, string> listData;
        private List<DragonBall> dragonBalls;
        private Context context;

        private OnStartDragListener _listner;
        public MyAdapter(Context context,List<DragonBall> dragonBalls, OnStartDragListener listner)
        {
            this.context = context;
            this.dragonBalls = dragonBalls;
            _listner = listner;
        }

        public override int ItemCount => dragonBalls.Count == null ? 0 : dragonBalls.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder myViewHolder = holder as MyViewHolder;
            myViewHolder.BindData(dragonBalls[position]);
            myViewHolder._linearLayout.SetOnLongClickListener(new LongClickListener(myViewHolder, _listner));
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row_item_layout, parent, false);
            return new MyViewHolder(view);
        }

        public bool OnItemMove(int fromPostion, int toPostion)
        {
            ListUtils.Swap(dragonBalls,fromPostion, toPostion);
            NotifyItemMoved(fromPostion, toPostion);
            return true;
        }

        public void OnItemDismiss(int position)
        {
            dragonBalls.RemoveAt(position);
            NotifyItemRemoved(position);
        }
    }
    public class MyViewHolder : RecyclerView.ViewHolder
    {
        public ImageView _imageView;
        public TextView _textViewTitle;
        public LinearLayout _linearLayout;
        public MyViewHolder(View itemView) : base(itemView)
        {
            _imageView = itemView.FindViewById<ImageView>(Resource.Id.imageViewGif);
            _textViewTitle = itemView.FindViewById<TextView>(Resource.Id.textViewTitle);
            _linearLayout = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayout);
           
           

        }

        public void BindData(DragonBall dragonBall)
        {
            _imageView.SetImageResource(dragonBall.imageId);
            _textViewTitle.Text = dragonBall.title;
        }
    }
   

    public class LongClickListener : Java.Lang.Object, View.IOnLongClickListener
    {
        private MyViewHolder myView;
        private OnStartDragListener _listener;

        public LongClickListener(MyViewHolder myView, OnStartDragListener listener)
        {
            this.myView = myView;
            _listener = listener;
        }

        public bool OnLongClick(View v)
        {
            _listener.OnStartDrag(myView);
            return true;
        }
    }
}