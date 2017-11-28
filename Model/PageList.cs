using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.


namespace Model
{
    public class PageList
    {
        // PPC_RentalEntities db = null;
        DemoPPCRentalEntities2 db = null;
        public  PageList()
        {
            db = new DemoPPCRentalEntities2();
        }
        public long Insert(USER entity)
        {
            db.USERs.Add(entity);
            db.SaveChangesAsync();
            return entity.ID;
        }
        public long InsertProperty(PROPERTY entity)
        {
            db.PROPERTies.Add(entity);
            db.SaveChangesAsync();
            return entity.ID;
        }
        public PROPERTY ViewDetail(int id)
        {
            return db.PROPERTies.Find(id);
        }
        public bool Update(PROPERTY entitys)
        {
            try
            {
                var property = db.PROPERTies.Find(entitys.ID);
                property.PropertyName = entitys.PropertyName;
                property.Images = entitys.Images;
                property.PropertyType_ID = entitys.PropertyType_ID;
                property.Content = entitys.Content;
                property.Street_ID = entitys.Street_ID;
                property.Ward_ID = entitys.Ward_ID;
                property.District_ID = entitys.District_ID;
                property.Price = entitys.Price;
                property.UnitPrice = entitys.UnitPrice;
                property.Area = entitys.Area;
                property.BedRoom = entitys.BedRoom;
                property.BathRoom = entitys.BathRoom;
                property.PackingPlace = entitys.PackingPlace;
                property.UserID = entitys.UserID;
                //property.Created_at = DateTime.Parse(DateTime.Now.ToString("yyyy-mm-dd"));
                //property.Create_post = DateTime.Parse(DateTime.Now.ToString("yyyy-mm-dd"));
                property.Status_ID = entitys.Status_ID;
                property.Note = entitys.Note;
                //property.Updated_at = DateTime.Parse(DateTime.Now.ToString("yyyy-mm-dd"));
                property.Updated_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                property.Sale_ID = entitys.Sale_ID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public IEnumerable<PROPERTY> ListAllPaging(int page, int pageSize)
        {
            return db.PROPERTies.OrderByDescending(x => x.PropertyName).ToPagedList(page, pageSize);
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
    }
}
