using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using BachorzLibrary.Common.Extensions;

namespace BachorzLibrary.Desktop.Utils
{
    public static class FormUtils
    {
        public static void MessageBoxOperation(Action<StringBuilder> action, bool isLongOperation, bool exceptionWithStackTrace = false)
        {
            var message = string.Empty;
            try
            {
                Action innerAction = () =>
                {
                    var sb = new StringBuilder();
                    action(sb);
                    message = sb.ToString();
                };

                if (isLongOperation)
                {
                    LongOperation(innerAction);
                }
                else
                {
                    innerAction();
                }
            }
            catch (Exception ex)
            {
                string fullMessage = ex.Message;
                if (ex.InnerException != null)
                    fullMessage += " " + ex.InnerException.Message;

                if (exceptionWithStackTrace)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(fullMessage);
                    for (int i = 0; i < 2; i++)
                    {
                        sb.AppendLine();
                    }
                    sb.AppendLine(ex.StackTrace);

                    message = sb.ToString();
                }
                else
                {
                    message = fullMessage;
                }
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show(message);
                }
            }
        }

        public static void LongOperation(Action action)
        {
            Cursor.Current = Cursors.WaitCursor;
            action();
            Cursor.Current = Cursors.Arrow;
        }

        public static void AdminZone(Action action, Func<bool> userIsAdmin)
        {
            if (userIsAdmin())
            {
                action();
            }
            else
            {
                MessageBox.Show("Nie masz uprawnień administratora", "Odmowa dostępu");
            }
        }

    }
}
