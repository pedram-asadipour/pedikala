var SinglePage = {};

// Load Content Modal with Ajax
SinglePage.LoadModal = function() {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function(htmlPage) {
            $("#ModalContent").html(htmlPage);

            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];

            //Validation For Display : None Item
            $.validator.setDefaults({ ignore: null });

            $.validator.unobtrusive.parse(newForm);

            showModal();

        }).fail(function() {
        ClearHash();
        swal("خطا در انجام عملیات!!!", "خطایی رخ داده , لطفا با مدیر سیستم تماس بگیرید", "error");
    });
};

//Load Operation with Ajax
SinglePage.LoadOperation = function() {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#operation")) {
        return;
    }
    url = url.split("operation=")[1];
    $.get(url,
        null,
        function(data) {

            ClearHash();
            CallBackHandler(data, "Refresh", null);

        }).fail(function() {
        swal("خطا در انجام عملیات!!!", "خطایی رخ داده , لطفا با مدیر سیستم تماس بگیرید", "error");
    });
};

//Load Content with Ajax
SinglePage.LoadContent = function() {
    var handlerPage = $("#siteContent").attr("data-handler");
    var url = GetPathName() + "?handler=" + handlerPage;

    GetContent(url, "siteContent");

    if (handlerPage == "list")
        setTimeout(function() { SetDataTable() }, 1000);

}

function GetPathName() {
    var url = window.location.pathname;
    return url;
}

function ClearHash() {
    window.location.hash = "";
}

function showModal() {
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).ready(function() {

    window.location.hash = "";
    SetDataTable();
    SetSelect2("SearchModel_CategoryId");
    SetSelect2("SearchModel_ProductId");
    SetSelect2("Command_CategoryId");
    SetSelect2("SearchModel_AccountId");
    SetTagInput();
    SetPersianDatePicker();

    //hash Change event
    window.onhashchange = function() {
        SinglePage.LoadModal();
        SinglePage.LoadOperation();
    };

    //Event Show Modal
    $("#MainModal").on("shown.bs.modal",
        function() {
            ClearHash();
            SetTagInput();
            SetSelect2("CategoryId");
            SetSelect2("ProductId");
            SetPersianDatePicker();
            MultipleSelect("Permission");
        });

    // Send Form event
    $(document).on("submit",
        'form[data-ajax="true"]',
        function(e) {
            e.preventDefault();

            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");


            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function(data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                const formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function(data) {
                        hideModal();
                        CallBackHandler(data, action, form);
                    },
                    error: function() {
                        hideModal();
                        swal("خطا در انجام عملیات!!!", "خطایی رخ داده , لطفا با مدیر سیستم تماس بگیرید", "error");
                    }
                });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
    case "Message":
        swal(data.message);
        break;
    case "RefreshPage":
        if (data.isSucceeded) {
            swal(data.message, "شما به صورت خودکار به صفحه اصلی باز گردانه می شوید", "success");
            const refreshUrl = form.attr("data-callback");
            setTimeout(function() {
                    location.assign(refreshUrl);
                },
                3000);
        } else {
            swal(data.message, "", "error");
        }
        break;
    case "Refresh":
        if (data.isSucceeded) {
            SinglePage.LoadContent();
            swal(data.message, "لیست به صورت خودکار بروز رسانی شد", "success");
        } else {
            swal(data.message, "", "error");
        }
        break;
    case "RefreshList":
        {
            hideModal();
            const refreshUrl = form.attr("data-refereshurl");
            const refreshDiv = form.attr("data-refereshdiv");
            get(refreshUrl, refreshDiv);
        }
        break;
    case "setValue":
        {
            const element = form.data("element");
            $(`#${element}`).html(data);
        }
        break;
    default:
    }
}

function GetContent(url, refreshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function(result) {
            $("#" + refreshDiv).html(result);
        });
}

function makeSlug(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(convertToSlug(value));
}

var convertToSlug = function(str) {
    var $slug = '';
    const trimmed = $.trim(str);
    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};

function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function(data) {
            if (data) {
                sendNotification('error', 'top right', "خطا", "اسلاگ نمی تواند تکراری باشد");
            }
        }
    });
}

function fillField(source, dist) {
    const value = $("#" + source).val();
    $("#" + dist).val(value);
}

$(document).on("click",
    'button[data-ajax="true"]',
    function() {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function(data) {

            }).fail(function(error) {
            alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
        });
    }
}

function SetTagInput() {
    try {
        $(".tagInput").tagsInput({ width: "auto", height: "auto" });
    } catch (e) {
    }
}

function SetSelect2(source) {
    try {
        $(`#${source}`).select2({
            width: "100%"
        });
    } catch (e) {
    }
}

function SetDataTable() {
    try {
        $("#datatable").dataTable({
            "order": [[0, "desc"]]
        });
    } catch (e) {
    }
}

function SetPersianDatePicker() {
    try {

        $(".datePickerInput").pDatepicker({
            format: "YYYY/MM/DD",
            autoClose: true,
            calendar: {
                persian: {
                    locale: "fa"
                }
            }
        });

    } catch (e) {
    }
}

function MultipleSelect(element) {

    try {

        $("#" + element).multiSelect({
            selectableOptgroup: true,
            selectableHeader:
                "<input type='text' class='form-control search-input' autocomplete='off' placeholder='جست و جو...'>",
            selectionHeader:
                "<input type='text' class='form-control search-input' autocomplete='off' placeholder='جست و جو...'>",
            afterInit: function (ms) {
                var that = this,
                    $selectableSearch = that.$selectableUl.prev(),
                    $selectionSearch = that.$selectionUl.prev(),
                    selectableSearchString =
                        '#' + that.$container.attr('id') + ' .ms-elem-selectable:not(.ms-selected)',
                    selectionSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selection.ms-selected';

                that.qs1 = $selectableSearch.quicksearch(selectableSearchString)
                    .on('keydown',
                        function (e) {
                            if (e.which === 40) {
                                that.$selectableUl.focus();
                                return false;
                            }
                        });

                that.qs2 = $selectionSearch.quicksearch(selectionSearchString)
                    .on('keydown',
                        function (e) {
                            if (e.which == 40) {
                                that.$selectionUl.focus();
                                return false;
                            }
                        });
            },
            afterSelect: function () {
                this.qs1.cache();
                this.qs2.cache();
            },
            afterDeselect: function () {
                this.qs1.cache();
                this.qs2.cache();
            }
        });


    } catch (e) {

    } 

}

//File extension Validation
jQuery.validator.addMethod("fileExtensionLimit",
    function(value, element, params) {

        if (element.files[0] == null)
            return true;

        var fileExe = element.files[0].name.split(".");
        fileExe = `.${fileExe[fileExe.length - 1]}`;

        const exe = element.attributes.getNamedItem("data-val-extensions").value.split(",");

        return exe.includes(fileExe);
    });
//File Size Validation

jQuery.validator.addMethod("maxFileSize",
    function(value, element, params) {

        if (element.files[0] == null)
            return true;

        const fileSize = element.files[0].size;
        const maxSize = element.attributes.getNamedItem("data-val-fileSize").value;

        return fileSize < maxSize;
    });

jQuery.validator.unobtrusive.adapters.addBool("fileExtensionLimit");
jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");