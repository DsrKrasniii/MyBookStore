using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public class EFPaymentRepository : IPurchaseRepository
    {
        private BookstoreContext context;
        public EFPaymentRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Pay> Payments => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(Pay payment)
        {
            context.AttachRange(payment.Lines.Select(x => x.Book));

            if (payment.PurchaseId == 0)
            {
                context.Purchases.Add(payment);
            }

            context.SaveChanges();
        }
    }
}
