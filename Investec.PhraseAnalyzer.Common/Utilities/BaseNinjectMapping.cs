using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Investec.PhraseAnalyzer.Common.Utilities
{
    public abstract class BaseNinjectMapping : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            var config = (NinjectConfiguration)System.Configuration.ConfigurationManager.GetSection("NinjectConfiguration");
            if (config != null && config.NinjectConfigMappings.Count > 0)
            {
                foreach (NinjectConfigMapping mapping in config.NinjectConfigMappings)
                {
                    // check if we added a parameter in the config. the basic assumption here is that the parameter will be of type string
                    var param = mapping.Param.Split(','); 
                    if (string.IsNullOrWhiteSpace(mapping.Param) || param.Length != 2)
                    {
                        Bind(Type.GetType(mapping.From, true)).To(Type.GetType(mapping.To, true));
                    }
                    else
                    {
                        Bind(Type.GetType(mapping.From, true)).To(Type.GetType(mapping.To, true)).WithConstructorArgument(param[0], param[1]);
                    }
                }
            }
        }
    }
}
