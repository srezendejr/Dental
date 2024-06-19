﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace APCD.Dados
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class APCDEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new APCDEntities object using the connection string found in the 'APCDEntities' section of the application configuration file.
        /// </summary>
        public APCDEntities() : base("name=APCDEntities", "APCDEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new APCDEntities object.
        /// </summary>
        public APCDEntities(string connectionString) : base(connectionString, "APCDEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new APCDEntities object.
        /// </summary>
        public APCDEntities(EntityConnection connection) : base(connection, "APCDEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Midias> Midias
        {
            get
            {
                if ((_Midias == null))
                {
                    _Midias = base.CreateObjectSet<Midias>("Midias");
                }
                return _Midias;
            }
        }
        private ObjectSet<Midias> _Midias;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Midias EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToMidias(Midias midias)
        {
            base.AddObject("Midias", midias);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="APCDModel", Name="Midias")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Midias : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Midias object.
        /// </summary>
        /// <param name="midiaId">Initial value of the MidiaId property.</param>
        public static Midias CreateMidias(global::System.Int32 midiaId)
        {
            Midias midias = new Midias();
            midias.MidiaId = midiaId;
            return midias;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 MidiaId
        {
            get
            {
                return _MidiaId;
            }
            set
            {
                if (_MidiaId != value)
                {
                    OnMidiaIdChanging(value);
                    ReportPropertyChanging("MidiaId");
                    _MidiaId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("MidiaId");
                    OnMidiaIdChanged();
                }
            }
        }
        private global::System.Int32 _MidiaId;
        partial void OnMidiaIdChanging(global::System.Int32 value);
        partial void OnMidiaIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MidiaNome
        {
            get
            {
                return _MidiaNome;
            }
            set
            {
                OnMidiaNomeChanging(value);
                ReportPropertyChanging("MidiaNome");
                _MidiaNome = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MidiaNome");
                OnMidiaNomeChanged();
            }
        }
        private global::System.String _MidiaNome;
        partial void OnMidiaNomeChanging(global::System.String value);
        partial void OnMidiaNomeChanged();

        #endregion
    
    }

    #endregion
    
}