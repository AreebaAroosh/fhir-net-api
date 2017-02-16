﻿using System;
using System.Collections.Generic;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;

/*
  Copyright (c) 2011+, HL7, Inc.
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
  

*/

//
// Generated for FHIR v1.8.0
//
namespace Hl7.Fhir.Model
{
    /// <summary>
    /// Links records for 'same' item
    /// </summary>
    [FhirType("Linkage", IsResource=true)]
    [DataContract]
    public partial class Linkage : Hl7.Fhir.Model.DomainResource, System.ComponentModel.INotifyPropertyChanged
    {
        [NotMapped]
        public override ResourceType ResourceType { get { return ResourceType.Linkage; } }
        [NotMapped]
        public override string TypeName { get { return "Linkage"; } }
        
        /// <summary>
        /// Used to distinguish different roles a resource can play within a set of linked resources
        /// (url: http://hl7.org/fhir/ValueSet/linkage-type)
        /// </summary>
        [FhirEnumeration("LinkageType")]
        public enum LinkageType
        {
            /// <summary>
            /// MISSING DESCRIPTION
            /// (system: http://hl7.org/fhir/linkage-type)
            /// </summary>
            [EnumLiteral("source"), Description("Source of truth")]
            Source,
            /// <summary>
            /// MISSING DESCRIPTION
            /// (system: http://hl7.org/fhir/linkage-type)
            /// </summary>
            [EnumLiteral("alternate"), Description("Alternate record")]
            Alternate,
            /// <summary>
            /// MISSING DESCRIPTION
            /// (system: http://hl7.org/fhir/linkage-type)
            /// </summary>
            [EnumLiteral("historical"), Description("Historical/obsolete record")]
            Historical,
        }

        [FhirType("ItemComponent")]
        [DataContract]
        public partial class ItemComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            [NotMapped]
            public override string TypeName { get { return "ItemComponent"; } }
            
            /// <summary>
            /// source | alternate | historical
            /// </summary>
            [FhirElement("type", InSummary=true, Order=40)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Code<Hl7.Fhir.Model.Linkage.LinkageType> TypeElement
            {
                get { return _TypeElement; }
                set { _TypeElement = value; OnPropertyChanged("TypeElement"); }
            }
            
            private Code<Hl7.Fhir.Model.Linkage.LinkageType> _TypeElement;
            
            /// <summary>
            /// source | alternate | historical
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public Hl7.Fhir.Model.Linkage.LinkageType? Type
            {
                get { return TypeElement != null ? TypeElement.Value : null; }
                set
                {
                    if (!value.HasValue)
                        TypeElement = null; 
                    else
                        TypeElement = new Code<Hl7.Fhir.Model.Linkage.LinkageType>(value);
                    OnPropertyChanged("Type");
                }
            }
            
            /// <summary>
            /// Resource being linked
            /// </summary>
            [FhirElement("resource", InSummary=true, Order=50)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.ResourceReference Resource
            {
                get { return _Resource; }
                set { _Resource = value; OnPropertyChanged("Resource"); }
            }
            
            private Hl7.Fhir.Model.ResourceReference _Resource;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as ItemComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(TypeElement != null) dest.TypeElement = (Code<Hl7.Fhir.Model.Linkage.LinkageType>)TypeElement.DeepCopy();
                    if(Resource != null) dest.Resource = (Hl7.Fhir.Model.ResourceReference)Resource.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new ItemComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as ItemComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(TypeElement, otherT.TypeElement)) return false;
                if( !DeepComparable.Matches(Resource, otherT.Resource)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as ItemComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(TypeElement, otherT.TypeElement)) return false;
                if( !DeepComparable.IsExactly(Resource, otherT.Resource)) return false;
                
                return true;
            }


            [NotMapped]
            public override IEnumerable<Base> Children
            {
                get
                {
                    // BackboneElement elements
                    foreach (var elem in ModifierExtension) { if (elem != null) yield return elem; }
                    // ItemComponent elements
                    if (TypeElement != null) yield return TypeElement;
                    if (Resource != null) yield return Resource;
                }
            }
            
        }
        
        
        /// <summary>
        /// Who is responsible for linkages
        /// </summary>
        [FhirElement("author", InSummary=true, Order=90)]
        [CLSCompliant(false)]
		[References("Practitioner","Organization")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Author
        {
            get { return _Author; }
            set { _Author = value; OnPropertyChanged("Author"); }
        }
        
        private Hl7.Fhir.Model.ResourceReference _Author;
        
        /// <summary>
        /// Item to be linked
        /// </summary>
        [FhirElement("item", InSummary=true, Order=100)]
        [Cardinality(Min=1,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Linkage.ItemComponent> Item
        {
            get { if(_Item==null) _Item = new List<Hl7.Fhir.Model.Linkage.ItemComponent>(); return _Item; }
            set { _Item = value; OnPropertyChanged("Item"); }
        }
        
        private List<Hl7.Fhir.Model.Linkage.ItemComponent> _Item;
        

        public override void AddDefaultConstraints()
        {
            base.AddDefaultConstraints();

        }

        public override IDeepCopyable CopyTo(IDeepCopyable other)
        {
            var dest = other as Linkage;
            
            if (dest != null)
            {
                base.CopyTo(dest);
                if(Author != null) dest.Author = (Hl7.Fhir.Model.ResourceReference)Author.DeepCopy();
                if(Item != null) dest.Item = new List<Hl7.Fhir.Model.Linkage.ItemComponent>(Item.DeepCopy());
                return dest;
            }
            else
            	throw new ArgumentException("Can only copy to an object of the same type", "other");
        }
        
        public override IDeepCopyable DeepCopy()
        {
            return CopyTo(new Linkage());
        }
        
        public override bool Matches(IDeepComparable other)
        {
            var otherT = other as Linkage;
            if(otherT == null) return false;
            
            if(!base.Matches(otherT)) return false;
            if( !DeepComparable.Matches(Author, otherT.Author)) return false;
            if( !DeepComparable.Matches(Item, otherT.Item)) return false;
            
            return true;
        }
        
        public override bool IsExactly(IDeepComparable other)
        {
            var otherT = other as Linkage;
            if(otherT == null) return false;
            
            if(!base.IsExactly(otherT)) return false;
            if( !DeepComparable.IsExactly(Author, otherT.Author)) return false;
            if( !DeepComparable.IsExactly(Item, otherT.Item)) return false;
            
            return true;
        }

        [NotMapped]
        public override IEnumerable<Base> Children
        {
            get
            {
				// Linkage elements
				if (Author != null) yield return Author;
				foreach (var elem in Item) { if (elem != null) yield return elem; }
            }
        }
    }
    
}