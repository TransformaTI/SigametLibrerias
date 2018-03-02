using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

    [DataContract]
    public class Version
    {
        public Version()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        string descripcionVersion;
        [DataMember]
        public string DescripcionVersion 
        {
            get { return descripcionVersion; }
            set { descripcionVersion = value; }
        }

        bool denegarAcceso;
        [DataMember]
        public bool DenegarAcceso
        {
            get { return denegarAcceso; }
            set { denegarAcceso = value; }
        }
    }