﻿using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Models;

namespace ProTips.Entity.Repository;

public class TeamRepository : Repository<Team>
{
    public TeamRepository(MySqlContext context) : base(context)
    {
    }
}