// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onGetTableData(param) {
    if (param === 0) {
        $.get("https://localhost:7005/TableData/GetTableBody", function (data) {
            $("#idTableData").html(data);
        });
        return;
    }

    if (param === 1) {
        $.get("https://localhost:7005/TableData/GetTableJson", function (data) {
            const tableBody = $("#idTableData");
            tableBody.html("");
            for (let i=0; i<data.length; i++) {
                tableBody.append(`<tr><th scope="row">${data[i].id}</td><td>${data[i].title}</td><td>${data[i].status}</td><td>${data[i].datesString}</td><td>${data[i].description}</td><td></td></tr>`);
            }
        });
        return;
    }
}

function onFormClear() {
    const title = $("#title");
    const status = $("#status");
    const description = $("#description");

    title.val("");
    status.val("");
    description.val("");
}

function onFormPost() {
    const title = $("#title").val();
    const status = $("#status").val();
    const description = $("#description").val();

    const postData = { title: title, status: status, description: description };

    $.ajax({
        type: "POST",
        url: "https://localhost:7005/TableData/PostItem",
        data: postData,
        success: function (data) {
            const t = data;
        },
        dataType: "json"
    });

    //var request = { Company: sapws.dbName, UserName: username, Password: userpass };
    //console.log(request);
    //$.ajax({
    //    type: "POST",
    //    url: this.wsUrl + "/Login",
    //    contentType: "text/plain",
    //    data: JSON.stringify(request),

    //    crossDomain: true,
    //});


}