﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShengXinSolution.Client.LablePrintSystem.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.0")]
        public string CLIENT_VERSION {
            get {
                return ((string)(this["CLIENT_VERSION"]));
            }
            set {
                this["CLIENT_VERSION"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("80")]
        public string API_SERVER_PORT {
            get {
                return ((string)(this["API_SERVER_PORT"]));
            }
            set {
                this["API_SERVER_PORT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("/sxn")]
        public string API_BASE_URL {
            get {
                return ((string)(this["API_BASE_URL"]));
            }
            set {
                this["API_BASE_URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://sdm-mail.com/sxn/download/lable-print-system-install/publish.htm")]
        public string CLIENT_UPDATE_URL {
            get {
                return ((string)(this["CLIENT_UPDATE_URL"]));
            }
            set {
                this["CLIENT_UPDATE_URL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("服务器配置修改")]
        public string UPDATE_LOG {
            get {
                return ((string)(this["UPDATE_LOG"]));
            }
            set {
                this["UPDATE_LOG"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UPDATE_LOG_READ_YN {
            get {
                return ((bool)(this["UPDATE_LOG_READ_YN"]));
            }
            set {
                this["UPDATE_LOG_READ_YN"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10000")]
        public int HTTP_REQUEST_TIMEOUT {
            get {
                return ((int)(this["HTTP_REQUEST_TIMEOUT"]));
            }
            set {
                this["HTTP_REQUEST_TIMEOUT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int WEIGHT_PRECISION {
            get {
                return ((int)(this["WEIGHT_PRECISION"]));
            }
            set {
                this["WEIGHT_PRECISION"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://sdm-mail.com")]
        public string API_SERVER_HOST {
            get {
                return ((string)(this["API_SERVER_HOST"]));
            }
            set {
                this["API_SERVER_HOST"] = value;
            }
        }
    }
}
