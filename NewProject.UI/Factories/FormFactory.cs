using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.UI.Factories
{
    public class FormFactory : IFormFactory
    {
        private readonly IServiceProvider _provider;

        public FormFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Create<T>() where T : Form
        {
            return _provider.GetRequiredService<T>();
        }

        public T Create<T>(params object[] parameters) where T : Form
        {
            return ActivatorUtilities.CreateInstance<T>(_provider, parameters);
        }
    }
}
