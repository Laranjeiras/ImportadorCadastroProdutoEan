using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ImportadorCadastroEan.Data
{
    internal class EFHintCommandInterceptor : DbCommandInterceptor
    {

        public override InterceptionResult<DbDataReader> ReaderExecuting(
          DbCommand command,
          CommandEventData eventData,
          InterceptionResult<DbDataReader> result)
        {
            Console.WriteLine($"===> {DateTime.UtcNow} START COMMAND");
            Console.WriteLine(command.CommandText);
            var pm = command.Parameters;
            foreach (var item in pm)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"===> {DateTime.UtcNow} FINISH COMMAND");
            return result;
        }
    }
}
