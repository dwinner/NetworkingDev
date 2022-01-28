var pdfMimeTypeId = 1;
var zipMimeTypeId = 2;
var progressClass = "fa fa-spinner fa-spin";
var getAllEndpointRoute = "/upload/getAll/";
var delFileEndpointRoute = "/upload/del";
var uploadFileEndpointRoute = "/upload/execute/";
var pdfUplaodStatEl = "pdfUploadStatus";
var zipUplaodStatEl = "zipUploadStatus";
var pdfUploadedTable = "pdfUploadedFiles";
var zipUploadedTable = "zipUploadedFiles";
var ajaxTimeout = 15000;
var pdfInputFileId = "resumeFile";
var zipInputFileId = "codeExampleFile";
var pdfFileLimit = 5;
var zipFileLimit = 1;

function deleteFile (fileName, mimeTypeId) {
    var formData = { fileNameToDelete: fileName };
    var successCallback = getSuccessUploadCallback (mimeTypeId);
    var uploadStatusEl = getSuccessStatusEl (mimeTypeId);

    $.ajax ({
        url: delFileEndpointRoute,
        type: "DELETE",
        data: formData,
        success: successCallback,
        error: function (jqXhr) {
            $ (uploadStatusEl).removeClass (progressClass);
            if (jqXhr.responseJSON) {
                $ (uploadStatusEl).html (jqXhr.responseJSON["Message"]);
            }
        }
    });
}

function getSuccessUploadCallback (mimeTypeId) {
    var successCallback;

    switch (mimeTypeId) {
    case pdfMimeTypeId:
        successCallback = getPdfUploadedFiles;
        break;
    case zipMimeTypeId:
        successCallback = getZipUploadedFiles;
        break;
    default:
        throw Error ("Unknown mime type: " + mimeTypeId);
    }

    return successCallback;
}

function getUploadLimit (mimeTypeId) {
    var uploadLimit;

    switch (mimeTypeId) {
    case 1:
        uploadLimit = pdfFileLimit;
        break;
    case 2:
        uploadLimit = zipFileLimit;
        break;
    default:
        throw Error ("Unknown mime type: " + mimeTypeId);
    }

    return uploadLimit;
}

function getInputFileTarget (mimeTypeId) {
    var inputFileTarget;

    switch (mimeTypeId) {
    case 1:
        inputFileTarget = pdfInputFileId;
        break;
    case 2:
        inputFileTarget = zipInputFileId;
        break;
    default:
        throw Error ("Unknown mime type: " + mimeTypeId);
    }

    return inputFileTarget;
}

function getSuccessStatusEl (mimeTypeId) {
    var uploadStatusEl;

    switch (mimeTypeId) {
    case pdfMimeTypeId:
        uploadStatusEl = "#" + pdfUplaodStatEl;
        break;
    case zipMimeTypeId:
        uploadStatusEl = "#" + zipUplaodStatEl;
        break;
    default:
        throw Error ("Unknown mime type: " + mimeTypeId);
    }

    return uploadStatusEl;
}

function getPdfUploadedFiles () {
    $.getJSON (getAllEndpointRoute + pdfMimeTypeId, null, function (uploadedData) {
        $ ("#" + pdfUplaodStatEl).empty();
        var target = $ ("#" + pdfUploadedTable);
        applyTemplate (target, uploadedData, "#pdfUploadedTmpl", pdfMimeTypeId);
    });
}

function getZipUploadedFiles () {
    $.getJSON (getAllEndpointRoute + zipMimeTypeId, null, function (uploadedData) {
        $ ("#" + zipUplaodStatEl).empty();
        var target = $ ("#" + zipUploadedTable);
        applyTemplate (target, uploadedData, "#zipUploadedTmpl", zipMimeTypeId);
    });
}

function applyTemplate (targetElement, uploadedData, sourceTemplate, mimeTypeId) {
    targetElement.empty();
    var uploadedViewModel = { uploadedFiles: [] };
    uploadedData.forEach (function (uploadedItem) {
        uploadedViewModel.uploadedFiles.push (uploadedItem);
    });

    var uploadLimit = getUploadLimit (mimeTypeId);
    var inputFileTarget = getInputFileTarget (mimeTypeId);
    $ ("#" + inputFileTarget).attr ("disabled", uploadedData.length >= uploadLimit);
    $ (sourceTemplate).template (uploadedViewModel).appendTo (targetElement);
    $ ("[title]").tooltip();
}

function ajaxFileUpload (inputFileId, uploadStatusId, mimeTypeId) {
    $ ("#" + inputFileId).change (function (e) {
        e.preventDefault();
        var postedFiles = document.getElementById (inputFileId).files;
        if (postedFiles.length <= 0) {
            console.log ("Ajax uploading is not enabled");
        } else {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < postedFiles.length; x++) {
                    data.append ("File " + x, postedFiles[x]);
                }

                $ (uploadStatusId).addClass (progressClass);
                $ (uploadStatusId).empty();

                $.ajax ({
                    timeout: ajaxTimeout,
                    type: "POST",
                    url: uploadFileEndpointRoute + mimeTypeId,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function () {
                        $ (uploadStatusId).removeClass (progressClass);
                        getSuccessUploadCallback (mimeTypeId)();
                    },
                    error: function (jqXhr) {
                        $ (uploadStatusId).removeClass (progressClass);
                        $ (uploadStatusId).html (jqXhr.status === 404
                            ? "Exceeded the maximum upload size"
                            : jqXhr.responseJSON["Message"]);
                    }
                });
            }
        }
    });
}

function setupAjaxUpload () {
    ajaxFileUpload (pdfInputFileId, "#" + pdfUplaodStatEl, pdfMimeTypeId);
    ajaxFileUpload (zipInputFileId, "#" + zipUplaodStatEl, zipMimeTypeId);
}

$ (function () {
    var defaultRatingBarTheme = "fontawesome-stars";
    setupAjaxUpload();
    getPdfUploadedFiles();
    getZipUploadedFiles();

    if (!Modernizr.inputtypes.date) {
        var birthdateEl = "#birthDate";
        $ (birthdateEl).datepicker ({
            defaultDate: "-30y",
            showOtherMonths: true,
            selectOtherMonths: true,
            changeMonth: true,
            changeYear: true
        });
        $ (birthdateEl).datepicker ("option", "showAnim", "clip");
        $ (birthdateEl).datepicker ("option", "dateFormat", "dd/mm/yy");
    }

    $ ("#CAndCppKnowledge").barrating ({
        theme: defaultRatingBarTheme,
        showSelectedRating: true,
        hoverState: true
    });

    $ ("#CSharpKnowledge").barrating ({
        theme: defaultRatingBarTheme,
        showSelectedRating: true,
        hoverState: true
    });

    $ ("#OodKnowledge").barrating ({
        theme: defaultRatingBarTheme,
        showSelectedRating: true,
        hoverState: true
    });

    $ ("#OopKnowledge").barrating ({
        theme: defaultRatingBarTheme,
        showSelectedRating: true,
        hoverState: true
    });

    $ ("#RefactoringKnowledge").barrating ({
        theme: defaultRatingBarTheme,
        showSelectedRating: true,
        hoverState: true
    });

    $ ("#Language").barrating ({
        theme: "bars-reversed",
        initialRating: 2,
        showValues: false,
        showSelectedRating: true,
        hoverState: true
    });

    $ ("#TelephoneNumber").mask ("(9) 999-999-9999");    
});