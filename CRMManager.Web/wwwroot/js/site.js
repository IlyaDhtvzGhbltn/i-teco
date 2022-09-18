function sendRequest(url, method, body, callbackOk, callbackFail) {
    $.ajax({
        url: url,
        data: JSON.stringify(body),
        method: method,
        contentType: 'application/json; charset=utf-8',
        success: callbackOk,
        error: callbackFail
    })
}

function setAttributeToSingle(selector, attribute, value) {
    $(selector)[0].setAttribute(attribute, value);
}

function executeRequest(progressElement, elementsToBeDisabled, request) {
    setAttributeToSingle(progressElement.selector, progressElement.attribute, progressElement.value);

    changeDisableOptAll(elementsToBeDisabled, true);

    sendRequest(request.url, request.method, request.body, request.callbackOk, request.callbackFail);

    changeDisableOptAll(elementsToBeDisabled, false);
    setAttributeToSingle(progressElement.selector, progressElement.attribute, progressElement.after);
}

function showAlert(type, message, elementSelector) {
    let alert = `<div class="alert ${type} alert-dismissible fade show" role="alert">` +
                    message
                    '<button type = "button" class="close" data-dismiss="alert" aria-label="Close">' +
                        '<span aria-hidden="true">&times;</span>'
                    '</button>'
                '</div>';
    let container = $(elementSelector);
    container.html(alert);

    const alertTimeout = setTimeout(function ()
    {
        $(".alert").alert('close');
    }, 5000);
}

function changeDisableOptAll(elements, value) {
    [].forEach.call(elements, function (e) {
        e.disabled = value;
    });
}


function deleteElementById(id) {
    $(`#${id}`).remove();
}
