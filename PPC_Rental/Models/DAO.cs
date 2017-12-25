using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace PPC_Rental.Models
{
    public class DAO
    {
        // PPC_RentalEntities db = null;
        DemoPPCRentalEntities1 db = null;
        public  DAO()
        {
            db = new DemoPPCRentalEntities1();
        }
        public long Insert(USER entity)
        {
            db.USERs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public long InsertProperty(PROPERTY entity)
        {
            var property = db.PROPERTies.Find(entity.ID);
            db.PROPERTies.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public PROPERTY ViewDetail(int id)
        {
            return db.PROPERTies.Find(id);
        }
        public bool Update(PROPERTY entitys)
        {
                var property = db.PROPERTies.Find(entitys.ID);
                property.PropertyName = entitys.PropertyName;
               if(entitys.ImageFile == null)
                {

                }
                else
                {
                    property.Avatar = entitys.Avatar;
                }
                if (entitys.ImageFile1 == null)
                {

                }
                else
                {
                    property.Images = entitys.Images;
                }
                property.PropertyType_ID = entitys.PropertyType_ID;
                property.Content = entitys.Content;
                property.Street_ID = entitys.Street_ID;
                property.Ward_ID = entitys.Ward_ID;
                property.District_ID = entitys.District_ID;
                property.Price = entitys.Price;
                property.Area = entitys.Area;
                property.BedRoom = entitys.BedRoom;
                property.BathRoom = entitys.BathRoom;
                property.PackingPlace = entitys.PackingPlace;
                property.Status_ID = entitys.Status_ID;
                if(entitys.Status_ID== 3)
                {
                property.Create_post = DateTime.Parse(DateTime.Now.ToShortDateString());
                String.Format("{0:dd/MM/yyyy}", property.Updated_at);
                }
                else
                {
                    property.Create_post = null;
                }
                property.Note = entitys.Note;
                property.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                String.Format("{0:dd/MM/yyyy}", property.Updated_at);
                property.Sale_ID = entitys.Sale_ID;
                db.SaveChanges();
                return true;
          

        }
        public IEnumerable<PROPERTY> ListAllPaging(int page, int pageSize,int x1)
        {
            return db.PROPERTies.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public IEnumerable<PROPERTY> UserListAllPaging(int page, int pageSize, int x1)
        {
            return db.PROPERTies.Where(x => x.UserID == x1).OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public IEnumerable<NEWS> ListNewsPaging(int page,int pageSize)
        {
            return db.NEWS.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
       

        public USER GetID(string userName)
        {
            return db.USERs.SingleOrDefault(x => x.Email == userName);

        }
        public int Login(string userName, string passWord)
        {

            // sing or find
            var res = db.USERs.SingleOrDefault(x => x.Email == userName);

            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (res.Password == passWord)
                        return 1;
                    else
                        return -2;

                }
            }

        }

        public bool CheckUserName(string email)
        {
            return db.USERs.Count(x => x.Email == email) > 0;
        }
        public bool CheckPropertyName(string propertyname)
        {
            return db.PROPERTies.Count(x => x.PropertyName == propertyname) > 0;
        }
        
    }
}