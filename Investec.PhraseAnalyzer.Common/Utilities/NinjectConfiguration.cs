using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Investec.PhraseAnalyzer.Common.Utilities
{
    public class NinjectConfiguration : System.Configuration.ConfigurationSection
    {
        private const string MappingsCollectionName = "NinjectBindingMappings";

        [System.Configuration.ConfigurationProperty(MappingsCollectionName)]
        [System.Configuration.ConfigurationCollection(typeof(NinjectConfigMappingCollection), AddItemName = "add")]
        public NinjectConfigMappingCollection NinjectConfigMappings { get { return (NinjectConfigMappingCollection)base[MappingsCollectionName]; } }
    }


    public class NinjectConfigMappingCollection : System.Configuration.ConfigurationElementCollection
    {
        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new NinjectConfigMapping();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((NinjectConfigMapping)element).From;
        }
    }


    public class NinjectConfigMapping : System.Configuration.ConfigurationElement
    {
        [System.Configuration.ConfigurationProperty("from", IsRequired=true, IsKey=true)]
        public string From
        {
            get => (string)this["from"];
            set => this["from"] = value;
        }
        [System.Configuration.ConfigurationProperty("to", IsRequired=true)]
        public string To
        {
            get
            {
                return (string)this["to"];
            }
            set
            {
                this["to"] = value;
            }
        }
        [System.Configuration.ConfigurationProperty("param", IsRequired = false)]
        public string Param
        {
            get
            {
                return (string)this["param"];
            }
            set
            {
                this["param"] = value;
            }
        }
    }
}
