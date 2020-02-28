﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleQuick.Business.Models
{
    public partial class InvoiceHeader
    {
        public InvoiceHeader()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hours { get; set; }
        [Required]
        [StringLength(5)]
        public string Voucher { get; set; }
        public int PointOfSale { get; set; }
        public int CurrentAccount { get; set; }
        [Column("CAE")]
        public int Cae { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Subtotal { get; set; }
        [Column("IVAIns", TypeName = "decimal(18, 2)")]
        public decimal Ivains { get; set; }
        [Column("IVARni", TypeName = "decimal(18, 2)")]
        public decimal Ivarni { get; set; }
        [Column("IVARG3337", TypeName = "decimal(18, 2)")]
        public decimal Ivarg3337 { get; set; }
        [Column("IIBB", TypeName = "decimal(18, 2)")]
        public decimal Iibb { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
        public int? VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        [InverseProperty("InvoiceHeaders")]
        public virtual Vehicle Vehicle { get; set; }
        [InverseProperty(nameof(InvoiceDetail.InvoiceHeader))]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}