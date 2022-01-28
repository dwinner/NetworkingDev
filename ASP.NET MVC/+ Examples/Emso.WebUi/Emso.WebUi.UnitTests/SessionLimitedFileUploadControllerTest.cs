using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Emso.WebUi.Infrastructure.Ifaces;
using Emso.WebUi.Models;
using Emso.WebUi.Services.UnitTests.Utilities;
using Emso.WebUi.Utils;
using Moq;
using NUnit.Framework;

namespace Emso.WebUi.Services.UnitTests
{
   /// <summary>
   ///    Testing Session based file uploading
   /// </summary>
   [TestFixture]
   public class SessionLimitedFileUploadControllerTest : IisTesterBase
   {
      [SetUp]
      protected void PerTestSettingUp()
      {
         UploadFileInfoFactory.Reinit();
      }

      private const string BaseRoute = "/upload";

      [OneTimeSetUp]
      protected void SetUpOnce()
      {
         Init();
      }

      [OneTimeTearDown]
      protected void TearDownOnce()
      {
         Destroy();
      }

      private static async Task<bool> DeleteZipAsync(string fileName)
      {
         var foundFile = UploadFileInfoFactory.ZipFiles.FirstOrDefault(zipFile => zipFile.Name == fileName);
         Assert.NotNull(foundFile);
         var successRemove = UploadFileInfoFactory.ZipFiles.Remove(foundFile);
         Assert.IsTrue(successRemove);
         return await Task.FromResult(true).ConfigureAwait(false);
      }

      private static async Task<bool> DeletePdfAsync(string fileName)
      {
         var foundFile = UploadFileInfoFactory.PdfFiles.FirstOrDefault(pdfFile => pdfFile.Name == fileName);
         Assert.NotNull(foundFile);
         var successRemove = UploadFileInfoFactory.PdfFiles.Remove(foundFile);
         Assert.IsTrue(successRemove);
         return await Task.FromResult(true).ConfigureAwait(false);
      }

      [Test]
      [TestCase("ZipFile0", MimeTypeId.Zip)]
      [TestCase("PdfFile0", MimeTypeId.Pdf)]
      [TestCase("NotExists", MimeTypeId.None)]
      public async Task DeleteAsyncTestAsync(string fileToDelete, MimeTypeId mimeTypeId)
      {
         string route = string.Format("{0}/del/", BaseRoute);

         switch (mimeTypeId)
         {
            case MimeTypeId.None:
               var resumeRepo = new Mock<IResumeManagerRepository>();
               resumeRepo
                  .Setup(repository => repository.DeleteAsync(HttpContextExtensions.DummySessionId, fileToDelete))
                  .Returns(Task.FromResult(false));
               var formData = new FormDataCollection(new List<KeyValuePair<string, string>>
               {
                  new KeyValuePair<string, string>(SessionLimitedFileUploadController.FileFormDataKey, fileToDelete)
               });
               var controller = new SessionLimitedFileUploadController(resumeRepo.Object)
               {
                  Configuration = new HttpConfiguration(),
                  Request = new HttpRequestMessage
                  {
                     Method = HttpMethod.Delete,
                     RequestUri = new Uri(string.Format("{0}:{1}{2}", CommonEnvFactory.TestHostAddress,
                        CommonEnvFactory.TestPort, route))
                  }
               };

               Assert.IsFalse(UploadFileInfoFactory.PdfFiles.Union(UploadFileInfoFactory.ZipFiles).Any(fileInfo => fileInfo.Name == fileToDelete));
               var beforePdfCount1 = UploadFileInfoFactory.PdfFiles.Count;
               var beforeZipCount1 = UploadFileInfoFactory.ZipFiles.Count;
               var responseMessage = await controller.DeleteAsync(formData).ConfigureAwait(false);
               var afterPdfCount1 = UploadFileInfoFactory.PdfFiles.Count;
               var afterZipCount1 = UploadFileInfoFactory.ZipFiles.Count;

               Assert.IsTrue(responseMessage.StatusCode == HttpStatusCode.BadRequest);
               Assert.IsTrue(beforePdfCount1 == afterPdfCount1);
               Assert.IsTrue(beforeZipCount1 == afterZipCount1);
               break;

            case MimeTypeId.Pdf:
               var pdfResumeRepo = new Mock<IResumeManagerRepository>();
               pdfResumeRepo
                  .Setup(repository => repository.DeleteAsync(HttpContextExtensions.DummySessionId, fileToDelete))
                  .Returns(() => DeletePdfAsync(fileToDelete));
               var pdfFormData = new FormDataCollection(new List<KeyValuePair<string, string>>
               {
                  new KeyValuePair<string, string>(SessionLimitedFileUploadController.FileFormDataKey, fileToDelete)
               });
               var pdfController = new SessionLimitedFileUploadController(pdfResumeRepo.Object)
               {
                  Configuration = new HttpConfiguration(),
                  Request = new HttpRequestMessage
                  {
                     Method = HttpMethod.Delete,
                     RequestUri = new Uri(string.Format("{0}:{1}{2}", CommonEnvFactory.TestHostAddress,
                        CommonEnvFactory.TestPort, route))
                  }
               };

               var beforePdfCount2 = UploadFileInfoFactory.PdfFiles.Count;
               var pdfFound = UploadFileInfoFactory.PdfFiles.Any(file => fileToDelete == file.Name);
               Assert.IsTrue(pdfFound);

               var message = await pdfController.DeleteAsync(pdfFormData).ConfigureAwait(false);

               var afterPdfCount2 = UploadFileInfoFactory.PdfFiles.Count;
               pdfFound = UploadFileInfoFactory.PdfFiles.Any(file => fileToDelete == file.Name);
               Assert.IsFalse(pdfFound);

               Assert.IsTrue(message.StatusCode == HttpStatusCode.OK);
               Assert.IsTrue(beforePdfCount2 == afterPdfCount2 + 1);
               break;

            case MimeTypeId.Zip:
               var zipResumeRepo = new Mock<IResumeManagerRepository>();
               zipResumeRepo
                  .Setup(repository => repository.DeleteAsync(HttpContextExtensions.DummySessionId, fileToDelete))
                  .Returns(() => DeleteZipAsync(fileToDelete));
               var zipFormData = new FormDataCollection(new List<KeyValuePair<string, string>>
               {
                  new KeyValuePair<string, string>(SessionLimitedFileUploadController.FileFormDataKey, fileToDelete)
               });
               var zipController = new SessionLimitedFileUploadController(zipResumeRepo.Object)
               {
                  Configuration = new HttpConfiguration(),
                  Request = new HttpRequestMessage
                  {
                     Method = HttpMethod.Delete,
                     RequestUri = new Uri(string.Format("{0}:{1}{2}", CommonEnvFactory.TestHostAddress,
                        CommonEnvFactory.TestPort, route))
                  }
               };

               var beforeZipCount3 = UploadFileInfoFactory.ZipFiles.Count;
               var zipFound = UploadFileInfoFactory.ZipFiles.Any(file => fileToDelete == file.Name);
               Assert.IsTrue(zipFound);

               var httpResponseMessage = await zipController.DeleteAsync(zipFormData).ConfigureAwait(false);

               var afterZipCount3 = UploadFileInfoFactory.ZipFiles.Count;
               zipFound = UploadFileInfoFactory.ZipFiles.Any(file => fileToDelete == file.Name);
               Assert.IsFalse(zipFound);

               Assert.IsTrue(httpResponseMessage.StatusCode == HttpStatusCode.OK);
               Assert.IsTrue(beforeZipCount3 == afterZipCount3 + 1);
               break;

            default:
               throw new ArgumentOutOfRangeException("mimeTypeId", mimeTypeId, null);
         }
      }

      [Test]
      [TestCase(1)]
      [TestCase(2)]
      public async Task GetAsyncTestAsync(int mimeId)
      {
         string route = string.Format("{0}/getAll/{1}", BaseRoute, mimeId);
         var resumeRepo = new Mock<IResumeManagerRepository>();
         resumeRepo.Setup(repository => repository.GetFilesAsync(HttpContextExtensions.DummySessionId, MimeTypeId.Pdf))
            .Returns(Task.FromResult<IEnumerable<UploadedFileInfo>>(UploadFileInfoFactory.PdfFiles));
         resumeRepo.Setup(repository => repository.GetFilesAsync(HttpContextExtensions.DummySessionId, MimeTypeId.Zip))
            .Returns(Task.FromResult<IEnumerable<UploadedFileInfo>>(UploadFileInfoFactory.ZipFiles));
         var resumeManagerRepository = resumeRepo.Object;

         var controller = new SessionLimitedFileUploadController(resumeManagerRepository)
         {
            Configuration = new HttpConfiguration(),
            Request = new HttpRequestMessage
            {
               Method = HttpMethod.Get,
               RequestUri = new Uri(string.Format("{0}:{1}{2}", CommonEnvFactory.TestHostAddress,
                  CommonEnvFactory.TestPort, route))
            }
         };

         var mimeTypeId = (MimeTypeId) mimeId;
         var actual = (await controller.GetAsync(mimeTypeId).ConfigureAwait(false)).ToArray();
         var expected = (mimeTypeId == MimeTypeId.Pdf ? UploadFileInfoFactory.PdfFiles : UploadFileInfoFactory.ZipFiles).ToArray();
         Assert.IsTrue(actual.Length == expected.Length);
         for (var i = 0; i < actual.Length; i++)
         {
            Assert.IsTrue(actual[i].Equals(expected[i]));
         }
      }

      [Test]
      [TestCase(1)]
      [TestCase(2)]
      public void PostAsyncTest(int mimeId)
      {
         string route = string.Format("{0}/execute/{1}", BaseRoute, mimeId);
         // TODO: STOPPED HERE!
      }
   }
}