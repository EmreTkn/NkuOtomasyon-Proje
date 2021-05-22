

using System;
using System.Collections;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly NkuContext _context;
        private Hashtable _repositories; //İşlem sonunda kullanılmak için oluşturalacak repository instancelarını tutmak için bir hashtable oluşturuldu.

        public UnitOfWork(NkuContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>()
        {
            if (_repositories==null) //hash durum kontrolü yapılıp boşsa oluşturuluyor.
            {
                _repositories=new Hashtable();
            }

            var type = typeof(TEntity).Name; //girilen nesnenin ismi alınıyor.
            if (!_repositories.ContainsKey(type))// eğer bu isimde bir repository yok ise oluşturmak için kontrol yapılıyor.
            {
                var repositoryType = typeof(GenericRepository<>); //generic olarak type alınıyor.
                var repositoryInstance =
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context); //Instance oluşturuluyor
                _repositories.Add(type, repositoryInstance);  
            }

            return (IGenericRepository<TEntity>) _repositories[type]; 
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
