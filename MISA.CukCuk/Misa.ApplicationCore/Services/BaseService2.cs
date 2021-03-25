using Misa.ApplicationCore.Entities;
using Misa.ApplicationCore.Enums;
using Misa.ApplicationCore.Interface;
using Misa.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Misa.ApplicationCore.Services
{
    public class BaseService2 : IBaseService
    {

        IBaseResponsitory _baseResponsitory;
        //ICustomerContext _customerContext;
        protected ServiceResult serviceResult;
        List<string> listError;
        public BaseService2(IBaseResponsitory baseResponsitory)
        {
            this._baseResponsitory = baseResponsitory;
            //this._customerContext = customerContext;
            this.serviceResult = new ServiceResult();
            this.serviceResult.MISACode = MisaCode.Susscess;

        }
        #region Method
        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {

            var entities = _baseResponsitory.GetAll<MISAEntity>();
            return entities;
        }
        public MISAEntity GetObjectById<MISAEntity>(Guid entityId)
        {

            var entitie = _baseResponsitory.GetObjectById<MISAEntity>(entityId);
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
        private ServiceResult ValidateObject<MISAEntity>(MISAEntity entity)
        {
            // check xem có mã code ko
            var className = typeof(MISAEntity).Name;
            //var propertyName = entity.GetType().GetProperty($"{className}Code");
            //var propertyValue = propertyName.GetValue(entity).ToString();
            //if (propertyName != null && (propertyValue == ""))
            //{

            //    serviceResult.Msg = Properties.Resources.ErrorMsg_CodeEmpty;

            //    serviceResult.isValid = false; // để đánh dấu lỗi client
            //    serviceResult.MISACode = MisaCode.IsEmpty; // mã lỗi tùy từng trường hợp
            //}
            //    return serviceResult;
            string displayName = "";
          
            
                var properties = entity.GetType().GetProperties();

                foreach (var property in properties)
                {
                    string propertyValue = property.GetValue(entity).ToString();
                    var propertyName = property.Name;
                    displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault().DisplayName;
                    if (property.IsDefined(typeof(Required), false))
                    {
                        if (propertyValue.Length == 0)
                        {
                            serviceResult.isValid = false;
                            serviceResult.MISACode = MisaCode.NotValid;
                            serviceResult.Msg = $"Thông tin {displayName} không được phép để trống";
                            listError.Add(serviceResult.Msg);
                        }
                    }
                    ////if (property.IsDefined(typeof(CheckDuplicate), false))
                    ////{
                    //var propertyName2 = property.Name;
                    ////var entityDuplicate = _baseResponsitory.GetEntityByProperty();
                    ////if (entityDuplicate != null)
                    ////{
                    //   serviceResult.isValid = false;
                    //    serviceResult.Msg = Properties.Resources.ErrorMsg_CodeDupplicate;
                    //    listError.Add(serviceResult.Msg);
                    //    serviceResult.MISACode = MisaCode.NotValid;
                    //}

                    //}

                }
                return serviceResult;
           
        }
        protected virtual void ValidateCustomer<MISAEntity>(MISAEntity entity)
        {

        }
        public ServiceResult InsertObject<MISAEntity>(MISAEntity entity)
        {
            try
            {
                //entity.EntityState = EntityState.AddNew;
                serviceResult = ValidateObject<MISAEntity>(entity);
                ValidateCustomer<MISAEntity>(entity);
                if (serviceResult.isValid == false)
                {
                    serviceResult.Msg = "Loi khong dung dinh dang";
                    serviceResult.MISACode = MisaCode.NotValid;
                    return serviceResult;
                }
                // nếu dữ liệu hợp lệ xong kiểm tra có thêm được hàng nào vào chưa
                else
                {
                    var rowAffect = _baseResponsitory.InsertObject<MISAEntity>(entity);
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
                serviceResult.Msg = "Lỗi server";
                serviceResult.Data = ex.Message;
                serviceResult.isValid = false; // để đánh dấu lỗi client
                serviceResult.MISACode = MisaCode.IsEmpty; // mã lỗi tùy từng trường hợp
                return serviceResult;
            }

        }
        public ServiceResult UpdateObject<MISAEntity>(MISAEntity entity)
        {
            try
            {

                serviceResult = ValidateObject<MISAEntity>(entity);
                ValidateCustomer<MISAEntity>(entity);
                if (serviceResult.isValid == false)
                {
                    return serviceResult;
                }
                // nếu dữ liệu hợp lệ xong kiểm tra có thêm được hàng nào vào chưa
                else
                {
                    var rowAffect = _baseResponsitory.UpdateObject<MISAEntity>(entity);
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
                serviceResult.Msg = "Lỗi server - sửa";
                serviceResult.Data = ex.Message;
                serviceResult.isValid = false; // để đánh dấu lỗi client
                serviceResult.MISACode = MisaCode.IsEmpty; // mã lỗi tùy từng trường hợp
                return serviceResult;
            }

        }

        public int DeleteObject<MISAEntity>(Guid entityId)
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
            //    var rowAffect = _baseResponsitory.InsertObject<MISAEntity>(entity);
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
            var rowAffect = _baseResponsitory.DeleteObject<MISAEntity>(entityId);
            return rowAffect;
        }
        #endregion
    }
}
