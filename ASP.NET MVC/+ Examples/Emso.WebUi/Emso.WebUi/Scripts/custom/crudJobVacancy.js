function addTextInputTmpl (triggerElement, sameNameElement, labelText, jobKind) {
    $ ("#" + triggerElement).click (function (e) {
        e.preventDefault();
        var elements = $ ("input[name=" + sameNameElement + "]");
        var elementsCount = elements.length + 1;
        var elementsData = {
            labelText: labelText,
            elementsCount: elementsCount,
            sameNameElement: sameNameElement,
            jobKind: jobKind,
            jobItemIndex: elementsCount
        };
        var newRespTmpl = $ ("#addJobItemTmpl").template (elementsData);
        if (elementsCount > 1) {
            newRespTmpl.insertAfter (elements.last().closest ("div.form-group"));
        } else {
            newRespTmpl.insertBefore ($ (this).closest ("div.form-group"));
        }
    });
}

function removeJobItem (elementId) {
    var closestFormGroup = $ ("#" + elementId).closest ("div.form-group");
    closestFormGroup.remove();
}