using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.UI.Factories
{
    public interface IFormFactory
    {
        T Create<T>() where T : Form;
        T Create<T>(params object[] parameters) where T : Form;
    }
}
