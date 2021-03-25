using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.ApplicationCore.Interface
{
    public interface IBaseResponsitory
    {
        public IEnumerable<MISAEntity> GetAll<MISAEntity>();
        public MISAEntity GetObjectById<MISAEntity>(Guid entityId);
        public int InsertObject<MISAEntity>(MISAEntity entity);
        //public MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property);
        public int DeleteObject<MISAEntity>(Guid entityId);
        public int UpdateObject<MISAEntity>(MISAEntity entity);
    }
}
