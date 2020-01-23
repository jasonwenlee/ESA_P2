using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESA.iOS.CustomRenderers;
using ESA.Models.CustomRenderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace ESA.iOS.CustomRenderers
{
    public class CustomEditorRenderer : EditorRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                //Control.BackgroundColor = UIColor.FromRGB(255, 255, 255);
                Control.Layer.CornerRadius = 3;
                Control.Layer.BorderColor = Color.FromHex("F0F0F0").ToCGColor();
                Control.Layer.BorderWidth = 2;
            }
        }

    }
}