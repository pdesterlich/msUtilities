﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace msUtilities.Database {
    using System;
    
    
    /// <summary>
    ///   Classe di risorse fortemente tipizzata per la ricerca di stringhe localizzate e così via.
    /// </summary>
    // Questa classe è stata generata automaticamente dalla classe StronglyTypedResourceBuilder.
    // tramite uno strumento quale ResGen o Visual Studio.
    // Per aggiungere o rimuovere un membro, modificare il file con estensione ResX ed eseguire nuovamente ResGen
    // con l'opzione /str oppure ricompilare il progetto VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Restituisce l'istanza di ResourceManager nella cache utilizzata da questa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("msUtilities.Database.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Esegue l'override della proprietà CurrentUICulture del thread corrente per tutte le
        ///   ricerche di risorse eseguite utilizzando questa classe di risorse fortemente tipizzata.
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
        ///   Cerca una stringa localizzata simile a cancel.
        /// </summary>
        internal static string buttonCancel {
            get {
                return ResourceManager.GetString("buttonCancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a hide.
        /// </summary>
        internal static string buttonHide {
            get {
                return ResourceManager.GetString("buttonHide", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a ok.
        /// </summary>
        internal static string buttonOk {
            get {
                return ResourceManager.GetString("buttonOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a show.
        /// </summary>
        internal static string buttonShow {
            get {
                return ResourceManager.GetString("buttonShow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a error connecting to {0}:{1}\n{2}.
        /// </summary>
        internal static string databaseConnectionError {
            get {
                return ResourceManager.GetString("databaseConnectionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a {0}:{1} succesfully connected.
        /// </summary>
        internal static string databaseConnectionTestResult {
            get {
                return ResourceManager.GetString("databaseConnectionTestResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a database not correctly configured.
        /// </summary>
        internal static string databaseNotConfigured {
            get {
                return ResourceManager.GetString("databaseNotConfigured", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a database.
        /// </summary>
        internal static string labelConnectionDatabase {
            get {
                return ResourceManager.GetString("labelConnectionDatabase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a host.
        /// </summary>
        internal static string labelConnectionHost {
            get {
                return ResourceManager.GetString("labelConnectionHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a password.
        /// </summary>
        internal static string labelConnectionPassword {
            get {
                return ResourceManager.GetString("labelConnectionPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a type.
        /// </summary>
        internal static string labelConnectionType {
            get {
                return ResourceManager.GetString("labelConnectionType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Cerca una stringa localizzata simile a username.
        /// </summary>
        internal static string labelConnectionUsername {
            get {
                return ResourceManager.GetString("labelConnectionUsername", resourceCulture);
            }
        }
    }
}
