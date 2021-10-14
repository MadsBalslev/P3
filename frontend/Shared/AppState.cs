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

    //public List<Institution> institutions = new List<Institution>();

    public event Action OnInstitutionUpdate;
    public void AddInstitution(Institution inst)
    {
      _institutions.Add(inst);
      OnInstitutionUpdate?.Invoke();
    }
    public void RemoveInstitution()
    {

    }

    public List<User> users = new List<User>();
    public void AddUser(User user)
    {
      users.Add(user);
    }

    public bool Auth { get; private set; }// = true;
    public string Role {get; private set;}// = "sys_admin";
    private List<CPoster> _posters = new List<CPoster>()
      {
      new CPoster("Test", "12/10-2021", "15/10-2021", "https://cdn.discordapp.com/attachments/755020353201373244/895224365711511612/image0.png"),
      };
    public IReadOnlyList<CPoster> Posters { get => _posters.AsReadOnly(); }
    public event Action OnListUpdate;
    public event Action OnAuthChange;
    public event Action OnPosterAdd;

    public void AddPoster(CPoster poster)
    {
      _posters.Add(poster);
      OnPosterAdd?.Invoke();
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

    private List<Institution> _institutions = new List<Institution>();
    public IReadOnlyList<Institution> Institutions { get => _institutions.AsReadOnly();}

    private List<Zone> _zones = new List<Zone>();
    public IReadOnlyList<Zone> Zones {get => _zones.AsReadOnly();}
    public event Action OnZoneAdd;

    public void AddZone(Zone zone)
    {
      _zones.Add(zone);
      OnZoneAdd?.Invoke();
    }

    private List<Screen> _screens = new List<Screen>();
    public IReadOnlyList<Screen> Screens {get => _screens.AsReadOnly();}
    public event Action OnScreenAdd;

    public void AddScreen(Screen screen)
    {
      _screens.Add(screen);
      OnScreenAdd?.Invoke();
    }
  }


  
}