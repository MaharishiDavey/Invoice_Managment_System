﻿using Invoice.DataAccess.Data;
using Invoice.DataAccess.Repository.IRepository;
using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.DataAccess.Repository
{
    public class PartyDetailRepository : Repository<PartyDetail>, IPartyDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public PartyDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PartyDetail obj)
        {
            _db.PartyDetails.Update(obj);

        }
    }
}
