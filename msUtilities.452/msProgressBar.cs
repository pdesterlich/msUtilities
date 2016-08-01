using System;
using System.Text;
using System.Threading;

namespace msUtilities
{

    /**
   * msProgressBar
   * a simple and efficient command line progress bar
   *
   * based on https://gist.github.com/DanielSWolf/0ab6a96899cc5377bf54
   * by Daniel Wolf (https://github.com/DanielSWolf)
   * slightly modified by Phelipe de Sterlich (https://github.com/pdesterlich)
   * - removed IProgress to target .net 2.0 and above
   * - added constructor options to allow minimal customization
   *
   * usage:
   * -----
   * using (var progress = new msProgressBar(50, false))
   *   {
   *     for (int i = 0; i <= 100; i++)
   *       {
   *         progress.Report((double)i / 100);
   *         Thread.Sleep(20);
   *       }
   *     }
   *   }
   **/

    public class MsProgressBar : IDisposable
    {

        private readonly int _blockCount;
        private readonly bool _showPercent;

        private readonly TimeSpan _animationInterval = TimeSpan.FromSeconds(1.0 / 8);
        private const string Animation = @"|/-\";

        private readonly Timer _timer;

        private double _currentProgress;
        private string _currentText = string.Empty;
        private bool _disposed;
        private int _animationIndex;

        public MsProgressBar(int blockCount = 10, bool showPercent = true)
        {
            _showPercent = showPercent;
            _blockCount = blockCount;

            _timer = new Timer(TimerHandler);

            ResetTimer();
        }

        public void Report(double value)
        {
            // Make sure value is in [0..1] range
            value = Math.Max(0, Math.Min(1, value));
            Interlocked.Exchange(ref _currentProgress, value);
        }

        private void TimerHandler(object state)
        {
            lock (_timer)
            {
                if (_disposed) return;

                var progressBlockCount = (int)(_currentProgress * _blockCount);
                var percent = (int)(_currentProgress * 100);

                string text;
                if (_showPercent)
                {
                    text = string.Format("[{0}{1}] {2,3}% {3}",
                      new string('#', progressBlockCount),
                      new string('-', _blockCount - progressBlockCount),
                      percent,
                      Animation[_animationIndex++ % Animation.Length]);
                }
                else
                {
                    text = string.Format("[{0}{1}] {2}",
                      new string('#', progressBlockCount),
                      new string('-', _blockCount - progressBlockCount),
                      Animation[_animationIndex++ % Animation.Length]);
                }
                UpdateText(text);

                ResetTimer();
            }
        }

        private void UpdateText(string text)
        {
            // Get length of common portion
            var commonPrefixLength = 0;
            var commonLength = Math.Min(_currentText.Length, text.Length);
            while (commonPrefixLength < commonLength && text[commonPrefixLength] == _currentText[commonPrefixLength])
            {
                commonPrefixLength++;
            }

            // Backtrack to the first differing character
            var outputBuilder = new StringBuilder();
            outputBuilder.Append('\b', _currentText.Length - commonPrefixLength);

            // Output new suffix
            outputBuilder.Append(text.Substring(commonPrefixLength));

            // If the new text is shorter than the old one: delete overlapping characters
            var overlapCount = _currentText.Length - text.Length;
            if (overlapCount > 0)
            {
                outputBuilder.Append(' ', overlapCount);
                outputBuilder.Append('\b', overlapCount);
            }

            Console.Write(outputBuilder);
            _currentText = text;
        }

        private void ResetTimer()
        {
            _timer.Change(_animationInterval, TimeSpan.FromMilliseconds(-1));
        }

        public void Dispose()
        {
            lock (_timer)
            {
                _disposed = true;
                UpdateText(string.Empty);
            }
        }

    }

}