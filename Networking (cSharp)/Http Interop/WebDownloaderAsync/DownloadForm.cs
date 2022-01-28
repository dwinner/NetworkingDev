using System;
using System.Net;
using System.Windows.Forms;
using WebDownloaderAsync.Properties;

namespace WebDownloaderAsync
{
   public partial class DownloadForm : Form
   {
      private WebClient _client;
      private bool _downloading; // Для отслеживания действий кнопки

      public DownloadForm()
      {
         InitializeComponent();
      }

      private void downloadButton_Click(object sender, EventArgs e)
      {
         if (!_downloading)
         {
            _client = new WebClient();
            // Прослушивать события, чтобы быть в курсе происходящего
            _client.DownloadProgressChanged += _client_DownloadProgressChanged;
            _client.DownloadDataCompleted += _client_DownloadDataCompleted;

            try
            {
               // Запустить загрузку и тут же возвратить управление
               _client.DownloadDataAsync(new Uri(urlTextBox.Text));
               // Теперь, пока мы ждем окончания загрузки, программа может выполнять другую работу
               _downloading = true;
               downloadButton.Text = Resources.DownloadForm_downloadButton_Click_Cancel;
            }
            catch (UriFormatException ex)
            {
               MessageBox.Show(ex.Message);
               _client.Dispose();
            }
            catch (WebException ex)
            {
               MessageBox.Show(ex.Message);
               _client.Dispose();
            }
         }
         else
         {
            _client.CancelAsync();
         }
      }

      private void _client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
      {
         downloadProgressBar.Value = e.ProgressPercentage;
         statusLabel.Text = string.Format("{0:N0} / {1:N0} bytes received", e.BytesReceived, e.TotalBytesToReceive);
      }

      private void _client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
      {
         // Загрузка файла завершена
         if (e.Cancelled)
         {
            downloadProgressBar.Value = 0;
            statusLabel.Text = Resources.DownloadForm_client_DownloadDataCompleted_Cancelled;
         }
         else if (e.Error != null)
         {
            downloadProgressBar.Value = 0;
            statusLabel.Text = e.Error.Message;
         }
         else
         {
            downloadProgressBar.Value = 100;
            statusLabel.Text = Resources.DownloadForm_client_DownloadDataCompleted_Done;
         }
         // Note: Не забудьте уничтожить объект-клиент!
         _client.Dispose();
         _downloading = false;
         downloadButton.Text = Resources.DownloadForm_client_DownloadDataCompleted_Download;
         // ToDo: Прочитать данные из e.Result
      }
   }
}