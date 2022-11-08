using AndroidX.RecyclerView.Widget;
using DragDropRecyclerView.Helper;

namespace DragDropRecyclerView
{
    public class MyImplementDrag : OnStartDragListener
    {
        private MainActivity _mainActivity;

        public MyImplementDrag(MainActivity mainActivity)
        {
            _mainActivity = mainActivity;
        }

        public void OnStartDrag(RecyclerView.ViewHolder viewHolder)
        {
            _mainActivity._itemTouchHelper.StartDrag(viewHolder);
        }
    }
}