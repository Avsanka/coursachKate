//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Ticket
    {
        [Required]
        public int Ticket_ID { get; set; }
        [Required]
        [DisplayName("Ряд")]
        public int row { get; set; }
        [Required]
        [DisplayName("Место")]
        public int place { get; set; }
        [Required]
        public System.DateTime purchase_datetine { get; set; }
        [Required]
        public int ID_Session { get; set; }
        [Required]
        [DisplayName("Ваш номер телефона")]
        [MinLength(11)]
        [MaxLength(12)]
        public string phonenumber { get; set; }
        [Required]
        [DisplayName("Цена")]
        public int price { get; set; }
    
        public virtual Session Session { get; set; }
    }
}
