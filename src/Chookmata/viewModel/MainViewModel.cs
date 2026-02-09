using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chookmata.viewModel
{
    public class MainViewModel: BaseViewModel
    {

        public SpriteViewModel Hundur { get; }
        public SpriteViewModel Kaling { get; }
        public SpriteViewModel Taowu { get; }
        public SpriteViewModel Qiongpi { get; }

        public MainViewModel()
        {

            var fKaling = LoadFrames("Assets/Sprites/Kaling");
            var fHundur = LoadFrames("Assets/Sprites/Hundur");
            var fTaowu = LoadFrames("Assets/Sprites/Taowu");
            var fQiongpi = LoadFrames("Assets/Sprites/Qiongpi");

            Hundur = new SpriteViewModel(fHundur);
            Hundur.Start();

            Taowu = new SpriteViewModel(fTaowu);
            Taowu.Start();

            Qiongpi = new SpriteViewModel(fQiongpi);
            Qiongpi.Start();

            Kaling = new SpriteViewModel(fKaling);
            Kaling.Start();
        }




        private List<ImageSource> LoadFrames(string folder)
        {

            var frames = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                var uri = new Uri($"pack://application:,,,/{folder}/stand_{i}.png");
                var bitmap = new BitmapImage(uri);
                bitmap.Freeze();
                frames.Add(bitmap);
            }
            return frames;
        }



    }
}
