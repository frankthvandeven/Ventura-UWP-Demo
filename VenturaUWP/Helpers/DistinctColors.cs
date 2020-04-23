using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Ventura.Helpers
{
    // https://sashat.me/2017/01/11/list-of-20-simple-distinct-colors/

    public class DistinctColors
    {
        private List<DistinctColorInfo> _list;
        private int _next;

        public DistinctColors()
        {
            _list = new List<DistinctColorInfo>();
            _next = 0;

            // Start with the best colors.
            AddColor("Pink", 250, 190, 190, Colors.Black);
            AddColor("Apricot", 255, 215, 180, Colors.Black);
            AddColor("Beige", 255, 250, 200, Colors.Black);
            AddColor("Mint", 170, 255, 195, Colors.Black);
            AddColor("Lavender", 230, 190, 255, Colors.Black);

            AddColor("Navy", 0, 0, 128, Colors.White);
            AddColor("Red", 230, 25, 75, Colors.White);
            AddColor("Orange", 245, 130, 48, Colors.White);
            AddColor("Green", 60, 180, 75, Colors.White);
            AddColor("Blue", 0, 130, 200, Colors.White);
            AddColor("Cyan", 70, 240, 240, Colors.Black);

            // Not sorted out yet. Some colors are crappy.
            AddColor("Yellow", 255, 255, 25, Colors.Black);
            AddColor("Maroon", 128, 0, 0, Colors.White);
            AddColor("Brown", 170, 110, 40, Colors.White);
            AddColor("Olive", 128, 128, 0, Colors.White);
            AddColor("Teal", 0, 128, 128, Colors.White);
            AddColor("Lime", 210, 245, 60, Colors.Black);
            AddColor("Purple", 145, 30, 180, Colors.White);
            AddColor("Magenta", 240, 50, 230, Colors.White);

            // We want to start with orange
            //_next = _list.FindIndex(m => m.Name == "Orange");
        }

        private void AddColor(string name, byte r, byte g, byte b, Color foreground)
        {
            Color background = Color.FromArgb(255, r, g, b);


            var info = new DistinctColorInfo
            {
                Name = name,
                BackgroundColor = background,
                ForegroundColor = foreground,
                BackgroundBrush = new SolidColorBrush(background),
                ForegroundBrush = new SolidColorBrush(foreground)
            };

            _list.Add(info);
        }


        public DistinctColorInfo GetNextColor()
        {
            var info = _list[_next];

            _next++;

            if (_next == _list.Count)
                _next = 0;


            return info;
        }




        public DistinctColorInfo[] ToArray()
        {
            return _list.ToArray();
        }

    }

    public class DistinctColorInfo
    {
        internal DistinctColorInfo()
        {
        }

        public string Name { internal set; get; }
        public Color BackgroundColor { internal set; get; }
        public Color ForegroundColor { internal set; get; }
        public Brush BackgroundBrush { internal set; get; }
        public Brush ForegroundBrush { internal set; get; }
    }

}
