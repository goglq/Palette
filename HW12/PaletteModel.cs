using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace HW12
{
    public class PaletteModel
    {
        public ObservableCollection<ColorSample> Colors { get; set; } = new ObservableCollection<ColorSample>();

        public PaletteModel()
        {
            Colors.Add(new ColorSample(Color.FromArgb(255, 200, 200, 200)));
            Colors.Add(new ColorSample(Color.FromArgb(255, 255, 0, 0)));
            Colors.Add(new ColorSample(Color.FromArgb(255, 0, 255, 0)));
        }
    }
}
