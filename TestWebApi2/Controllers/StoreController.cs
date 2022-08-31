using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebApi2.Models;

namespace TestWebApi2.Controllers
{
    public class StoreController : ApiController
    {
        Entities db = new Entities();

        //Add Post Request
        public string Post(Store store)
        {
            db.Stores.Add(store);
            db.SaveChanges();
            return "Store Added";
        }

        //Get All Records
        public IEnumerable<Store> Get()
        {
            return db.Stores.ToList();
        }

        //Get Single Product
        public Store Get(int id)
        {
            Store store = db.Stores.Find(id);
            return store;
        }

        //Update the record
        public string Put(int id, Store store)
        {
            var store_ = db.Stores.Find(id);
            store_.StoreNumber = store.StoreNumber;
            store_.StoreName = store.StoreName;
            store_.City = store.City;
            store_.State = store.State;
            store_.Phone = store.Phone;

            db.Entry(store_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return "Store Updated";
        }

        //Delete The Record
        public string Delete(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
            db.SaveChanges();
            return "Deleted";
        }

    }
}
