using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface CityDeliveryService
    {
        List<TbCityDeliveryFees> getAll();
        bool Add(TbCityDeliveryFees client);
        bool Edit(TbCityDeliveryFees client);
        bool Delete(TbCityDeliveryFees client);


    }
    public class ClsCityDeliveryFees : CityDeliveryService
    {
        TawredatDbContext ctx;
        CityService cityService;
        public ClsCityDeliveryFees(CityService CityService, TawredatDbContext context)
        {
            cityService = CityService;
            ctx = context;
        }
        public List<TbCityDeliveryFees> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbCityDeliveryFees> lstCityDeliveryFeess = ctx.TbCityDeliveryFeess.ToList();

            return lstCityDeliveryFeess;
        }

        public bool Add(TbCityDeliveryFees item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                item.CityName = cityService.getAll().Where(a => a.CityId == item.CityId).FirstOrDefault().CityName;
                ctx.TbCityDeliveryFeess.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbCityDeliveryFees item)
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

        public bool Delete(TbCityDeliveryFees item)
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
