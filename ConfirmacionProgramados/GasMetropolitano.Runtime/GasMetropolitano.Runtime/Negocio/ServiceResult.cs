using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMetropolitano.Runtime.Negocio
{
    using System.Runtime.Serialization;

    [DataContract]
    public abstract class ServiceResult
    {
        protected Exception internalException;

        protected string internalExceptionMsg;

        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Class
        {
            get
            {
                return this.GetType().Name;
            }
            set
            {
            }
        }
        [DataMember]
        public string Method
        {
            get
            {
                string method;
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
                method  = stackTrace.GetFrame(0).GetMethod().Name;
                stackTrace = null;
                return method;
            }
            set
            {
            }
        }
        [DataMember]
        public string InternalException
        {
            get
            {
                StringBuilder _mensaje = new StringBuilder();

                if (internalException != null)
                {
                    _mensaje.Append("Class:");
                    _mensaje.AppendLine(this.Class);
                    _mensaje.Append("Method:");
                    _mensaje.AppendLine(this.Method);
                    _mensaje.AppendLine("Exception:");
                    _mensaje.AppendLine(internalException.ToString());
                    if (internalException.InnerException != null)
                    {
                        _mensaje.AppendLine("Inner Exception:");
                        _mensaje.AppendLine(internalException.InnerException.ToString());
                    }
                }
                else
                {
                    _mensaje.Append(internalExceptionMsg);
                }

                return _mensaje.ToString();
            }
            set
            {
                internalExceptionMsg = value;
            }
        }
    }
}
