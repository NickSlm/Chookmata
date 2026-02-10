using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Chookmata.viewModel
{
    public class MainViewModel: BaseViewModel
    {
        public ObservableCollection<SpriteViewModel> Sprites { get; } = new();

        public MainViewModel()
        {

            var fKaling = LoadFrames("Assets/Sprites/Kaling");
            var fKalingP3 = LoadFrames("Assets/Sprites/KalingP3");
            var fHundur = LoadFrames("Assets/Sprites/Hundur");
            var fTaowu = LoadFrames("Assets/Sprites/Taowu");
            var fQiongpi = LoadFrames("Assets/Sprites/Qiongpi");

            var Hundur = new SpriteViewModel(fHundur);
            var Taowu = new SpriteViewModel(fTaowu);
            var Qiongpi = new SpriteViewModel(fQiongpi);
            var Kaling = new SpriteViewModel(fKaling);
            var KalingP3 = new SpriteViewModel(fKalingP3);


            Sprites.Add(Hundur);
            Sprites.Add(Taowu);
            Sprites.Add(Qiongpi);
            Sprites.Add(Kaling);
            Sprites.Add(KalingP3);

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
