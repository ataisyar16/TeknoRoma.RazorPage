﻿using TeknoRoma.Entities.Entities.Abstract;

namespace TeknoRoma.Entities.Entities.Concrete
{
    public class SiparisDetay : BaseEntity
    {
        public string SiparisId { get; set; }
        public string StokId { get; set; }
        public int Miktar { get; set; }
        public double BirimFiyat { get; set; }

        // Navigation Properties
        public Siparis Siparis { get; set; }
        public Stok Stok { get; set; }
    }
}
