//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projects_Engineers_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PE_CCity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PE_CCity()
        {
            this.PE_UserLocation = new HashSet<PE_UserLocation>();
        }
    
        public int Id_City { get; set; }
        public Nullable<int> Id_State { get; set; }
        public string City { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PE_UserLocation> PE_UserLocation { get; set; }
        public virtual PE_CState PE_CState { get; set; }
    }
}
