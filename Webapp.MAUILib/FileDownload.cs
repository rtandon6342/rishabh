using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;

namespace Webapp.MAUI.Data;

public class MAUIFileService
{
    public async Task DownloadFile(byte[] bytes)
    {
        await SaveFile(new CancellationToken(),bytes);        
    }

    private async Task SaveFile(CancellationToken cancellationToken,byte[] bytes)
    {
        using var stream = new MemoryStream(bytes);
        var fileSaverResult = await FileSaver.Default.SaveAsync("test.txt", stream, cancellationToken);
        if (fileSaverResult.IsSuccessful)
        {
            await Toast.Make($"The file was saved successfully to location: {fileSaverResult.FilePath}").Show(cancellationToken);
        }
        else
        {
            await Toast.Make($"The file was not saved successfully with error: {fileSaverResult.Exception.Message}").Show(cancellationToken);
        }
    }
}