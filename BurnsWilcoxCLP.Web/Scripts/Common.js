//kendo.cultures.current.calendar.patterns.d = "dd/MM/yyyy";

var datatypeEnum, typeEnum;

$(document).ready(
    function () {
        setMenu();
        setInputMaxLength();      

        if (typeof datatypeEnum == "undefined") {
            datatypeEnum = {
                "json": "json",
                "text": "text"
            };
        }

        if (typeof typeEnum == "undefined") {
            typeEnum = {
                "get": "get",
                "post": "post"
            };
        }
    }
);

function setMenu() {
    var url = window.location.toString();
    url = url.split("?")[0];
    var temp = url.split("/");

    var keyWord = '';
    for (i = 3; i < temp.length; i++) {
        keyWord += '/' + temp[i];
    }
    $('a[href~="' + keyWord + '"]').parent().addClass("active");
    //if (!$('body').hasClass("sidebar-xs")) {
    //    $('a[href~="' + keyWord + '"]').parent().parent().show();
    //}
    $('a[href*="/Dashboard/Home"]').find('span').css("cursor", "pointer")
    $('a[href="/"]').find('span').css("cursor", "pointer")
    $('a[href="/crm/"]').find('span').css("cursor", "pointer")

}

function setInputMaxLength() {
    $("input[data-val-maxlength-max]").each(function (index, element) {
        var length = parseInt($(this).attr("data-val-maxlength-max"));
        $(this).prop("maxlength", length);
    });
}

function closeKendoWindow(id) {
    var dialog = $('#' + id);
    dialog.data("kendoWindow").close();
}

function showMessageOnly(message, alertClass) {
    bootbox.alert(message, '', alertClass);
}

function callwebservice(ajaxurl, parameter, callbackFunction, isErrorHandle, dataType) {

    if (typeof (parameter) === 'undefined') {
        parameter = '';
    }

    try {
        $.support.cors = true;
        $.ajax({
            url: ajaxurl,
            cache: false,
            dataType: dataType,
            data: parameter,
            timeout: 40000,
            success: function (data) {
                callbackFunction(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (isErrorHandle === true) {
                    callbackFunction("error");
                }
                else {
                    if (errorThrown !== "") {
                        showMessageOnly("The following error occured: " + errorThrown, 'popup-error');
                    }
                    else {
                        showMessageOnly("There is an error while connecting to server. Please try again!", 'popup-error');
                    }
                }
            },
            always: function () {
            }
        });
    }
    catch (e) {
        showMessageOnly("Errour occurred " + e, 'popup-error');
    }
}

function AjaxCall(url, parameter, callbackFunction, isErrorHandle, dataType) {
    if (typeof (parameter) === 'undefined') {
        parameter = '';
    }
    try {
        $.support.cors = true;
        $.ajax({
            url: url,
            cache: false,
            type: dataType,
            data: parameter,
            timeout: 40000,
            async: false,
            success: function (data) {
                callbackFunction(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                if (isErrorHandle === true) {
                    callbackFunction("error");
                }
                else {
                    if (errorThrown !== "") {
                        //showMessageOnly("The following error occured: " + errorThrown, 'popup-error');
                    }
                    else {
                        //showMessageOnly("There is an error while connecting to server. Please try again!", 'popup-error');
                    }
                }
            },
            always: function () {
            }
        });
    }
    catch (e) {
        //showMessageOnly("Errour occurred " + e, 'popup-error');
    }
}

function getLocalValue(key) {
    return localStorage.getItem(key);
}

function setLocalValue(key, value) {
    localStorage.setItem(key, value);
}

function readKendoGrid(id) {
    var grid = $("#" + id).data("kendoGrid");
    grid.dataSource.read();
}

function GetDateDiff(dt1, dt2) {

    /*
     * setup 'empty' return object
     */
    var ret = { days: 0, months: 0, years: 0 };

    /*
     * If the dates are equal, return the 'empty' object
     */
    if (dt1 == dt2 || dt2 > dt1) return GetDateDiff(dt2,dt1);

    /*
     * ensure dt2 > dt1
     */
    if (dt1 > dt2) {
        var dtmp = dt2;
        dt2 = dt1;
        dt1 = dtmp;
    }


    /*
     * First get the number of full years
     */

    var year1 = dt1.getFullYear();
    var year2 = dt2.getFullYear();

    var month1 = dt1.getMonth();
    var month2 = dt2.getMonth();

    var day1 = dt1.getDate();
    var day2 = dt2.getDate();

    /*
     * Set initial values bearing in mind the months or days may be negative
     */

    ret['years'] = year2 - year1;
    ret['months'] = month2 - month1;
    ret['days'] = day2 - day1;

    /*
     * Now we deal with the negatives
     */

    /*
     * First if the day difference is negative
     * eg dt2 = 13 oct, dt1 = 25 sept
     */
    if (ret['days'] < 0) {
        /*
         * Use temporary dates to get the number of days remaining in the month
         */
        var dtmp1 = new Date(dt1.getFullYear(), dt1.getMonth() + 1, 1, 0, 0, -1);

        var numDays = dtmp1.getDate();

        ret['months'] -= 1;
        ret['days'] += numDays;

    }

    /*
     * Now if the month difference is negative
     */
    if (ret['months'] < 0) {
        ret['months'] += 12;
        ret['years'] -= 1;
    }

    var DateDiffMessage = "";
    if (ret.years > 0) {
        DateDiffMessage += ret.years + " Years ";
    }
    if (ret.months > 0) {
        DateDiffMessage += ret.months + " Months ";
    }
    if (ret.days > 0) {
        DateDiffMessage += ret.days + " Days ";
    }

    return DateDiffMessage;
}

function kendoGridScroll() {
    var tableGrid = $(".k-grid").find('table');
    tableGrid.wrap('<div class = "table-responsive"></div>');
}