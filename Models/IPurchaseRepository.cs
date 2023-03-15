using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<Pay> Payments { get; }

        void SavePurchase(Pay payment);
    }
}
