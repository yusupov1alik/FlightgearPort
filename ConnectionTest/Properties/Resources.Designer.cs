﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18444
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConnectionTest.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ConnectionTest.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;?xml version=&quot;1.0&quot;?&gt;
        /// 
        ///&lt;PropertyList&gt;
        /// &lt;generic&gt;
        ///  &lt;input&gt;
        ///   &lt;line_separator&gt;newline&lt;/line_separator&gt;
        ///   &lt;var_separator&gt;,&lt;/var_separator&gt;
        /// 
        ///   &lt;!-- Controls --&gt;
        ///    -&lt;chunk&gt;
        ///      &lt;name&gt;Longitude Degree&lt;/name&gt;
        ///      &lt;type&gt;float&lt;/type&gt;
        ///      &lt;node&gt;/position/longitude-deg&lt;/node&gt;
        ///      &lt;format&gt;%f&lt;/format&gt;
        ///    &lt;/chunk&gt;
        ///
        ///    -&lt;chunk&gt;
        ///      &lt;name&gt;Latitude Degree&lt;/name&gt;
        ///      &lt;type&gt;float&lt;/type&gt;
        ///      &lt;node&gt;/position/latitude-deg&lt;/node&gt;
        ///      &lt;format&gt;%f&lt;/format&gt;
        ///    &lt;/chunk&gt;
        ///
        ///    -&lt;chunk&gt;
        /// [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string inputprotocol {
            get {
                return ResourceManager.GetString("inputprotocol", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;?xml version=&quot;1.0&quot;?&gt;
        /// 
        ///&lt;PropertyList&gt;
        /// &lt;generic&gt;
        ///  &lt;input&gt;
        ///   &lt;line_separator&gt;newline&lt;/line_separator&gt;
        ///   &lt;var_separator&gt;,&lt;/var_separator&gt;
        /// 
        ///   &lt;!-- Controls --&gt;
        ///    -&lt;chunk&gt;
        ///      &lt;name&gt;Longitude Degree&lt;/name&gt;
        ///      &lt;type&gt;float&lt;/type&gt;
        ///      &lt;node&gt;/ai/models/carrier[0]/position/longitude-deg&lt;/node&gt;
        ///      &lt;format&gt;%f&lt;/format&gt;
        ///    &lt;/chunk&gt;
        ///
        ///    -&lt;chunk&gt;
        ///      &lt;name&gt;Latitude Degree&lt;/name&gt;
        ///      &lt;type&gt;float&lt;/type&gt;
        ///      &lt;node&gt;/ai/models/carrier[0]/position/latitude-deg&lt;/node&gt;
        ///      &lt;format&gt;% [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string inputprotocolcarrier {
            get {
                return ResourceManager.GetString("inputprotocolcarrier", resourceCulture);
            }
        }
    }
}
