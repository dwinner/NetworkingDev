using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Emso.WebUi.Infrastructure;
using Emso.WebUi.Models;
using Emso.WebUi.Properties;

namespace Emso.WebUi.HtmlHelpers
{
   /// <summary>
   ///    Html helpers for taming bootstrap layout
   /// </summary>
   public static class BootstrapHelpers
   {
      private const int DefaultStrLinkLen = 0x80;

      /// <summary>
      ///    Build the create link
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="url">Url</param>
      /// <param name="title">Tooltip</param>
      /// <returns>The create link</returns>
      public static MvcHtmlString BuildCreateLink(this HtmlHelper htmlHelper, string url, string title)
      {
         var aCreateTag = new TagBuilder("a");
         aCreateTag.AddCssClass("glyphicon-plus-sign");
         aCreateTag.AddCssClass("glyphicon");
         aCreateTag.AddCssClass("btn-default");
         aCreateTag.AddCssClass("btn");
         aCreateTag.MergeAttribute("href", url);
         aCreateTag.MergeAttribute("style", "font-size: 24px;");
         aCreateTag.MergeAttribute("title", title);

         return MvcHtmlString.Create(aCreateTag.ToString());
      }

      /// <summary>
      ///    Build delete button
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="additionalClasses">Additional classes</param>
      /// <returns>The delete button</returns>
      public static MvcHtmlString BuildDeleteButton(this HtmlHelper htmlHelper, params string[] additionalClasses)
      {
         var divWrapperTag = new TagBuilder("div");
         divWrapperTag.AddCssClass("text-center");
         divWrapperTag.AddCssClass("no-color");
         divWrapperTag.AddCssClass("form-actions");
         foreach (var @class in additionalClasses)
         {
            divWrapperTag.AddCssClass(@class);
         }

         divWrapperTag.InnerHtml = BuildDeleteInput();
         return MvcHtmlString.Create(divWrapperTag.ToString());
      }

      /// <summary>
      ///    Build delete input
      /// </summary>
      /// <returns>The delete input</returns>
      private static string BuildDeleteInput()
      {
         var btnTag = new TagBuilder("input");
         btnTag.AddCssClass("btn-default");
         btnTag.AddCssClass("btn");
         btnTag.MergeAttribute("type", "submit");
         btnTag.MergeAttribute("value", Resources.DeleteLinkTitle);
         var delBtn = btnTag.ToString();
         return delBtn;
      }

      /// <summary>
      ///    Build the Edit link
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="url">url</param>
      /// <param name="dialogBehavior">True if we need the dialog behavior, false - otherwise</param>
      /// <returns>The edit link</returns>
      public static MvcHtmlString BuildEditLink(this HtmlHelper htmlHelper, string url, bool dialogBehavior = false)
      {
         var aTag = new TagBuilder("a");
         aTag.AddCssClass("glyphicon-edit");
         aTag.AddCssClass("glyphicon");
         aTag.AddCssClass("btn-default");
         aTag.AddCssClass("btn");
         aTag.MergeAttribute("href", url);
         aTag.MergeAttribute("title", Resources.EditLinkTitle);
         aTag.MergeAttribute("style", "font-size: 24px;");
         if (dialogBehavior)
         {
            aTag.AddCssClass("view-dialog");
            aTag.MergeAttribute("data-dialog-title", Resources.EditLinkTitle);
         }

         return MvcHtmlString.Create(aTag.ToString());
      }

      /// <summary>
      ///    Build details link
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="url">url</param>
      /// <param name="dialogBehavior">True if we need the dialog behavior, false - otherwise</param>
      /// <returns>The details link</returns>
      public static MvcHtmlString BuildDetailsLink(this HtmlHelper htmlHelper, string url, bool dialogBehavior = false)
      {
         var aTag = new TagBuilder("a");
         aTag.AddCssClass("glyphicon-hand-right");
         aTag.AddCssClass("glyphicon");
         aTag.AddCssClass("btn-default");
         aTag.AddCssClass("btn");
         aTag.MergeAttribute("href", url);
         aTag.MergeAttribute("title", Resources.DetailsLinkTitle);
         aTag.MergeAttribute("style", "font-size: 24px;");
         if (dialogBehavior)
         {
            aTag.AddCssClass("view-dialog");
            aTag.MergeAttribute("data-dialog-title", Resources.DetailsLinkTitle);
         }

         return MvcHtmlString.Create(aTag.ToString());
      }

      /// <summary>
      ///    Build the Delete link
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="url">url</param>
      /// <param name="dialogBehavior">True if we need the dialog behavior, false - otherwise</param>
      /// <returns>The delete link</returns>
      public static MvcHtmlString BuildDeleteLink(this HtmlHelper htmlHelper, string url, bool dialogBehavior = false)
      {
         var aTag = new TagBuilder("a");
         aTag.AddCssClass("glyphicon-remove-circle");
         aTag.AddCssClass("glyphicon");
         aTag.AddCssClass("btn-default");
         aTag.AddCssClass("btn");
         aTag.MergeAttribute("href", url);
         aTag.MergeAttribute("title", Resources.DeleteLinkTitle);
         aTag.MergeAttribute("style", "font-size: 24px;");
         if (dialogBehavior)
         {
            aTag.AddCssClass("view-dialog");
            aTag.MergeAttribute("data-dialog-title", Resources.DetailsLinkTitle);
         }

         return MvcHtmlString.Create(aTag.ToString());
      }

      /// <summary>
      ///    Build the Back link
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="url">url</param>
      /// <returns>The back link</returns>
      public static MvcHtmlString BuildBackLink(this HtmlHelper htmlHelper, string url)
      {
         var aTag = new TagBuilder("a");
         aTag.AddCssClass("glyphicon-hand-left");
         aTag.AddCssClass("glyphicon");
         aTag.AddCssClass("btn-info");
         aTag.AddCssClass("btn");
         aTag.MergeAttribute("href", url);
         aTag.MergeAttribute("title", Resources.BackToList);
         aTag.MergeAttribute("style", "font-size: 24px;");

         return MvcHtmlString.Create(aTag.ToString());
      }

      /// <summary>
      ///    Build the translated employment type
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="employmentType">Employment type</param>
      /// <returns>The translated employment type</returns>
      public static MvcHtmlString BuildTranslatedEmploymentType(this HtmlHelper htmlHelper,
         EmploymentType employmentType)
      {
         string result;
         switch (employmentType)
         {
            case EmploymentType.Full:
               result = Resources.EmploymentType_Full;
               break;
            case EmploymentType.Part:
               result = Resources.EmploymentType_Part;
               break;
            case EmploymentType.Flexible:
               result = Resources.EmploymentType_Flexible;
               break;
            case EmploymentType.Remote:
               result = Resources.EmploymentType_Remote;
               break;
            default:
               throw new ArgumentOutOfRangeException("employmentType", employmentType, null);
         }

         return MvcHtmlString.Create(result);
      }

      /// <summary>
      ///    Build the translated experience
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="experience">Experience</param>
      /// <returns>The translated experience</returns>
      public static MvcHtmlString BuildTranslatedExperience(this HtmlHelper htmlHelper, Experience experience)
      {
         string result;
         switch (experience)
         {
            case Experience.LessThanOne:
               result = Resources.LessThanYear;
               break;
            case Experience.MoreThanOneLessThanThree:
               result = Resources.MoreThanOneLessThanThree;
               break;
            case Experience.MoreThanThreeLessThanSix:
               result = Resources.MoreThanThreeLessThanSix;
               break;
            case Experience.MoreThanSix:
               result = Resources.MoreThanSix;
               break;
            default:
               throw new ArgumentOutOfRangeException("experience", experience, null);
         }

         return MvcHtmlString.Create(result);
      }

      /// <summary>
      ///    Build DHTML plus text box
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="labelIndex">Label index</param>
      /// <param name="labelText">Label text</param>
      /// <param name="textBoxName">Text box name</param>
      /// <param name="item">Model item</param>
      /// <param name="idPrefix">Id prefix</param>
      /// <param name="tooltip">Tooltip</param>
      /// <returns>DHTML plus text box</returns>
      public static MvcHtmlString BuildDhtmlTextBox(this HtmlHelper htmlHelper,
         int labelIndex,
         string labelText,
         string textBoxName,
         string item,
         string idPrefix,
         string tooltip)
      {
         var divFormGroup = new TagBuilder("div");
         divFormGroup.AddCssClass("form-group");

         var label = new TagBuilder("label");
         label.AddCssClass("control-label");
         label.AddCssClass("col-md-2");
         label.SetInnerText(string.Format("{0} №{1}", labelText, labelIndex + 1));

         var divTextBox = new TagBuilder("div");
         divTextBox.AddCssClass("col-md-6");
         divTextBox.InnerHtml = htmlHelper.TextBox(textBoxName, item, new {@class = "form-control"}).ToString();

         divFormGroup.InnerHtml =
            string.Format("{0}{1}{2}", label, divTextBox,
               labelIndex > 0 ? BuildPlusLink(labelIndex, idPrefix, tooltip) : string.Empty);

         return new MvcHtmlString(divFormGroup.ToString());
      }

      private static string BuildPlusLink(int labelIndex, string idPrefix, string tooltip)
      {
         var plusDiv = new TagBuilder("div");
         plusDiv.AddCssClass("col-md-4");
         TagBuilder aPlus;
         {
            aPlus = new TagBuilder("a");
            aPlus.MergeAttribute("href", "#");
            aPlus.GenerateId(string.Format("{0}-{1}", idPrefix, labelIndex));
            aPlus.AddCssClass("col-md-4");
            aPlus.AddCssClass("control-label");
            aPlus.MergeAttribute("title", tooltip);
            aPlus.MergeAttribute("onclick", "removeJobItem (this.id); return false;");
            TagBuilder plus;
            {
               plus = new TagBuilder("div");
               plus.AddCssClass("glyphicon");
               plus.AddCssClass("glyphicon-minus");
               plus.AddCssClass("btn");
               plus.AddCssClass("btn-default");
            }
            aPlus.InnerHtml = plus.ToString();
         }

         plusDiv.InnerHtml = aPlus.ToString();
         return plusDiv.ToString();
      }

      /// <summary>
      ///    Build the login form
      /// </summary>
      /// <param name="htmlHelper">htmlHelper</param>
      /// <returns>The login form</returns>
      public static MvcHtmlString BuildLoginForm(this HtmlHelper<LoginModel> htmlHelper)
      {
         return new MvcHtmlString(string.Format("{0}{1}{2}", htmlHelper.BuildLoginName(),
            htmlHelper.BuildLoginPassword(), BuildLoginButton()));
      }

      /// <summary>
      ///    Build the upload file form
      /// </summary>
      /// <param name="htmlHelper">Html helper (as an extension context)</param>
      /// <param name="uploadText">Upload text label</param>
      /// <param name="uploadElementId">Upload element Id</param>
      /// <param name="statusElementId">Status element Id</param>
      /// <returns>The upload file form</returns>
      public static MvcHtmlString BuildUploadFileItem(this HtmlHelper htmlHelper,
         string uploadText,
         string uploadElementId,
         string statusElementId)
      {
         var formGroupDiv = new TagBuilder("div");
         formGroupDiv.AddCssClass("form-group");

         var label = new TagBuilder("label");
         label.AddCssClass("control-label");
         label.AddCssClass("col-md-2");
         label.MergeAttribute("for", uploadElementId);
         label.SetInnerText(uploadText);

         var uploadDiv = new TagBuilder("div");
         TagBuilder aTag;
         uploadDiv.AddCssClass("col-md-6");
         {
            aTag = new TagBuilder("a");
            aTag.AddCssClass("top-left");
            aTag.AddCssClass("fa");
            aTag.AddCssClass("fa-file-image-o");
            aTag.MergeAttribute("style", "font-size: 36px;");
            aTag.MergeAttribute("href", "javascript:;");

            TagBuilder inputFileTag;
            {
               inputFileTag = new TagBuilder("input");
               inputFileTag.MergeAttribute("type", "file");
               inputFileTag.MergeAttribute("id", uploadElementId);
               inputFileTag.MergeAttribute("name", uploadElementId);
            }
            aTag.InnerHtml = inputFileTag.ToString();
         }
         uploadDiv.InnerHtml = aTag.ToString();

         var statusDiv = new TagBuilder("div");
         statusDiv.AddCssClass("col-md-4");
         statusDiv.MergeAttribute("id", statusElementId);
         statusDiv.InnerHtml = "&nbsp;";

         formGroupDiv.InnerHtml = string.Format("{0}{1}{2}", label, uploadDiv, statusDiv);

         return new MvcHtmlString(formGroupDiv.ToString());
      }

      /// <summary>
      ///    Build the upload file form
      /// </summary>
      /// <param name="htmlHelper">Html helper (as an extension context)</param>
      /// <param name="uploadText">Upload text label</param>
      /// <param name="uploadElementId">Upload element Id</param>
      /// <param name="statusElementId">Status element Id</param>
      /// <param name="labelTitle">Label title</param>
      /// <param name="fileType">File type</param>
      /// <param name="tableId">Table Id</param>
      /// <returns>The upload file form</returns>
      public static MvcHtmlString BuildUploadFileItem(this HtmlHelper htmlHelper,
         string uploadText,
         string uploadElementId,
         string statusElementId,
         string labelTitle,
         string fileType,
         string tableId)
      {
         var formGroupDiv = new TagBuilder("div");
         formGroupDiv.AddCssClass("form-group");

         var labelDiv = new TagBuilder("div");
         labelDiv.AddCssClass("col-md-3");
         TagBuilder label;
         {
            label = new TagBuilder("label");
            label.AddCssClass("top-left");
            label.MergeAttribute("for", uploadElementId);
            label.MergeAttribute("title", labelTitle);
            label.SetInnerText(uploadText);
         }
         labelDiv.InnerHtml = label.ToString();

         var uploadDiv = new TagBuilder("div");
         TagBuilder aTag, tableTag;
         uploadDiv.AddCssClass("col-md-5");
         {
            aTag = new TagBuilder("a");
            aTag.AddCssClass("top-left");
            aTag.AddCssClass("fa");
            aTag.AddCssClass(fileType);
            aTag.MergeAttribute("style", "font-size: 36px;");
            aTag.MergeAttribute("href", "javascript:;");

            TagBuilder inputFileTag;
            {
               inputFileTag = new TagBuilder("input");
               inputFileTag.MergeAttribute("type", "file");
               inputFileTag.MergeAttribute("id", uploadElementId);
               inputFileTag.MergeAttribute("name", uploadElementId);
            }
            aTag.InnerHtml = inputFileTag.ToString();

            tableTag = new TagBuilder("table");
            tableTag.AddCssClass("table");
            tableTag.AddCssClass("table-hover");
            tableTag.AddCssClass("table-striped");
            tableTag.GenerateId(tableId);
         }
         uploadDiv.InnerHtml = string.Format("{0}{1}", aTag, tableTag);

         var statusDiv = new TagBuilder("div");
         statusDiv.AddCssClass("col-md-4");
         statusDiv.AddCssClass("text-danger");
         statusDiv.GenerateId(statusElementId);
         statusDiv.InnerHtml = "&nbsp;";

         formGroupDiv.InnerHtml = string.Format("{0}{1}{2}", labelDiv, uploadDiv, statusDiv);

         return new MvcHtmlString(formGroupDiv.ToString());
      }

      /// <summary>
      ///    Build submit item
      /// </summary>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="submitText">Submit text</param>
      /// <returns>Submit item</returns>
      public static MvcHtmlString BuildSubmitItem(this HtmlHelper htmlHelper, string submitText)
      {
         var formGroupDiv = new TagBuilder("div");
         formGroupDiv.AddCssClass("form-group");

         var rowDiv = new TagBuilder("div");
         rowDiv.AddCssClass("col-md-offset-2");
         rowDiv.AddCssClass("col-md-10");

         var submitTag = new TagBuilder("input");
         submitTag.AddCssClass("btn");
         submitTag.AddCssClass("btn-default");
         submitTag.MergeAttribute("type", "submit");
         submitTag.MergeAttribute("value", submitText);

         rowDiv.InnerHtml = submitTag.ToString();
         formGroupDiv.InnerHtml = rowDiv.ToString();

         return new MvcHtmlString(formGroupDiv.ToString());
      }

      /// <summary>
      ///    Build the form group item
      /// </summary>
      /// <typeparam name="TModel">Model type</typeparam>
      /// <typeparam name="TProperty">Property type</typeparam>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="expression">Model expression for output</param>
      /// <returns>The form group item</returns>
      public static MvcHtmlString BuildFormGroupItem<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
         Expression<Func<TModel, TProperty>> expression)
      {
         var formGroupDiv = new TagBuilder("div");
         formGroupDiv.AddCssClass("form-group");

         var modelLabel = htmlHelper.LabelFor(expression, new {@class = "control-label col-md-2"});

         var editorDiv = new TagBuilder("div");
         editorDiv.AddCssClass("col-md-6");
         editorDiv.InnerHtml =
            htmlHelper.EditorFor(expression, new {htmlAttributes = new {@class = "form-control"}})
               .ToString();

         var validationDiv = new TagBuilder("div");
         validationDiv.AddCssClass("col-md-4");
         validationDiv.InnerHtml =
            htmlHelper.ValidationMessageFor(expression, String.Empty, new {@class = "text-danger"})
               .ToString();

         formGroupDiv.InnerHtml = string.Format("{0}{1}{2}", modelLabel, editorDiv, validationDiv);

         return new MvcHtmlString(formGroupDiv.ToString());
      }

      /// <summary>
      ///    Build the form group item for enum dropdown list
      /// </summary>
      /// <typeparam name="TModel">Model type</typeparam>
      /// <typeparam name="TProperty">Property type</typeparam>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="expression">Model expression for output</param>
      /// <returns>The form group item</returns>
      public static MvcHtmlString BuildEnumGroupItem<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
         Expression<Func<TModel, TProperty>> expression)
      {
         var formGroupDiv = new TagBuilder("div");
         formGroupDiv.AddCssClass("form-group");

         var modelLabel = htmlHelper.LabelFor(expression, new {@class = "control-label col-md-2"});

         var editorDiv = new TagBuilder("div");
         editorDiv.AddCssClass("col-md-6");
         editorDiv.InnerHtml =
            htmlHelper.EnumDropDownListFor(expression, new {htmlAttributes = new {@class = "form-control"}})
               .ToString();

         var validationDiv = new TagBuilder("div");
         validationDiv.AddCssClass("col-md-4");
         validationDiv.InnerHtml =
            htmlHelper.ValidationMessageFor(expression, String.Empty, new {@class = "text-danger"})
               .ToString();

         formGroupDiv.InnerHtml = string.Format("{0}{1}{2}", modelLabel, editorDiv, validationDiv);

         return new MvcHtmlString(formGroupDiv.ToString());
      }

      /// <summary>
      ///    Build the form group item
      /// </summary>
      /// <typeparam name="TModel">Model type</typeparam>
      /// <typeparam name="TProperty">Property type</typeparam>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="expression">Model expression for output</param>
      /// <param name="placeHolder">Placeholder</param>
      /// <param name="editorId">Id for editor</param>
      /// <param name="tooltipMessage">Title for tooltip</param>
      /// <returns>The form group item</returns>
      public static MvcHtmlString BuildFormGroupItem<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
         Expression<Func<TModel, TProperty>> expression,
         string placeHolder,
         string editorId = "",
         string tooltipMessage = "")
      {
         var formGroupDiv = new TagBuilder("div");
         formGroupDiv.AddCssClass("form-group");

         var labelDiv = new TagBuilder("div");
         labelDiv.AddCssClass("col-md-3");
         labelDiv.InnerHtml = !String.IsNullOrWhiteSpace(tooltipMessage)
            ? htmlHelper.LabelFor(expression, new {@class = "top-left", title = tooltipMessage}).ToString()
            : htmlHelper.LabelFor(expression, new {@class = "top-left"}).ToString();

         var editorDiv = new TagBuilder("div");
         editorDiv.AddCssClass("col-md-5");

         var editor = String.IsNullOrWhiteSpace(editorId)
            ? htmlHelper.EditorFor(expression,
               new {htmlAttributes = new {placeholder = placeHolder, @class = "form-control"}})
            : htmlHelper.EditorFor(expression,
               new {htmlAttributes = new {placeholder = placeHolder, @class = "form-control", id = editorId}});
         editorDiv.InnerHtml = editor.ToString();

         var validationDiv = new TagBuilder("div");
         validationDiv.AddCssClass("col-md-4");
         validationDiv.InnerHtml =
            htmlHelper.ValidationMessageFor(expression, String.Empty, new {@class = "text-danger h4"})
               .ToString();

         formGroupDiv.InnerHtml = string.Format("{0}{1}{2}", labelDiv, editorDiv, validationDiv);

         return new MvcHtmlString(formGroupDiv.ToString());
      }

      /// <summary>
      ///    Build the form group drop down list
      /// </summary>
      /// <typeparam name="TModel">Model type</typeparam>
      /// <typeparam name="TProperty">Property type</typeparam>
      /// <param name="htmlHelper">Html helper</param>
      /// <param name="expression">Model expression for output</param>
      /// <param name="placeHolder">Placeholder</param>
      /// <param name="editorId">Id for editor</param>
      /// <param name="tooltipMessage">Title for tooltip</param>
      /// <returns>The form group item</returns>
      public static MvcHtmlString BuildEnumGroupItem<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
         Expression<Func<TModel, TProperty>> expression,
         string placeHolder,
         string editorId = "",
         string tooltipMessage = "")
      {
         var formGroupDiv = new TagBuilder("div");
         formGroupDiv.AddCssClass("form-group");

         var labelDiv = new TagBuilder("div");
         labelDiv.AddCssClass("col-md-3");
         labelDiv.InnerHtml = !String.IsNullOrWhiteSpace(tooltipMessage)
            ? htmlHelper.LabelFor(expression, new {@class = "top-left", title = tooltipMessage}).ToString()
            : htmlHelper.LabelFor(expression, new {@class = "top-left"}).ToString();

         var editorDiv = new TagBuilder("div");
         editorDiv.AddCssClass("col-md-5");

         var editor = String.IsNullOrWhiteSpace(editorId)
            ? htmlHelper.EnumDropDownListFor(expression,
               new {htmlAttributes = new {placeholder = placeHolder, @class = "form-control"}})
            : htmlHelper.EnumDropDownListFor(expression,
               new {htmlAttributes = new {placeholder = placeHolder, @class = "form-control", id = editorId}});
         editorDiv.InnerHtml = editor.ToString();

         var validationDiv = new TagBuilder("div");
         validationDiv.AddCssClass("col-md-4");
         validationDiv.InnerHtml =
            htmlHelper.ValidationMessageFor(expression, String.Empty, new {@class = "text-danger h4"})
               .ToString();

         formGroupDiv.InnerHtml = string.Format("{0}{1}{2}", labelDiv, editorDiv, validationDiv);

         return new MvcHtmlString(formGroupDiv.ToString());
      }

      private static MvcHtmlString BuildLoginName(this HtmlHelper<LoginModel> htmlHelper)
      {
         var divNameTag = new TagBuilder("div");
         divNameTag.AddCssClass("form-group");

         var labelNameTag = new TagBuilder("label");
         labelNameTag.SetInnerText(Resources.LoginForm_Name);
         var nameTextBox = htmlHelper.TextBoxFor(model => model.Name, new {@class = "form-control"});

         divNameTag.InnerHtml += labelNameTag;
         divNameTag.InnerHtml += nameTextBox;

         return new MvcHtmlString(divNameTag.ToString());
      }

      private static MvcHtmlString BuildLoginPassword(this HtmlHelper<LoginModel> htmlHelper)
      {
         var divPassTag = new TagBuilder("div");
         divPassTag.AddCssClass("form-group");

         var labelPassTag = new TagBuilder("label");
         labelPassTag.SetInnerText(Resources.LoginForm_Password);
         var passwordTextBox = htmlHelper.PasswordFor(model => model.Password, new {@class = "form-control"});

         divPassTag.InnerHtml += labelPassTag;
         divPassTag.InnerHtml += passwordTextBox;

         return new MvcHtmlString(divPassTag.ToString());
      }

      private static MvcHtmlString BuildLoginButton()
      {
         var loginButtonTag = new TagBuilder("button");
         loginButtonTag.AddCssClass("btn");
         loginButtonTag.AddCssClass("btn-primary");
         loginButtonTag.MergeAttribute("type", "submit");
         loginButtonTag.InnerHtml = Resources.LogInButtonText;

         return new MvcHtmlString(loginButtonTag.ToString());
      }

      /// <summary>
      ///    Build the bootstrap pagination
      /// </summary>
      /// <param name="html">Html helper</param>
      /// <param name="navigator">Navigator</param>
      /// <param name="pageUrlFunc">Pager function</param>
      /// <returns>The bootstrap pagination</returns>
      public static MvcHtmlString BuildBootstrapPagination(this HtmlHelper html,
         PagingNavigator navigator, Func<int, string> pageUrlFunc)
      {
         var navTag = new TagBuilder("nav");
         var ulTag = new TagBuilder("ul");
         ulTag.AddCssClass("pagination");
         ulTag.AddCssClass("pagination-lg");

         var pageItems = new StringBuilder(navigator.TotalPagesCount*DefaultStrLinkLen);
         for (var pageIndex = 1; pageIndex <= navigator.TotalPagesCount; pageIndex++)
         {
            var lIndex = pageIndex;
            pageItems.Append(BuildPaginationListItem(() => lIndex == navigator.CurrentPageNumber, pageUrlFunc, pageIndex));
         }

         ulTag.InnerHtml = pageItems.ToString();
         navTag.InnerHtml = ulTag.ToString();

         return MvcHtmlString.Create(navTag.ToString());
      }

      private static TagBuilder BuildPaginationListItem(Func<bool> isActive, Func<int, string> pageUrlFunc,
         int pageIndex)
      {
         var liTag = new TagBuilder("li");
         var paginationLink = BuildPaginationLink(pageUrlFunc, pageIndex);
         if (isActive())
         {
            liTag.AddCssClass("active");
         }

         liTag.InnerHtml = paginationLink;
         return liTag;
      }

      private static string BuildPaginationLink(Func<int, string> pageUrlFunc, int pageIndex)
      {
         var aTag = new TagBuilder("a");
         aTag.MergeAttribute("href", pageUrlFunc(pageIndex));
         aTag.InnerHtml = pageIndex.ToString();
         return aTag.ToString();
      }
   }
}