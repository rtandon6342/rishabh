using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.MAUI.Data;
using System.Net.Http;
using System.Net;
using System.Net.WebSockets;

namespace Webapp.WebApp.Data
{
    public class FileService
    {
        // private readonly VerityOperatingSystem _VerityOperatingSystem;


        // public FileService()
        // {
        //     _VerityOperatingSystem = new VerityOperatingSystem();
        // }

        public async Task<byte[]> DownloadFileToBytes()
        {
            var fileURL = "http://localhost:5029/api/WeatherForecast/Download";
            var httpClient = new HttpClient();
            // var fileName = "test.cvs";
            Console.WriteLine("start download file");
            // var fileURL = "http://localhost:5095/api/WeatherForecast/Download";
            var response = await httpClient.GetAsync(fileURL);
            var content = await response.Content.ReadAsByteArrayAsync();
            return content;
        }

        public async Task FileDownloadToPhone()
        {
            var MauiFileService = new MAUIFileService();
            var bytes = await DownloadFileToBytes();
            await MauiFileService.DownloadFile(bytes);
        }
    }
}