//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Tampinhas.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Organization))]
    [KnownType(typeof(Place))]
    public partial class Place
    {
        public Place()
        {
            this.OrganizationsByDisctrict = new HashSet<Organization>();
            this.OrganizationsByCounty = new HashSet<Organization>();
            this.District = new HashSet<Place>();
        }
    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Nullable<int> ParentId { get; set; }
    
        [DataMember]
        public virtual ICollection<Organization> OrganizationsByDisctrict { get; set; }
        [DataMember]
        public virtual ICollection<Organization> OrganizationsByCounty { get; set; }
        [DataMember]
        public virtual Place County { get; set; }
        [DataMember]
        public virtual ICollection<Place> District { get; set; }
    }
    
}
