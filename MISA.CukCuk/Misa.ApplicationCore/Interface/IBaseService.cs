
using Misa.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.ApplicationCore
{
    /// <summary>
    /// Interface của service base
    /// </summary>
    /// <typeparam name="MISAEntity">Kiểu thực thể thực hiện</typeparam>
    /// Author: Nguyễn Thị Phượng (26/3/2021)
    public interface IBaseService<MISAEntity>
    {
        public IEnumerable<MISAEntity> GetAll();
        public MISAEntity GetObjectById(Guid entityId);
        public ServiceResult InsertObject(MISAEntity entity);

        public int DeleteObject(Guid entityId);
        public ServiceResult UpdateObject(MISAEntity entity);
        
    }
}
