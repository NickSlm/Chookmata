using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;

namespace Chookmata.viewModel
{
    public class MainViewModel: BaseViewModel
    {

        private ImageSource _selectedPhase;

        public MainViewModel()
        {
            CreateObjects();

            SelectCommand = new AsyncRelayCommand<SpriteViewModel>(SelectPhase);
        }


        private void CreateObjects()
        {
            var Hundur = new SpriteViewModel("Assets/Sprites/Hundur");
            var Taowu = new SpriteViewModel("Assets/Sprites/Taowu");
            var Qiongpi = new SpriteViewModel("Assets/Sprites/Qiongpi");
            var Kaling = new SpriteViewModel("Assets/Sprites/Kaling");
            var KalingP3 = new SpriteViewModel("Assets/Sprites/KalingP3");

            Sprites.Add(Hundur);
            Sprites.Add(Taowu);
            Sprites.Add(Qiongpi);
            Sprites.Add(Kaling);
            Sprites.Add(KalingP3);
        }

        public async Task SelectPhase(SpriteViewModel sprite)
        {
            sprite.Selected = true;
            SelectedPhase = sprite.StringImage;
        }

        public IAsyncRelayCommand<SpriteViewModel> SelectCommand { get; }

        public ObservableCollection<SpriteViewModel> Sprites { get; } = new();
        public ImageSource SelectedPhase
        {
            get => _selectedPhase;
            set
            {
                _selectedPhase = value;
                OnPropertyChanged(nameof(SelectedPhase));
            }
        }

    }
}
