function ShowImagePerview(ImageUploader, PerviewImage) {
    if (ImageUploader.files && ImageUploader.files[0]) {
        var reader = new FileReader();

    reader.onload = function (e) {
        $(PerviewImage).attr('src', e.target.result);
    }

    reader.readAsDataURL(ImageUploader.files[0]);

        }

}
function JquaryAjaxPost(form) {
    $.validator.unobtrusive.parse($(form));
    if ($(form).valid()) {
        var ajaxconfig = {
            type: "POST",
            url: from.action,
            data: new FromData(from),
            success: function (respone) {
                $("#firsttab").html(respone);
                refreshaddnewtab($(form).attr("data_restUrl"), true);
            },
            dataType: dataType
        }
        if ($(form).attr("enctype") == multipart / form - data) {
            ajaxconfig["contentType"] = false;
            ajaxconfig["processData"] = false;
        }
        $.ajax(ajaxconfig);

    }
    return false;

}
function refreshaddnewtab(restUrl, showViewTab) {
    $.ajax({
        type:"GET",
        url: restUrl, sucess: function (response) {
            $("#secondtab").html(respone);
            $("ul.nav.nav-tabs a:eq(1)").html("Add New");
            if (showViewTab) {
                $("ul.nav.nav-tabs a:eq(0)").tab("show");
            }
        }
    });
   
}
function Edit(Url) {
    debugger;
    $.ajax({
        type:"GET",
        url: Url,
        success: function (respone) {
            alert('Success');
            $("#secondtab").html(respone);
            $("ul.nav.nav-tabs a:eq(1)").html("Edit");

            $("ul.nav.nav-tabs a:eq(1)").tab("show");
        },
        error: function () {
            alert('A error');

        }
    })
        ;
}
