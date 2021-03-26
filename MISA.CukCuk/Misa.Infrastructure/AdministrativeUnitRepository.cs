using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Misa.Infrastructure
{
    class AdministrativeUnitRepository<T> :BaseRepository<T>
    {
        string procName = "";
        public AdministrativeUnitRepository()
        {
           
        }
        public IEnumerable<T> GetByCountry()
        {
            procName = $"Proc_GetByCountry";
            var entities = _dbConnection.Query<T>(procName, commandType: CommandType.StoredProcedure);
            return entities;
        }
    }
}
