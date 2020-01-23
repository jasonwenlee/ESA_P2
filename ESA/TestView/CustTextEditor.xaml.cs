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
    public partial class CustTextEditor : StackLayout
    {
        public CustTextEditor()
        {
            InitializeComponent();
            RichTextEditor.Source = App.urlSource;
        }
    }
}