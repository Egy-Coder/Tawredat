using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface SupplierSubscriptionService
    {
        List<TbSupplierSubscription> getAll();
        bool Add(TbSupplierSubscription client);
        bool Edit(TbSupplierSubscription client);
        bool Delete(TbSupplierSubscription client);


    }
    public class ClsSupplierSubscription : SupplierSubscriptionService
    {
        TawredatDbContext ctx;

        public ClsSupplierSubscription(TawredatDbContext context)
        {
            ctx = context;
        }
        public List<TbSupplierSubscription> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbSupplierSubscription> lstSupplierSubscriptions = ctx.TbSupplierSubscriptions.ToList();

            return lstSupplierSubscriptions;
        }

        public bool Add(TbSupplierSubscription item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbSupplierSubscriptions.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbSupplierSubscription item)
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

        public bool Delete(TbSupplierSubscription item)
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
