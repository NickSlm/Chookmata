using Chookmata.viewModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

public class SpriteViewModel : BaseViewModel
{
    private readonly List<ImageSource> _frames;
    private int _index;
    private readonly double _frameDurationMs;
    private readonly Stopwatch _stopwatch = new Stopwatch();
    private double _lastFrameTimeMs;

    public ImageSource CurrentFrame { get; private set; }

    public SpriteViewModel(IEnumerable<ImageSource> frames, double fps = 16)
    {
        _frames = new List<ImageSource>(frames);
        if (_frames.Count == 0) throw new ArgumentException("No frames provided");

        CurrentFrame = _frames[0];
        _frameDurationMs = 1000.0 / fps;
    }

    public void Start()
    {
        _stopwatch.Restart();
        _lastFrameTimeMs = 0;
        CompositionTarget.Rendering += OnRendering;
    }

    public void Stop()
    {
        CompositionTarget.Rendering -= OnRendering;
        _stopwatch.Stop();
    }

    private void OnRendering(object sender, EventArgs e)
    {
        double totalElapsedMs = _stopwatch.Elapsed.TotalMilliseconds;

        while (totalElapsedMs - _lastFrameTimeMs >= _frameDurationMs)
        {
            _lastFrameTimeMs += _frameDurationMs;

            _index = (_index + 1) % _frames.Count;
            CurrentFrame = _frames[_index];
            OnPropertyChanged(nameof(CurrentFrame));
        }
    }
}
