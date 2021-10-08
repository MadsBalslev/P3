using System;
using System.Collections.Generic;

namespace frontend
{
  public class AppState
  {
    private List<string> _users = new List<string>()
      {
        "user",
        "inst_admin",
        "sys_admin"
      };

    private bool _auth = false;
    public bool Auth { get; private set; }
    public string Role {get; private set;}
    private List<string> _imgSources = new List<string>()
      {
      "https://cdn.discordapp.com/attachments/755020353201373244/895224365711511612/image0.png",
      };
    public IReadOnlyList<string> ImgSources { get => _imgSources.AsReadOnly(); }
    public event Action OnListUpdate;
    public event Action OnAuthChange;

    public void AddPoster(string imgSource)
    {
      _imgSources.Add(imgSource);
      OnListUpdate?.Invoke();
    }

    public bool Login(string user)
    {
      if (_users.Contains(user))
      {
        Auth = true;
        Role = user;
        System.Console.WriteLine(Role);
        OnAuthChange?.Invoke();
        return true;
      }
      else
      {
        OnAuthChange?.Invoke();
        return false;
      }
    }

    public void LogOut()
    {
      Auth = false;
    }
  }
}