using System;
using System.Collections.Generic;

namespace frontend
{
  public class AppState
  {
    private List<string> _imgSources = new List<string>()
      {
      "https://cdn.discordapp.com/attachments/755020353201373244/895224365711511612/image0.png",
      };
    public IReadOnlyList<string> ImgSources { get => _imgSources.AsReadOnly(); }
    public event Action OnListUpdate;

    public void Add(string imgSource)
    {
      _imgSources.Add(imgSource);
      OnListUpdate?.Invoke();
    }
  }
}