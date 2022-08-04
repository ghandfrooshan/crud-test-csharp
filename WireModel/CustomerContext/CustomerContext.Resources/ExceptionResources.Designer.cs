﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerContext.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CustomerContext.Resources.ExceptionResources", typeof(ExceptionResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to شماره حساب بانکی نامعتبر می باشد! .
        /// </summary>
        public static string BankAccountNumberIsNotValidException {
            get {
                return ResourceManager.GetString("BankAccountNumberIsNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to مشتری مورد نظر با مشخصات وارد شده قبلا ثبت شده است !.
        /// </summary>
        public static string CustomerExistedAlreadyException {
            get {
                return ResourceManager.GetString("CustomerExistedAlreadyException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to فرمت تاریخ نامعتبر می باشد! .
        /// </summary>
        public static string DateFormatIsNotValidException {
            get {
                return ResourceManager.GetString("DateFormatIsNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ایمیل وارد شده قبلا ثبت شده است ! .
        /// </summary>
        public static string EmailExistedAlreadyException {
            get {
                return ResourceManager.GetString("EmailExistedAlreadyException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to فرمت ایمیل نا معتبر می باشد !.
        /// </summary>
        public static string EmailFormatIsNotValidException {
            get {
                return ResourceManager.GetString("EmailFormatIsNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to فیلد مورد نظر اجباری می باشد!.
        /// </summary>
        public static string FieldIsRequiredException {
            get {
                return ResourceManager.GetString("FieldIsRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to فرمت شماره تماس وارد شده صحیح نمی باشد ! شماره موبایل با فرمت صحیح وارد شود ..
        /// </summary>
        public static string PhoneNumberIsNotValidException {
            get {
                return ResourceManager.GetString("PhoneNumberIsNotValidException", resourceCulture);
            }
        }
    }
}
