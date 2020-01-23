using ESA.Models.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESA.TestView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateHistory : ContentPage
    {
        public CustomWebview GetHistoryTextEditor { get; private set; }

        public CreateHistory()
        {
            InitializeComponent();
            GetHistoryTextEditor = textEditor.FindByName<CustomWebview>("RichTextEditor");
        }
    }
}