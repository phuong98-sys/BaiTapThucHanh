using Misa.ApplicationCore.Entities;
using Misa.ApplicationCore.Entity;
using Misa.ApplicationCore.Enums;
using Misa.ApplicationCore.Interface;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Misa.ApplicationCore.Services
{
    public class BaseService2<MISAEntity> : IBaseService<MISAEntity> where MISAEntity:BaseEntity
    {     

        IBaseRepository<MISAEntity> _baseRepository;
        //ICustomerContext _customerContext;
        protected ServiceResult serviceResult;
        public List<string> listError;
        string className = "";
        public BaseService2(IBaseRepository<MISAEntity> baseRepository)
        {
            this._baseRepository = baseRepository;
            //this._customerContext = customerContext;
            this.serviceResult = new ServiceResult();
            this.serviceResult.MISACode = MisaCode.Susscess;
             className = typeof(MISAEntity).Name;
        }
        #region Method
        public IEnumerable<MISAEntity> GetAll()
        {

            var entities = _baseRepository.GetAll();
            return entities;
        }
        public MISAEntity GetObjectById(Guid entityId)
        {

            var entitie = _baseRepository.GetObjectById(entityId);
            return entitie;
        }
        // Validate mã code chung
        //private ServiceResult ValidateObject<MISAEntity>(MISAEntity entity)
        //{
        //    // check xem có mã code ko
        //    var className = typeof(MISAEntity).Name;
        //    var propertyName = entity.GetType().GetProperty($"{className}Code");
        //    var propertyValue = propertyName.GetValue(entity).ToString();
        //    if (propertyName != null && (propertyValue == ""))
        //    {

        //        /***
        //         * 
        //         *  Nên dùng bên controller rồi, data để truyền số cột hợp lệ vào
        //         */

        //        //var msg = new
        //        //{
        //        //    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng bị trống" },
        //        //    userMsg = "mã khách hàng bị trống",
        //        //    code = MisaCode.NotValid,
        //        //};
        //        serviceResult.Msg = Properties.Resources.ErrorMsg_CodeEmpty;

        //        serviceResult.isValid = false; // để đánh dấu lỗi client
        //        serviceResult.MISACode = MisaCode.IsEmpty; // mã lỗi tùy từng trường hợp

        //        return serviceResult;

        //        //if (_customerContext.GetCustomerByCode(propertyValue) != null)
        //        //{
        //        //    //var msg = new
        //        //    //{
        //        //    //    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng bị trung" },
        //        //    //    userMsg = "mã khách hàng bị trung",
        //        //    //    code = MisaCode.NotValid,
        //        //    //};
        //        //    serviceResult.Msg = "Mã khách hàng bị trung";
        //        //    //serviceResult.Data = msg;
        //        //    serviceResult.isValid = false;

        //        //    serviceResult.MISACode = MisaCode.NotValid;
        //        //    return serviceResult;
        //        //}

        //    }
        //    return serviceResult;

        //}
        //check Validate chung cho các trương
        private ServiceResult ValidateObject(MISAEntity entity)
        {
            // check xem có mã code ko
           
            //var propertyName = entity.GetType().GetProperty($"{className}Code");
            //var propertyValue = propertyName.GetValue(entity).ToString();
            //if (propertyName != null && (propertyValue == ""))
            //{

            //    serviceResult.Msg = Properties.Resources.ErrorMsg_CodeEmpty;

            //    serviceResult.isValid = false; // để đánh dấu lỗi client
            //    serviceResult.MISACode = MisaCode.IsEmpty; // mã lỗi tùy từng trường hợp
            //}
            //    return serviceResult;



            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {


                //string displayName = "";
                //displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault().DisplayName;

                //try
                //{
                //    displayname = property.getcustomattributes(typeof(displaynameattribute), true).cast<displaynameattribute>().singleordefault().displayname;
                //}
                //catch (exception e)
                //{

                //    serviceresult.data = e.message;
                //    serviceresult.isvalid = false;

                //    return serviceresult;
                //}
                var propertyValue = property.GetValue(entity).ToString();
                var propertyName = property.Name;

                if (property.IsDefined(typeof(Required), false))
                {

                    if (propertyValue.Length == 0)
                    {
                        serviceResult.isValid = false;
                        serviceResult.MISACode = MisaCode.NotValid;
                        serviceResult.Msg = $"Thông tin {propertyName} không được phép để trống";
                        //listError.Add(serviceResult.Msg);
                        return serviceResult;
                    }
                   
                }
                //Nếu thuộc tính này là Unique
                if (property.IsDefined(typeof(Unique), false))
                {
                    if (!(property.GetValue(entity) is null) && (property.GetValue(entity).ToString().Length != 0))
                    {
                        var entities = _baseRepository.GetEntitiesBySpecs(property.Name, property.GetValue(entity));
                        if (entities.Count() > 0)
                        {
                            //Nếu chỉ có một entity trùng thuộc tính với entity mình đang kiểm tra
                            //thì kiểm tra xem entity đó có với entity mình đưa vào validate có phải là 1 không
                            if (entities.Count() == 1 && entity.EntityState == EntityState.Update)
                            {
                                //TODO Xử lý trường hợp entityState
                                //TODO Phải lấy được trạng thái trả về của CSDL
                                //TODO chỗ này cần kiểm tra tính hoạt động đúng
                                var secondEntity = entities.FirstOrDefault();
                                var secondEntityId = secondEntity.GetType().GetProperty($"{className}Id").GetValue(secondEntity);
                                if (!secondEntityId.Equals(entity.GetType().GetProperty($"{className}Id").GetValue(entity)))
                                {
                                    serviceResult.isValid = false;
                                    serviceResult.Msg = $"Thông tin {propertyName} bạn sửa đã trùng với một cửa hàng trong hệ thống";
                                    return serviceResult;
                                    //listError.Add($"Thông tin {propertyName} đã bị trùng");
                                }
                            }
                            //Còn nếu có nhiều hơn 1 entity giống cái mình đưa vào thì mặc định là not valid
                            else
                            {
                                serviceResult.isValid = false;
                                serviceResult.Msg = $"Thông tin {propertyName} thêm này không được phép để trùng";
                                return serviceResult;
                                //listError.Add($"Thông tin {propertyName} đã bị trùng");
                                //listError.Add($"Thông tin {propertyName} đã bị trùng");
                            }
                        }
                    }


                }
            }
            return serviceResult;

        }
        protected virtual void ValidateCustomer(MISAEntity entity)
        {

        }
        public ServiceResult InsertObject(MISAEntity entity)
        {
            try
            {
                entity.EntityState = EntityState.AddNew;
                //entity.EntityState = EntityState.AddNew;
                ValidateObject(entity);
                //ValidateCustomer<MISAEntity>(entity);
                if (serviceResult.isValid == false)
                {
                    serviceResult.Data = "Loi khong dung dinh dang";
                    serviceResult.MISACode = MisaCode.NotValid;
                    return serviceResult;
                }
                // nếu dữ liệu hợp lệ xong kiểm tra có thêm được hàng nào vào chưa
                else
                {
                    var rowAffect = _baseRepository.InsertObject(entity);
                    if (rowAffect <= 0)
                    {
                        serviceResult.Msg = Properties.Resources.ErrorMsg_NotRecordAddToDB;
                        serviceResult.Data = rowAffect;
                        serviceResult.MISACode = MisaCode.IsValid;
                        serviceResult.isValid = false;
                        return serviceResult;
                    }
                    else
                    {
                        serviceResult.MISACode = MisaCode.Susscess;
                        serviceResult.Data = rowAffect;
                        serviceResult.Msg = Properties.Resources.Susscess;
                        serviceResult.isValid = true;
                        return serviceResult;
                    }
                }


        }
            catch (Exception ex)
            {
                //var msg = new
                //{
                //{
                //    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng bị trống" },
                //    userMsg = "lỗi server",
                //    code = MisaCode.NotValid,
                //};
                serviceResult.Msg = ex.Message;
                serviceResult.Data = ex.Message;
                serviceResult.isValid = false; // để đánh dấu lỗi client
                serviceResult.MISACode = MisaCode.IsEmpty; // mã lỗi tùy từng trường hợp
                return serviceResult;
            }

}
        public ServiceResult UpdateObject(MISAEntity entity)
        {
            try
            {
                entity.EntityState = EntityState.Update;
                
                ValidateObject(entity);
                //ValidateCustomer(entity);
                if (serviceResult.isValid == false)
                {
                    serviceResult.Data = "Loi khong dung dinh dang";
                    serviceResult.MISACode = MisaCode.NotValid;
                    return serviceResult;
                }
                // nếu dữ liệu hợp lệ xong kiểm tra có thêm được hàng nào vào chưa
                else
                {
                    var rowAffect = _baseRepository.UpdateObject(entity);
                    if (rowAffect <= 0)
                    {
                        serviceResult.Msg = Properties.Resources.ErrorMsg_NotRecordAddToDB;
                        serviceResult.Data = rowAffect;
                        serviceResult.MISACode = MisaCode.IsValid;
                        serviceResult.isValid = false;
                        return serviceResult;
                    }
                    else
                    {
                        serviceResult.MISACode = MisaCode.Susscess;
                        serviceResult.Data = rowAffect;
                        serviceResult.Msg = Properties.Resources.Susscess;
                        serviceResult.isValid = true;
                        return serviceResult;
                    }
                }


            }
            catch (Exception ex)
            {
                //var msg = new
                //{
                //    devMsg = new { fieldName = "customerCode", msg = "Mã khách hàng bị trống" },
                //    userMsg = "lỗi server",
                //    code = MisaCode.NotValid,
                //};
                serviceResult.Msg = ex.Message;
                serviceResult.Data = "";
                serviceResult.isValid = false; // để đánh dấu lỗi client
                serviceResult.MISACode = MisaCode.IsEmpty; // mã lỗi tùy từng trường hợp
                return serviceResult;
            }

        }

        public int DeleteObject(Guid entityId)
        {


            //serviceResult = ValidateObject<MISAEntity>(entity);
            //ValidateCustomer<MISAEntity>(entity);
            //if (serviceResult.isValid == false)
            //{
            //    return serviceResult;
            //}
            //// nếu dữ liệu hợp lệ xong kiểm tra có thêm được hàng nào vào chưa
            //else
            //{
            //    var rowAffect = _baseRepository.InsertObject<MISAEntity>(entity);
            //    if (rowAffect <= 0)
            //    {
            //        serviceResult.Msg = Properties.Resources.ErrorMsg_NotRecordAddToDB;
            //        serviceResult.Data = rowAffect;
            //        serviceResult.MISACode = MisaCode.IsValid;
            //        serviceResult.isValid = false;
            //        return serviceResult;
            //    }
            //    else
            //    {
            //        serviceResult.MISACode = MisaCode.Susscess;
            //        serviceResult.Data = rowAffect;
            //        serviceResult.Msg = Properties.Resources.Susscess;
            //        serviceResult.isValid = true;
            //        return serviceResult;
            //    }
            //}
            var rowAffect = _baseRepository.DeleteObject(entityId);
            return rowAffect;
        }
        #endregion
    }
}
