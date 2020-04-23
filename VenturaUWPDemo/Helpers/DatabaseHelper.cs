using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Demo.Helpers
{
    public static class DatabaseHelper
    {

        public static async Task RestoreDatabaseFile(bool force_restore = false)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var databaseFolder = await localFolder.CreateFolderAsync("Database", CreationCollisionOption.OpenIfExists);

            var storage_item = await databaseFolder.TryGetItemAsync("VanArsdel.db");

            if (storage_item == null || force_restore == true)
            {
                var sourceLogFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///VanArsdel.db"));
                var targetLogFile = await databaseFolder.CreateFileAsync("VanArsdel.db", CreationCollisionOption.ReplaceExisting);
                await sourceLogFile.CopyAndReplaceAsync(targetLogFile);
            }
        }


    }
}
