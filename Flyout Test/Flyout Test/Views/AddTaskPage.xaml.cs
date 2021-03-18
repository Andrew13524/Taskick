using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Flyout_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        public IList<string> DifficultyList
        {
            get
            {
                return new List<string> { "Easy", "Medium", "Hard" };
            }
        }
        public AddTaskPage()
        {
            InitializeComponent();
        }
    }
}