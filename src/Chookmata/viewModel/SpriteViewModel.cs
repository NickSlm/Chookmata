using Chookmata.viewModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class SpriteViewModel : BaseViewModel
{
    private bool _selected = false;
    private string _path;

    public SpriteViewModel(string path)
    {
        _path = path;
        InitializeAssets();
    }

    private void InitializeAssets()
    {
        IdleImage = Load($"pack://application:,,,/{_path}/idle.png");
        StringImage = Load($"pack://application:,,,/{_path}/string.png");
    }

    private ImageSource Load(string uriString)
    {
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.UriSource = new Uri(uriString, UriKind.Absolute);
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.EndInit();
        bitmap.Freeze();

        return bitmap;
    }

    public ImageSource IdleImage { get; private set; }
    public ImageSource StringImage { get; private set; }
    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            OnPropertyChanged(nameof(Selected));
        }
    }

}
