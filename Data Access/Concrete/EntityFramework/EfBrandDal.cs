using Core.DataAccess.EntityFramework;
using Data_Access.Abstract;
using Entities.Concrete;

namespace Data_Access.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapProjectContext>, IBrandDal
    {
    }
}
