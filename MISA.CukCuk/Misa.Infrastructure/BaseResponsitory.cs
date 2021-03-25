using Dapper;
using Misa.ApplicationCore.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Misa.Infrastructure
{   
    /// <summary>
    /// class cha xử lí kết nối database cho cá class khác kế thừa
    /// CreatedBy:Nguyễn Thị Phượng
    /// CreatedBy: 25/3/2021
    /// </summary>
    public class BaseResponsitory:IBaseResponsitory
    {
        /// <summary>
        /// chuỗi kết nối đến database
        /// </summary>
        protected string _connectionString = "Host= 47.241.69.179;" +
                "Port=3306;" +
                "Database=MF753_NTPHUONG_ESHOP;" +
                "User Id = dev;" +
                "Password=12345678";
        protected IDbConnection _dbConnection;
        public BaseResponsitory()
        {
            _dbConnection = new MySqlConnection(_connectionString);

        }
        /// <summary>
        /// Hàm lấy thông tin tất cả các đối tượng 
        /// </summary>
        /// <typeparam name="T">Tên của lớp đối tượng đang xét</typeparam>
        /// <returns>Các bản ghi với đối tượng tương ứng</returns>
        public IEnumerable<T> GetAll<T>()
        {
            var className = typeof(T).Name;
            var procName = $"Proc_Get{className}s";
            var entities = _dbConnection.Query<T>(procName, commandType: CommandType.StoredProcedure);
            return entities;
        }
        /// <summary>
        /// Lấy thông tin của đối tượng theo id
        /// </summary>
        /// <typeparam name="T">Tên của lớp đối tượng đang xét</typeparam>
        /// <param name="entityId">Khóa chính của đối tượng</param>
        /// <returns>bản ghi có mã tương ứng</returns>
        public T GetObjectById<T>(Guid entityId)
        {
            var className = typeof(T).Name;
            var procName = $"Proc_Get{className}ById";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add($"{className}Id", entityId.ToString());
            var entity = _dbConnection.Query<T>(procName, param: dynamicParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }
        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <typeparam name="T">Tên của lớp đối tượng đang xét</typeparam>
        /// <param name="entity">đối tượng cần xét</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public int InsertObject<T>(T entity)
        {

            // xử lí các  kiểu dữ liệu
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if ((propertyType == typeof(Guid)) || (propertyType == typeof(Guid?)))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            //Thêm dữ liệu, trả về số bản ghi thêm mới được
            var className = typeof(T).Name;
            var procName = $"Proc_Insert{className}";
            var rowAffect = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }
        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <typeparam name="T">Tên của lớp đối tượng đang xét</typeparam>
        /// <param name="entityId"> Khóa chính của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public int DeleteObject<T>(Guid entityId)
        {
            var className = typeof(T).Name;
            //var customerId = entity.GetType().GetProperty($"{className}Id");
            var dynamicParams = new DynamicParameters();

            dynamicParams.Add($"{className}Id", entityId.ToString());
            var procName = $"Proc_Delete{className}";
            var rowAffect = _dbConnection.Execute(procName, param: dynamicParams, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }
        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <typeparam name="T">Tên của lớp đối tượng đang xét</typeparam>
        /// <param name="entity">Tên đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public int UpdateObject<T>(T entity)
        {

            // xử lí các  kiểu dữ liệu
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if ((propertyType == typeof(Guid)) || (propertyType == typeof(Guid?)))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }
            //Thêm dữ liệu, trả về số bản ghi thêm mới được
            var className = typeof(T).Name;
            var procName = $"Proc_Update{className}";
            var rowAffect = _dbConnection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }
        //public T GetEntityByProperty<T>(T entity, PropertyInfo property)
        //{
        //    var className = typeof(T).Name;
        //    var propertyName = property.Name;
        //    var propertyValue = property.GetValue(entity);
        //    var keyValue = entity.GetType().GetProperty($"{className}Id").GetValue(entity);
        //    var query = string.Empty;
        //    if (entity.En)
        //        var entityReturn = _dbConnection.Query<T>(query, commandType: CommandType.Text).FirstOrDefault();


        //    return entityReturn;
        //}
    }
}

