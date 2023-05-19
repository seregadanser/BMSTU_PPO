#define Laptop


using DB_course.Presenter;
using DB_course.View;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

using DB_course.tecknologicalUI;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


using Microsoft.EntityFrameworkCore;

namespace DB_course
{
    internal static class Program
    {

        private static TimeSpan ParseTimeZoneOffset(string offsetString)
        {
            bool isNegative = offsetString.StartsWith("-");
            string[] parts = offsetString.TrimStart('-', '+').Split(':');

            int hours = int.Parse(parts[0]);
            int minutes = parts.Length > 1 ? int.Parse(parts[1]) : 0;

            int totalMinutes = (hours * 60) + minutes;
            if(isNegative)
                totalMinutes = -totalMinutes;

            return TimeSpan.FromMinutes(totalMinutes);
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string p = "";
#if Laptop
           p ="D:\\Study\\Test\\DB_course";
#else
           p ="D:\\Labs\\DB_course";
#endif

            var configuration = new ConfigurationBuilder().SetBasePath(p).AddJsonFile("logconfig.json").Build();
            var timeZoneOffsetString = configuration["Logging:File:TimeZoneOffset"];
            var timeZoneOffset = ParseTimeZoneOffset(timeZoneOffsetString);
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>

              builder.AddFile(Path.Combine(Directory.GetCurrentDirectory(), configuration["Logging:File:FilePath"]), timeZoneOffset).
              AddConfiguration(configuration.GetSection("Logging")));
         

              var builder = new ConfigurationBuilder();
#if Laptop
            builder.SetBasePath("D:\\Study\\Test\\DB_course");
#else
            builder.SetBasePath("D:\\Labs\\DB_course");
#endif
            builder.AddJsonFile("connstring.json");
            IConfigurationRoot config = builder.Build();

            IView view = null;
            ApplicationConfiguration.Initialize();
            if (args[0] == "TUI")
                new AutoriseConsole(config, loggerFactory);

            if (args[0] == "work")
            {
                view = new UnLoginForm();
                new UnLoginPresenter(view, config, loggerFactory);
            }


            if (args[0] != "TUI")
                Application.Run((Form)view);


        }
    }
}