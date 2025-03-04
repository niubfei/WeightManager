﻿using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.MI.DAL
{
    public class DALDbCustomer
    {
        public void Customer_Insert(FactoryArgs args, out t_BigID CustomerID, t_String CustomerCode,t_String CustomerName, t_String Contact, t_String Phone, t_String Address, 
            t_Bool CarIsLimit,t_ID AmountType, t_String LicenceNum, t_String Description,t_ID ReceiveType,
            t_Decimal CreditAmount,t_Bool IsDisplayPrice, t_Bool IsDisplayAmount, t_Bool IsPrintAmount, t_Bool IsAllowOverFul,
            t_Bool IsAllowEmptyIn, t_Decimal AmountNotEnough, t_String K3CustomerCode, t_BigID CustomerTypeID)
        {
            CustomerTypeID.NullIfZero();
            CarIsLimit.IsNullToZero();
            IsDisplayPrice.IsNullToZero();
            IsDisplayAmount.IsNullToZero();
            IsPrintAmount.IsNullToZero();
            IsAllowOverFul.IsNullToZero();
            CreditAmount.IsNullToZero();
            CreditAmount.IsNullToZero();

            CustomerID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID, true));
            parms.Add(new LBDbParameter("CustomerCode", CustomerCode));
            parms.Add(new LBDbParameter("CustomerName", CustomerName));
            parms.Add(new LBDbParameter("CustomerTypeID", CustomerTypeID));
            parms.Add(new LBDbParameter("Contact", Contact));
            parms.Add(new LBDbParameter("Phone", Phone));
            parms.Add(new LBDbParameter("Address", Address));
            parms.Add(new LBDbParameter("CarIsLimit", CarIsLimit));
            parms.Add(new LBDbParameter("AmountType", AmountType));
            parms.Add(new LBDbParameter("LicenceNum", LicenceNum));
            parms.Add(new LBDbParameter("Description", Description));
            parms.Add(new LBDbParameter("ReceiveType", ReceiveType));
            parms.Add(new LBDbParameter("CreditAmount", CreditAmount));
            parms.Add(new LBDbParameter("IsDisplayPrice", IsDisplayPrice));
            parms.Add(new LBDbParameter("IsDisplayAmount", IsDisplayAmount));
            parms.Add(new LBDbParameter("IsPrintAmount", IsPrintAmount));
            parms.Add(new LBDbParameter("IsAllowOverFul", IsAllowOverFul));
            parms.Add(new LBDbParameter("IsAllowEmptyIn", IsAllowEmptyIn));
            parms.Add(new LBDbParameter("CreateBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("CreateTime", new t_DTSmall(DateTime.Now)));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("ChangeTime", new t_DTSmall(DateTime.Now)));
            parms.Add(new LBDbParameter("AmountNotEnough", AmountNotEnough));
            parms.Add(new LBDbParameter("K3CustomerCode", K3CustomerCode));

            string strSQL = @"
insert into dbo.DbCustomer(CustomerCode,CustomerName, Contact, Phone, Address, CarIsLimit, AmountType, LicenceNum, 
    Description, ReceiveType, CreditAmount, IsDisplayPrice, IsDisplayAmount, IsPrintAmount, IsAllowOverFul, 
    CreateBy, CreateTime, ChangeBy, ChangeTime,IsAllowEmptyIn,AmountNotEnough,K3CustomerCode, CustomerTypeID)
values(@CustomerCode, @CustomerName, @Contact, @Phone, @Address, @CarIsLimit, @AmountType, @LicenceNum, 
    @Description, @ReceiveType, @CreditAmount, @IsDisplayPrice, @IsDisplayAmount, @IsPrintAmount, @IsAllowOverFul, 
    @CreateBy, @CreateTime, @ChangeBy, @ChangeTime,@IsAllowEmptyIn,@AmountNotEnough,@K3CustomerCode, @CustomerTypeID)

set @CustomerID = @@identity
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            CustomerID.Value = Convert.ToInt64(parms["CustomerID"].Value);
        }

        public void Customer_Update(FactoryArgs args, t_BigID CustomerID, t_String CustomerName, t_String Contact, t_String Phone, t_String Address,
            t_Bool CarIsLimit, t_ID AmountType, t_String LicenceNum, t_String Description, t_ID ReceiveType,
            t_Decimal CreditAmount, t_Bool IsDisplayPrice, t_Bool IsDisplayAmount, t_Bool IsPrintAmount, t_Bool IsAllowOverFul,
            t_Bool IsAllowEmptyIn, t_Decimal AmountNotEnough, t_String K3CustomerCode, t_BigID CustomerTypeID)
        {
            CustomerTypeID.NullIfZero();
            CarIsLimit.IsNullToZero();
            IsDisplayPrice.IsNullToZero();
            IsDisplayAmount.IsNullToZero();
            IsPrintAmount.IsNullToZero();
            IsAllowOverFul.IsNullToZero();
            CreditAmount.IsNullToZero();
            CreditAmount.IsNullToZero();

            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("CustomerName", CustomerName));
            parms.Add(new LBDbParameter("CustomerTypeID", CustomerTypeID));
            parms.Add(new LBDbParameter("Contact", Contact));
            parms.Add(new LBDbParameter("Phone", Phone));
            parms.Add(new LBDbParameter("Address", Address));
            parms.Add(new LBDbParameter("CarIsLimit", CarIsLimit));
            parms.Add(new LBDbParameter("AmountType", AmountType));
            parms.Add(new LBDbParameter("LicenceNum", LicenceNum));
            parms.Add(new LBDbParameter("Description", Description));
            parms.Add(new LBDbParameter("ReceiveType", ReceiveType));
            parms.Add(new LBDbParameter("CreditAmount", CreditAmount));
            parms.Add(new LBDbParameter("IsDisplayPrice", IsDisplayPrice));
            parms.Add(new LBDbParameter("IsDisplayAmount", IsDisplayAmount));
            parms.Add(new LBDbParameter("IsPrintAmount", IsPrintAmount));
            parms.Add(new LBDbParameter("IsAllowOverFul", IsAllowOverFul));
            parms.Add(new LBDbParameter("IsAllowEmptyIn", IsAllowEmptyIn));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("ChangeTime", new t_DTSmall(DateTime.Now)));
            parms.Add(new LBDbParameter("AmountNotEnough", AmountNotEnough));
            parms.Add(new LBDbParameter("K3CustomerCode", K3CustomerCode));

            string strSQL = @"
update dbo.DbCustomer
set CustomerName = @CustomerName, 
    Contact=@Contact, 
    Phone=@Phone, 
    Address=@Address, 
    CarIsLimit=@CarIsLimit, 
    AmountType=@AmountType, 
    LicenceNum=@LicenceNum, 
    Description=@Description,
    ReceiveType=@ReceiveType, 
    CreditAmount=@CreditAmount, 
    IsDisplayPrice=@IsDisplayPrice, 
    IsDisplayAmount=@IsDisplayAmount, 
    IsPrintAmount=@IsPrintAmount, 
    IsAllowOverFul=@IsAllowOverFul, 
    ChangeBy=@ChangeBy, 
    ChangeTime=@ChangeTime,
    IsAllowEmptyIn = @IsAllowEmptyIn,   
    AmountNotEnough = @AmountNotEnough,
    K3CustomerCode = @K3CustomerCode,
    CustomerTypeID = @CustomerTypeID
where CustomerID =  @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void Customer_Delete(FactoryArgs args, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));

            string strSQL = @"
delete dbo.DbCustomer
where CustomerID = @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void GetMaxCode(FactoryArgs args, out t_String MaxCode)
        {
            MaxCode = new t_String();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("MaxCode", MaxCode, true));
            string strSQL = @"
    select top 1 @MaxCode = CustomerCode
    from dbo.DbCustomer
    order by CustomerCode desc
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            MaxCode.SetValueWithObject(parms["MaxCode"].Value);
        }

        public DataTable GetCustomerByName(FactoryArgs args, t_BigID CustomerID, t_String CustomerName)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("CustomerName", CustomerName));
            string strSQL = @"
if @CustomerID = 0
begin
    select CustomerName
    from dbo.DbCustomer
    where CustomerName=@CustomerName
end
else
begin
    select CustomerName
    from dbo.DbCustomer
    where CustomerName=@CustomerName and CustomerID<>@CustomerID
end
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable GetCustomerByName(FactoryArgs args,  t_String CustomerName)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerName", CustomerName));
            string strSQL = @"
    select CustomerName
    from dbo.DbCustomer
    where CustomerName=@CustomerName
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable GetCustomerByID(FactoryArgs args, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            string strSQL = @"
    select *
    from dbo.DbCustomer
    where CustomerID=@CustomerID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable GetCarByCustomer(FactoryArgs args, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            string strSQL = @"
select *
from dbo.DbCustomerCar
where CustomerID = @CustomerID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void UpdateAmount(FactoryArgs args, t_BigID CustomerID, t_Decimal TotalReceivedAmount, t_Decimal SalesReceivedAmount)
        {
            TotalReceivedAmount.IsNullToZero();
            SalesReceivedAmount.IsNullToZero();

            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("TotalReceivedAmount", TotalReceivedAmount));
            parms.Add(new LBDbParameter("SalesReceivedAmount", SalesReceivedAmount));

            string strSQL = @"
update dbo.DbCustomer
set TotalReceivedAmount = @TotalReceivedAmount, 
    SalesReceivedAmount=@SalesReceivedAmount
where CustomerID =  @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void Forbid(FactoryArgs args, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("ForbidBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("ForbidTime", new t_DTSmall(DateTime.Now)));

            string strSQL = @"
update dbo.DbCustomer
set IsForbid = 1, 
    ForbidBy=@ForbidBy, 
    ForbidTime=@ForbidTime
where CustomerID =  @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }
        public void UnForbid(FactoryArgs args, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));

            string strSQL = @"
update dbo.DbCustomer
set IsForbid = 0, 
    ForbidBy=null, 
    ForbidTime=null
where CustomerID =  @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }
    }
}
