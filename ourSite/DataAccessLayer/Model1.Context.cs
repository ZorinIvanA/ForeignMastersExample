﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class StudentsEntities : DbContext
    {
        public StudentsEntities()
            : base("name=StudentsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Students> Students { get; set; }
    
        public virtual int spAddStudent(string fIO, Nullable<System.DateTime> birthday, Nullable<int> cityID, ObjectParameter studentId)
        {
            var fIOParameter = fIO != null ?
                new ObjectParameter("FIO", fIO) :
                new ObjectParameter("FIO", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("Birthday", birthday) :
                new ObjectParameter("Birthday", typeof(System.DateTime));
    
            var cityIDParameter = cityID.HasValue ?
                new ObjectParameter("CityID", cityID) :
                new ObjectParameter("CityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddStudent", fIOParameter, birthdayParameter, cityIDParameter, studentId);
        }
    }
}