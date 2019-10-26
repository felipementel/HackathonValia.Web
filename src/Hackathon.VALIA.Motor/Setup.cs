using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.IO;

namespace POCAttribute
{
    public class Setup
    {
        public static void SetCulture()
        {
            var culture = new CultureInfo("pt-BR");
            CultureInfo.CurrentCulture = culture;
        }
    }
}
