// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/*=============================================================================
**
**
**
** Purpose: Exception class for invalid arguments to a method.
**
**
=============================================================================*/

using System.Globalization;
using System.Runtime.Serialization;

namespace System
{
    // The ArgumentException is thrown when an argument does not meet 
    // the contract of the method.  Ideally it should give a meaningful error
    // message describing what was wrong and which parameter is incorrect.
    [Serializable]
    [System.Runtime.CompilerServices.TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public class ArgumentException : SystemException
    {
        private String _paramName;

        // Creates a new ArgumentException with its message 
        // string set to the empty string. 
        public ArgumentException()
            : base("Value does not fall within the expected range.")
        // TODO: SR
        //: base(SR.Arg_ArgumentException)
        {
            HResult = HResults.COR_E_ARGUMENT;
        }

        // Creates a new ArgumentException with its message 
        // string set to message. 
        // 
        public ArgumentException(String message)
            : base(message)
        {
            HResult = HResults.COR_E_ARGUMENT;
        }

        public ArgumentException(String message, Exception innerException)
            : base(message, innerException)
        {
            HResult = HResults.COR_E_ARGUMENT;
        }

        public ArgumentException(String message, String paramName, Exception innerException)
            : base(message, innerException)
        {
            _paramName = paramName;
            HResult = HResults.COR_E_ARGUMENT;
        }

        public ArgumentException(String message, String paramName)
            : base(message)
        {
            _paramName = paramName;
            HResult = HResults.COR_E_ARGUMENT;
        }

        // TODO: NotSupported
        //protected ArgumentException(SerializationInfo info, StreamingContext context)
        //    : base(info, context)
        //{
        //    _paramName = info.GetString("ParamName");
        //}

        // TODO: NotSupported
        //public override void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    base.GetObjectData(info, context);
        //    info.AddValue("ParamName", _paramName, typeof(string));
        //}

        public override String Message
        {
            get
            {
                String s = base.Message;
                if (!String.IsNullOrEmpty(_paramName))
                {
                    String resourceString = SR.Format("Parameter name: {0}", _paramName);
                    // TODO: SR
                    //String resourceString = SR.Format(SR.Arg_ParamName_Name, _paramName);
                    return s + Environment.NewLine + resourceString;
                }
                else
                    return s;
            }
        }

        public virtual String ParamName
        {
            get { return _paramName; }
        }
    }
}
