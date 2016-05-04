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

  public class msProgressBar : IDisposable
  {

    private int blockCount = 20;
    private bool showPercent = true;

    private readonly TimeSpan animationInterval = TimeSpan.FromSeconds(1.0 / 8);
    private const string animation = @"|/-\";

    private readonly Timer timer;

    private double currentProgress = 0;
    private string currentText = string.Empty;
    private bool disposed = false;
    private int animationIndex = 0;

    public msProgressBar(int blockCount = 10, bool showPercent = true)
    {
      this.showPercent = showPercent;
      this.blockCount = blockCount;

      timer = new Timer(TimerHandler);

      ResetTimer();
    }

    public void Report(double value)
    {
      // Make sure value is in [0..1] range
      value = Math.Max(0, Math.Min(1, value));
      Interlocked.Exchange(ref currentProgress, value);
    }

    private void TimerHandler(object state)
    {
      lock (timer)
      {
        if (disposed) return;

        int progressBlockCount = (int)(currentProgress * blockCount);
        int percent = (int)(currentProgress * 100);

        String text = "";
        if (showPercent)
        {
          text = string.Format("[{0}{1}] {2,3}% {3}",
            new string('#', progressBlockCount), new string('-', blockCount - progressBlockCount),
            percent,
            animation[animationIndex++ % animation.Length]);
        }
        else
        {
          text = string.Format("[{0}{1}] {2}",
            new string('#', progressBlockCount), new string('-', blockCount - progressBlockCount),
            animation[animationIndex++ % animation.Length]);
        }
        UpdateText(text);

        ResetTimer();
      }
    }

    private void UpdateText(string text)
    {
      // Get length of common portion
      int commonPrefixLength = 0;
      int commonLength = Math.Min(currentText.Length, text.Length);
      while (commonPrefixLength < commonLength && text[commonPrefixLength] == currentText[commonPrefixLength])
      {
        commonPrefixLength++;
      }

      // Backtrack to the first differing character
      StringBuilder outputBuilder = new StringBuilder();
      outputBuilder.Append('\b', currentText.Length - commonPrefixLength);

      // Output new suffix
      outputBuilder.Append(text.Substring(commonPrefixLength));

      // If the new text is shorter than the old one: delete overlapping characters
      int overlapCount = currentText.Length - text.Length;
      if (overlapCount > 0)
      {
        outputBuilder.Append(' ', overlapCount);
        outputBuilder.Append('\b', overlapCount);
      }

      Console.Write(outputBuilder);
      currentText = text;
    }

    private void ResetTimer()
    {
      timer.Change(animationInterval, TimeSpan.FromMilliseconds(-1));
    }

    public void Dispose()
    {
      lock (timer)
      {
        disposed = true;
        UpdateText(string.Empty);
      }
    }

  }

}