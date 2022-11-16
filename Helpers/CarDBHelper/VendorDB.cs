using ProjectPooja.CarDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPooja.Helpers.CarDBHelper
{
    public class VendorDB
    {
        CarServiceContext db;
        public VendorDB(CarServiceContext db)
        {
            this.db = db;
        }

        public bool InsertServiceCenter(ServiceCenter sc)
        {
            try
            {
                var servicecenter = db.ServiceCenters.Add(new ServiceCenter { Address = sc.Address, Centerpickup = sc.Centerpickup, ServiceCenterName = sc.ServiceCenterName, VendorId = sc.VendorId });
                if (db.SaveChanges() > 0)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertServicestoServiceCenter(Service s)
        {
            try
            {
                //var servicecenter = db.ServiceCenters.Where(x => x.ServiceCenterId == sc.ServiceCenterId).FirstOrDefault();
                var service = db.Services.Add(new Service { Active = true, ServiceCenterId = s.ServiceCenterId, Servicename = s.Servicename });
                if (db.SaveChanges() > 0)
                    return true;

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ServiceCenter Servicecenter(ServiceCenter sc)
        {
            var center = db.ServiceCenters.FirstOrDefault(x => x.Address == sc.Address || x.ServiceCenterName == sc.ServiceCenterName || x.VendorId == sc.VendorId);

            return center;
        }

        public List<ServiceCenter> GetAllCenters()
        {
            return db.ServiceCenters.ToList();
        }

        public bool ServiceApproval()
        {
            try
            {
                var pending_approvals = db.Bookings.Where(x => x.Active).ToList();
                foreach (var i in pending_approvals)
                {
                    i.VendorApproval = true; // for now all the orders will be approved by the vendor
                    i.Active = true;
                    db.SaveChangesAsync();
                }
                return true;
            }

            catch(Exception e)
            {
                return false;
            }

        }


    }
}
