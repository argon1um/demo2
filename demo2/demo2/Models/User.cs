using System;
using System.Collections.Generic;

namespace demo2.Models;

public partial class User
{
    public int Userid { get; set; }

    public string? Usersurname { get; set; }

    public string? Username { get; set; }

    public string? Userpatronymic { get; set; }

    public string? Userlogin { get; set; }

    public string? Userpassword { get; set; }

    public int? Userroleid { get; set; }

    public virtual Role? Userrole { get; set; }
}
