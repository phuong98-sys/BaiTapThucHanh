
using Misa.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.ApplicationCore
{
    public interface IBaseServiceN
    {
        public IEnumerable<MISAEntity> GetAll<MISAEntity>();
        public MISAEntity GetObjectById<MISAEntity>(Guid entityId);
        public ServiceResult InsertObject<MISAEntity>(MISAEntity entity);

        public int DeleteObject<MISAEntity>(Guid entityId);
        public ServiceResult UpdateObject<MISAEntity>(MISAEntity entity);
    }
}
