﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nimbus.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Nimbus.Resources.ErrorMessages", typeof(ErrorMessages).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
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
        ///   Consulta uma cadeia de caracteres localizada semelhante a API Key is not set!.
        /// </summary>
        internal static string ApiKeyNotSet {
            get {
                return ResourceManager.GetString("ApiKeyNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a API Path is not set!.
        /// </summary>
        internal static string ApiPathNotSet {
            get {
                return ResourceManager.GetString("ApiPathNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Base Address is not set!.
        /// </summary>
        internal static string BaseAddressNotSet {
            get {
                return ResourceManager.GetString("BaseAddressNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a HttpMessageHandler not set!.
        /// </summary>
        internal static string HttpMessageHandlerNotSet {
            get {
                return ResourceManager.GetString("HttpMessageHandlerNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a HttpMessageHandler must be set before setting the API Key.
        /// </summary>
        internal static string HttpMessageHandlerNotSetBeforeApiKey {
            get {
                return ResourceManager.GetString("HttpMessageHandlerNotSetBeforeApiKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a HttpMessageHandler must be set before setting the API path.
        /// </summary>
        internal static string HttpMessageHandlerNotSetBeforeApiPath {
            get {
                return ResourceManager.GetString("HttpMessageHandlerNotSetBeforeApiPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a HttpMessageHandler must be set before setting the Base Address.
        /// </summary>
        internal static string HttpMessageHandlerNotSetBeforeBase {
            get {
                return ResourceManager.GetString("HttpMessageHandlerNotSetBeforeBase", resourceCulture);
            }
        }
    }
}
