using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.ApplicationCore.Interface
{
    public interface IBaseResponsitory<MISAEntity>
    {
        public IEnumerable<MISAEntity> GetAll();
        public MISAEntity GetObjectById(Guid entityId);
        public int InsertObject(MISAEntity entity);
        //public MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property);
        public int DeleteObject(Guid entityId);
        public int UpdateObject(MISAEntity entity);
        public IEnumerable<MISAEntity> GetEntitiesBySpecs(string propertyName, object propertyValue);

    }
}
