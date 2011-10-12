using System.Windows.Forms;
using Alfa.Core.Exception;

namespace Alfa.Core.Windows
{
    public class HandlerMessage : IHandlerMessage
    {
        public void Show(string message)
        {
            MessageBox.Show(message, "Mensagem de Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
