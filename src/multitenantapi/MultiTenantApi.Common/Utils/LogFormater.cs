using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MultiTenantApi.Common.Utils
{
    public static class LogFormater
    {
        public static string Format(string message, params object[] objects)
        {
            var sb = new StringBuilder();
            sb.Append($"{message}: ");
            sb.AppendJoin(",", 
                (objects ?? Array.Empty<string>())
                    .Select(o => JsonSerializer.Serialize(o))
            );

            return sb.ToString();
        }
    }
}
