﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CopyToolWpfApp {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    internal sealed partial class CopyToolSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static CopyToolSettings defaultInstance = ((CopyToolSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new CopyToolSettings())));
        
        public static CopyToolSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SourcePath {
            get {
                return ((string)(this["SourcePath"]));
            }
            set {
                this["SourcePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DestinationPath {
            get {
                return ((string)(this["DestinationPath"]));
            }
            set {
                this["DestinationPath"] = value;
            }
        }
    }
}
