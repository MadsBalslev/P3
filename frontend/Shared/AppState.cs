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

    public List<Institution> institutions = new List<Institution>();

    public event Action OnInstitutionUpdate;
    public void AddInstitution(Institution inst)
    {
      institutions.Add(inst);
      OnInstitutionUpdate?.Invoke();
    }
    public void RemoveInstitution()
    {

    }
    public void EditInstitution(Institution institution)
    {
  
        int index = institutions.FindIndex(item => item.Navn == institution.Navn);
        if (index >= 0) 
        {
            Console.WriteLine("bang");
            institutions[index].Navn = "hej";
            institutions[index].Admin = "XD";
        }
    }

    public List<User> users = new List<User>();

    public void AddUser(User user)
    {
      users.Add(user);
    }

    public List<Screen> screens = new List<Screen>();
    public void AddScreen (Screen screen)
    {
      screens.Add(screen);
    }

    public List<Zone> zones = new List<Zone>();
    public void AddZone (Zone zone)
    {
      zones.Add(zone);
    }

    public bool Auth { get; private set; }
    public string Role {get; private set;}
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
  }


  
}