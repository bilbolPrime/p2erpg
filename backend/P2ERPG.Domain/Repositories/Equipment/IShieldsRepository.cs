﻿using BilbolStack.Boonamai.P2ERPG.Domain.Entities;
using BilbolStack.Boonamai.P2ERPG.Domain.Entities.Equipment;

namespace BilbolStack.Boonamai.P2ERPG.Domain.Repositories.Equipment
{
    public interface IShieldsRepository
    {
        Task<Shield> GetAsync(int shieldId, long mintId);
        Task<IEnumerable<Shield>> GetAsync(string wallet);
        Task UpdateAsync(IEnumerable<Shield> shields);
        Task UpdateAsync(Shield shield);
        Task UpdateAsync(IEnumerable<NFTOwnership> nFTOwnerships);
    }
}