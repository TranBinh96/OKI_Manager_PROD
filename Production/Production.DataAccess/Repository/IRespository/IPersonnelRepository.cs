﻿using Production.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.DataAccess.Repository.IRespository
{
    public interface IPersonnelRepository : IRepository<Personnel>
    {
        void Update(Personnel obj);
    }
}
