using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ESA.Models.CustomRenderers
{
    public class CustomEditor : Editor
    {
        // Remove from android custom renderer
        public delegate void BackspaceEventHandler(object sender, EventArgs e);
        public event BackspaceEventHandler OnBackspace;

        public CustomEditor() 
        {
        }

        public void OnBackspacePressed()
        {
            OnBackspace?.Invoke(null, null);
        }
    }
}
