﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WareHouseSolution.Client.LablePrintSystem.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
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
        [global::System.Configuration.DefaultSettingValueAttribute("2.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ACCESS_TOKEN {
            get {
                return ((string)(this["ACCESS_TOKEN"]));
            }
            set {
                this["ACCESS_TOKEN"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public decimal DEFAULT_LENGTH {
            get {
                return ((decimal)(this["DEFAULT_LENGTH"]));
            }
            set {
                this["DEFAULT_LENGTH"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public decimal DEFAULT_WIDTH {
            get {
                return ((decimal)(this["DEFAULT_WIDTH"]));
            }
            set {
                this["DEFAULT_WIDTH"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal DEFAULT_HEIGHT {
            get {
                return ((decimal)(this["DEFAULT_HEIGHT"]));
            }
            set {
                this["DEFAULT_HEIGHT"] = value;
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
        [global::System.Configuration.DefaultSettingValueAttribute("http://wh.moair-logistics.com/storage/download/windows-printer/publish.htm")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("http://wh.moair-logistics.com")]
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
