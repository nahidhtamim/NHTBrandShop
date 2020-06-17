using NHTBrandShop.DB;
using NHTBrandShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTBrandShop.Services
{
    public class TagServices
    {
        public IEnumerable<Tag> GetAllTags()
        {
            var context = new BrandShopContext();

            return context.Tags.ToList();
        }

        public Tag GetTagByID(int ID)
        {
            using (var context = new BrandShopContext())
            {
                return context.Tags.Find(ID);
            }
        }

        public bool SaveTag(Tag tag)
        {
            var context = new BrandShopContext();

            context.Tags.Add(tag);

            return context.SaveChanges() > 0;
        }

        public bool UpdateTag(Tag tag)
        {
            var context = new BrandShopContext();

            context.Entry(tag).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteTag(Tag tag)
        {
            var context = new BrandShopContext();

            context.Entry(tag).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
