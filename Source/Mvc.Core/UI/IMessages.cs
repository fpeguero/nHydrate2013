using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Core.UI
{
    public interface IMessages
    {
        string Code { get; set; }

        string Description { get; set; }

        IMessages GetMessages(string code);

        string Mensaje(string code);
        string GetOrSetMensaje(string code);
    }
}
