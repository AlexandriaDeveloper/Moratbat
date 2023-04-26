using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class BaseEntityModel
    {

        public virtual int Id { get; set; }
        [MaxLength(200)]
        public virtual string Name { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CteaedAt { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsUpdated => UpdatedAt.HasValue ? true : false;

        public string DeletedBy { get; set; }
        public DateTime? DeleteddAt { get; set; }
        public bool IsDeleted => DeleteddAt.HasValue ? true : false;
    }
}