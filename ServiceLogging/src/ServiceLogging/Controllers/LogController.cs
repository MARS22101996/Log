using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLogging.Models;

namespace ServiceLogging.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        [HttpPost]
        [Route("new")]
        public async Task Log([FromBody] LogModel model)
        {
            if (model != null)
            {
                //UnicodeEncoding ue = new UnicodeEncoding();

                var informationLog = DateTime.UtcNow + " CorrelationId = " + model.CorrelationId + " | " +
                                     model.ServiceName +
                                     "|" + model.Level + " | " + model.Logger + " | " + model.Message + "\n";

                System.IO.File.AppendAllText(@"AllServiceLog.txt", informationLog);
                //var buffer = ue.GetBytes(informationLog);

                //using (FileStream sourceStream = System.IO.File.Open("AllServiceLog.txt", FileMode.OpenOrCreate))
                //{
                //    sourceStream.Seek(0, SeekOrigin.End);

                //    await sourceStream.WriteAsync(buffer, 0, buffer.Length);
                //}
            }
        }
    }
}