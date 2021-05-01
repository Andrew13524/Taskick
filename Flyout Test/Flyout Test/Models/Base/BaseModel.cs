using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Taskick.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private string _expBackgroundColor = "#7f7f7f"; // TertiaryTextColor
        public string ExpBackgroundColor
        {
            get { return _expBackgroundColor; }
            set
            {
                _expBackgroundColor = value;
                OnPropertyChanged(nameof(ExpBackgroundColor));
            }
        }

        private string _blueColor = "#2196f3"; // Blue
        public string BlueColor
        {
            get { return _blueColor; }
            set
            {
                _blueColor = value;
                OnPropertyChanged(nameof(BlueColor));
            }
        }

        private string _greyColor = "#b3b3b3"; // SecondaryTextColor
        public string GreyColor
        {
            get { return _greyColor; }
            set
            {
                _greyColor = value;
                OnPropertyChanged(nameof(GreyColor));
            }
        }

        private string _darkColor = "#262626"; // Bottom Gradient
        public string DarkColor
        {
            get { return _darkColor; }
            set
            {
                _darkColor = value;
                OnPropertyChanged(nameof(DarkColor));
            }
        }
    }
}
