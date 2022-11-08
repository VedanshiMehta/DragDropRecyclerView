using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using DragDropRecyclerView.Adapter;
using DragDropRecyclerView.Helper;
using DragDropRecyclerView.Model;
using System;
using System.Collections.Generic;

namespace DragDropRecyclerView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _recyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private MyAdapter _myAdapter;
        private List<DragonBall> _dragonBalls;

        public ItemTouchHelper _itemTouchHelper;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            GetData();
            _layoutManager = new GridLayoutManager(this, 2);
            _recyclerView.SetLayoutManager(_layoutManager);
            _myAdapter = new MyAdapter(this,_dragonBalls, new MyImplementDrag(this));
            _recyclerView.SetAdapter(_myAdapter);
            var callback = new MyItemTouchHelperCallback(_myAdapter);
            _itemTouchHelper = new ItemTouchHelper(callback);
            _itemTouchHelper.AttachToRecyclerView(_recyclerView);
        }

        private List<DragonBall> GetData()
        {
            _dragonBalls = new List<DragonBall>()
              {
                new DragonBall { imageId = Resource.Drawable.image1, title = "Ultra Instinct" },
                new DragonBall { imageId = Resource.Drawable.image3, title = "Super Saiyan" },
                new DragonBall { imageId = Resource.Drawable.image4, title = "Super Saiyan Blue" },
                new DragonBall { imageId = Resource.Drawable.image5, title = "Son Goku" },
                new DragonBall { imageId = Resource.Drawable.image6, title = "Son Goku" },
                new DragonBall { imageId = Resource.Drawable.image7, title = "Super Saiyan God"},
                new DragonBall { imageId = Resource.Drawable.image8, title = "Super Saiyan God" },
                new DragonBall { imageId = Resource.Drawable.image9, title = "Ultra Instinct" },
                new DragonBall { imageId = Resource.Drawable.image10, title = "Super Saiyan 4" },
                new DragonBall { imageId = Resource.Drawable.image11, title = "Ultra Instinct 2" },
                new DragonBall { imageId = Resource.Drawable.image12, title =  "Son Goku" },
                new DragonBall { imageId = Resource.Drawable.image13, title = "Goku's Sons" },
                new DragonBall { imageId = Resource.Drawable.image14, title = "Ultra Instinct" }
                };

         
           
            return _dragonBalls;



        }

        private void UIReferences()
        {
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewViewData);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}