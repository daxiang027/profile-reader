using System.Configuration;

namespace xdf.document.reader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new FrmReader());
            //api/generate
            var url = ConfigurationManager.AppSettings["openAIUrl"].Trim().ToLower();
            if(!url.EndsWith("/api/generate"))
            {
                url = $"{url}/api/generate";
            }
            InternalTools.aiUrl = url ;
            var modelName = ConfigurationManager.AppSettings["modelName"];
            InternalTools.model_name = modelName;
            Application.Run(new FrmMutiPageReader());
        }
    }
}