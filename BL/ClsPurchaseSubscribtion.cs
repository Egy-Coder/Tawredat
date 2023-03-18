using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface PurchaserSubscriptionService
    {
        List<TbPurchaseSubscribtion> getAll();
        bool Add(TbPurchaseSubscribtion client);
        bool Edit(TbPurchaseSubscribtion client);
        bool Delete(TbPurchaseSubscribtion client);


    }
    public class ClsPurchaseSubscribtion : PurchaserSubscriptionService
    {
        TawredatDbContext ctx;

        public ClsPurchaseSubscribtion(TawredatDbContext context)
        {
            ctx = context;
        }
        public List<TbPurchaseSubscribtion> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbPurchaseSubscribtion> lstSupplierSubscriptions = ctx.TbPurchaseSubscribtions.ToList();

            return lstSupplierSubscriptions;
        }

        public bool Add(TbPurchaseSubscribtion item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbPurchaseSubscribtions.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbPurchaseSubscribtion item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbPurchaseSubscribtion item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
