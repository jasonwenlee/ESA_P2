using System;
using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using ESA.Droid.CustomRenderers;
using ESA.Models.CustomRenderers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace ESA.Droid.CustomRenderers
{
    public class CustomEditorRenderer : EditorRenderer
    {

        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
        }

        // Check for backspace key event
        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.Action == KeyEventActions.Down)
            {
                if (e.KeyCode == Keycode.Del)
                {
                    if (string.IsNullOrWhiteSpace(Control.Text))
                    {
                        var entry = (CustomEditor)Element;
                        entry.OnBackspacePressed();
                        return true; 
                    }
                }
            }
            return base.DispatchKeyEvent(e);
        }
        #region Code to prevent custom editor renderer from crashing
        // Prevents custom editor from crashing when deleted/removed from list of children
        [Obsolete]
        public CustomEditorRenderer(System.IntPtr i, Android.Runtime.JniHandleOwnership j) : base(Forms.Context)
        {
        }
        // Prevents custom editor from crashing when deleted/removed from list of children
        protected override FormsEditText CreateNativeControl()
        {
            return new MyFormsEditText(Context);
        }
        #endregion

    }

    #region Fix for FormsEditText and CustomEditor to prevent crashing
    // Prevents ctor(System.IntPtr i, Android.Runtime.JniHandleOwnership j) error
    public class MyFormsEditText : FormsEditText
    {
        public MyFormsEditText(Context context) : base(context)
        {
        }

        [Obsolete]
        public MyFormsEditText(System.IntPtr i, Android.Runtime.JniHandleOwnership j) : base(Forms.Context)
        {
        }
    }
    #endregion

}