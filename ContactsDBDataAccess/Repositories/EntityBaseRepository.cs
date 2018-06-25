using ContactsDBDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ContactsDBDataAccess.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class
    {
        private ContactsDBEntities _contactsDBEntities;
        private DbSet<T> dbSet;

        public EntityBaseRepository(ContactsDBEntities contactsDBEntities)
        {
            _contactsDBEntities = contactsDBEntities;
            this.dbSet = contactsDBEntities.Set<T>();
        }
        public IList<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _contactsDBEntities.Set<T>().Add(entity);
            _contactsDBEntities.SaveChanges();
        }

        public bool Update(T entity)
        {
            _contactsDBEntities.Entry<T>(entity).State = EntityState.Modified;
            _contactsDBEntities.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            T entityToDelete = dbSet.Find(id);
            if (entityToDelete == null)
                return false;
            _contactsDBEntities.Set<T>().Remove(entityToDelete);
            _contactsDBEntities.SaveChanges();
            return true;
        }
    }
}
