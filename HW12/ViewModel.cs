using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace HW12
{
    public class ViewModel : BindableBase
    {
        private PaletteModel Model { get; }

        public ICommand OnAddColor { get; private set; }
        public ICommand OnDeleteColor { get; private set; }

        private IList<ColorSample> colors;
        public IList<ColorSample> Colors {
            get => colors;
            set {
                SetProperty(ref colors, value);
            }
        }

        private bool isAlphaEnabled;
        public bool IsAlphaEnabled {
            get => isAlphaEnabled;
            set {
                SetProperty(ref isAlphaEnabled, value);
                ColorBrush = CreateBrush();
            }
        }

        private bool isRedEnabled;
        public bool IsRedEnabled {
            get => isRedEnabled;
            set {
                SetProperty(ref isRedEnabled, value);
                ColorBrush = CreateBrush();
            }
        }

        private bool isGreenEnabled;
        public bool IsGreenEnabled {
            get => isGreenEnabled;
            set {
                SetProperty(ref isGreenEnabled, value);
                ColorBrush = CreateBrush();
            }
        }

        private bool isBlueEnabled;
        public bool IsBlueEnabled {
            get => isBlueEnabled;
            set {
                SetProperty(ref isBlueEnabled, value);
                ColorBrush = CreateBrush();
            }
        }

        private byte alpha;
        public byte Alpha {
            get => alpha;
            set {
                if (alpha == value)
                    return;
                SetProperty(ref alpha, value);
                ColorBrush = CreateBrush();
            }
        }

        private byte red;
        public byte Red {
            get => red;
            set {
                if (red == value)
                    return;
                SetProperty(ref red, value);
                ColorBrush = CreateBrush();
            }
        }

        private byte green;
        public byte Green {
            get => green;
            set {
                if (green == value)
                    return;
                SetProperty(ref green, value);
                ColorBrush = CreateBrush();
            }
        }

        private byte blue;
        public byte Blue {
            get => blue;
            set {
                if (blue == value)
                    return;
                SetProperty(ref blue, value);
                ColorBrush = CreateBrush();
            }
        }

        private Brush colorBrush;
        public Brush ColorBrush {
            get => colorBrush;
            set {
                if (colorBrush == value)
                    return;
                SetProperty(ref colorBrush, value);
            }
        }

        public ViewModel(PaletteModel model) {
            Model = model;
            Colors = Model.Colors;

            OnAddColor = new DelegateCommand(AddColor);
            OnDeleteColor = new DelegateCommand<int?>(DeleteColor);
        }

        private SolidColorBrush CreateBrush() => 
            new SolidColorBrush(Color.FromArgb(
                isAlphaEnabled ? alpha : (byte)0, 
                isRedEnabled ? red : (byte)0, 
                isGreenEnabled ? green : (byte)0, 
                isBlueEnabled ? blue : (byte)0));

        private void AddColor()
        {
            Model.Colors.Add(new ColorSample(
                Color.FromArgb(
                    isAlphaEnabled ? alpha : (byte)0,
                    isRedEnabled ? red : (byte)0,
                    isGreenEnabled ? green : (byte)0, 
                    isBlueEnabled ? blue : (byte)0)));
        }

        private void DeleteColor(int? id)
        {
            ColorSample removingColor = Model.Colors.Where(color => color.Id == id).First();
            Model.Colors.Remove(removingColor);
        }
    }
}
