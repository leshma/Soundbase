//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Soundbase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Performed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Performed()
        {
            this.Created = new HashSet<Created>();
        }
    
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public int Id { get; set; }
    
        public virtual Song Song { get; set; }
        public virtual Artist Artist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Created> Created { get; set; }
    }
}
