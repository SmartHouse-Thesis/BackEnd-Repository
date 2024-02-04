using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } 
        public DateTime? CreationDate { get; set; } //ngày tạo 
        public Guid? CreatedBy { get; set; } // tạo bởi ai 
        public DateTime? ModificationDate { get; set; } // ngày chỉnh sửa
        public Guid? ModificationBy { get; set; } // chỉnh bởi ai
        public bool? IsDelete { get; set; } // xóa Status
        public Guid? DeletedBy { get; set; } //xóa bởi ai 
         

    }
}
