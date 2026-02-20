using NewProject.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infrastructure.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _logPath;

        public FileLogger(string basePath)
        {
            _logPath = Path.Combine(basePath, "logs", "app.log");
        }

        public void Log(Exception ex)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_logPath)!);

            File.AppendAllText(_logPath,
                $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}]\n{ex}\n\n");
        }
    }
}
