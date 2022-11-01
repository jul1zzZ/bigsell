
namespace Addvesting.Modules
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.Perfomances = new HashSet<Perfomance>();
        }

        public string GetPhoto
        {
            get
            {
                return $@"{Directory.GetCurrentDirectory()}\Images\{Photo}";
            }
        }

        public double GetSale
        {
            get
            {
                return Price * 0.9;
            }
        }

        public int ServiceID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Perfomance> Perfomances { get; set; }
    }
}
