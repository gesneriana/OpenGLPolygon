using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Opengl;
using Android.Util;

namespace OpenGLPolygon
{
    [Activity(Label = "OpenGLPolygon", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            // 创建一个GLSurfaceView,用于显示OpenGL绘制的图形
            GLSurfaceView glView = new GLSurfaceView(this);

            // Get our button from the layout resource,
            // and attach an event to it
            // 创建GLSurfaceView的内容绘制器
            MyRenderer myRender = new MyRenderer();
            glView.SetRenderer(myRender);
            SetContentView(glView);
            Log.Debug("调试信息", "handle: " + this.Handle);
        }
    }
}

