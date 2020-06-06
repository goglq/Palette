using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HW12
{
    public class ColorSample : INotifyPropertyChanged
    {
        private static int idCounter = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        private Color color;
        public Color Color{
            get => color;
            set {
                if (color == value)
                    return;
                color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        public string ColorCode => color.ToString();

        public Brush ColorBrush => new SolidColorBrush(color);

        public ColorSample(Color color)
        {
            Id = idCounter++;
            Color = color;
        }
    }
}
