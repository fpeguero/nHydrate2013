//----------------------------------------------------------
// @author: Icinetic TIC SL
//----------------------------------------------------------

var dialogCustomActions = (function() {
   

    function addEvent(options) {

        var gridPass = options.gridId;
        var messagePass = options.messages;
        var titleWindow = options.titlewindow;
        var objectSelctor = options.selector;

        var mygridId = gridPass;

        $("#" + mygridId).on("click", objectSelctor, function (evt) {
            evt.preventDefault();
            var url = $(this).prop("href");

            dialogUtils.confirmDialog({
                title: titleWindow,
                message: messagePass,
                funcOK: ajaxEjecute(url, mygridId)
            });
            return false;
        });
    }
    

    function ajaxEjecute(url, mygridId) {
        return function () {
            $.ajax({
                url: url,
                type: 'post',
                success:
                    function (data, textStatus, XMLHttpRequest) {
                        reload(mygridId);

                        messagesUtils.showNotificacion({
                            cssMainClass: data.cssMainClass,
                            title: data.title,
                            body: data.body
                        });
                    },
                error:
                    function (jqXHR, textStatus, errorThrown) {
                        formUtils.showMessage(jqXHR.responseText);
                    }
            });
        };
    }

    function reload(mygridId) {
        var dataTable = getDataTable(mygridId);
        dataTable.fnDraw();
    }
    function getDataTable(mygridId) {
        return $("#" + mygridId).dataTable();
    }

    return {
        addEvent: addEvent
        
    };
})();


var dialogUtils = (function() {

    function getModalHtml(id) {
        return  "<div class='modal fade' id='"+id+"' tabindex='-1' role='dialog' aria-labelledby='"+id+"-label' aria-hidden'true'>" +
                    "<div class='modal-dialog'>" +
                        "<div class='modal-content'>" +
                            "<div class='modal-header '>" +
                                "<button type='button' class='close' data-dismiss='modal' aria-hidden='true' tabindex='-1'>&times;</button>" +
                                "<h4 class='modal-title' id='"+id+"-label'></h4>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                                "<p>Body</p>" +
                            "</div>" +
                            "<div class='modal-footer '>" +
                                "<button type='submit' class='button-ok btn btn-primary'>" + $.uiLocale.common.accept + "</button>" +
                                "<button type='button' class='button-cancel btn btn-default' data-dismiss='modal'>" + $.uiLocale.common.cancel + "</button>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>";
        
    }

    function confirmDialog(settings) {
        if ($("dialog-box").length == 0) {
            $("body").append(getModalHtml("dialog-box"));
            $("#dialog-box").modal({ show: false });
        }

        $("#dialog-box .modal-title").text(settings.title);
        $("#dialog-box .modal-body").html(settings.message);
        $("#dialog-box button.button-ok").unbind("click").bind("click", function () {
            $("#dialog-box").modal("hide");
            if (settings.funcOK) {
                settings.funcOK();
            }
        });
        $('#dialog-box').modal('show')
                        .on("shown.bs.modal", function () {
                            $("#dialog-box button.button-ok").focus();
                        });
    }

    return {
        confirmDialog: confirmDialog,
        getModalHtml: getModalHtml
    };
})();


var messagesUtils = (function () {

    function getDivHtml() {
        return '<div id="showMessage" class=" message"> ' +
                    '<h3 id="showMessageTitle"></h3>' +
                    '<p id="showMessageBody"></p>' +
               '</div>';
    }

    function showNotificacion(settings) {
        $("body").append(getDivHtml());

        $("#showMessage").addClass(settings.cssMainClass);
        $("#showMessageTitle").html(settings.title);
        $("#showMessageBody").html(settings.body);

        showMessage1();
    }

    return {
        getDivHtml: getDivHtml,
        showNotificacion: showNotificacion
    };

})();




var dataTablesGridAdapter = (function () {

    function getDataTable(gridId) {
        return $("#" + gridId).dataTable();
    }

    function reload(gridId) {
        var dataTable = getDataTable(gridId);
        dataTable.fnDraw();
    }

    function initialize(gridId) {
        var dataTable = getDataTable(gridId);
        dataTable.fnFilter("");
    }
    
    function getCurrentFilter(gridId) {
        var dataTable = getDataTable(gridId);
        var search = dataTable.fnSettings().oPreviousSearch;
        return search.sSearch || "";
    }

    function setCurrentFilter(gridId, filter) {
        var dataTable = getDataTable(gridId);
        var prevSearch = dataTable.fnSettings().oPreviousSearch;
        var sSearch = prevSearch.sSearch || "";
        if (sSearch != filter) {
            dataTable.fnFilter(filter);
        }
    }

    function findGrid(containerSelector) {
        return $(".dataTable", containerSelector);
    }

    return {
        findGrid: findGrid,
        reload: reload,
        setCurrentFilter: setCurrentFilter,
        getCurrentFilter: getCurrentFilter,
        initialize: initialize
    };
})();

var selectionGridUtils = (function (gridAdapter, formUtils) {

    var checkedRows = {};

    function showSelectionPopup(settings) {
        var $popup = $("#" + settings.popUpId);
        $(".modal-title", $popup).text($.uiLocale.selectionDialog.title);
        $(".button-ok", $popup).text($.uiLocale.common.select);
        $(".modal-dialog", $popup).css({ width: settings.width || '90%' });
        $popup
            .on('hidden.bs.modal', function() {
                if (settings.funcCancel) {
                    settings.funcCancel();
                }
            })
            .on("show.bs.modal", function() {
                if (settings.openFunc) {
                    settings.openFunc();
                }
            })
            .modal({ show: true, backdrop: "static" });

        $(".button-ok", $popup).unbind("click").bind("click", function () {
            if (settings.funcOK) {
                settings.funcOK();
            }
            $popup.modal("hide");
        });
    }

    function setMessageItemsSelected(gridId) {
        var elem = $("#selected" + gridId);
        if (elem.length > 0) {
            var obj = checkedRows[gridId];
            var size = 0, key; // Count elements
            for (key in obj) {
                if (obj.hasOwnProperty(key)) size++;
            }
            elem.text(size);
        }
    }

    function enableGridSelection(gridId) {
        checkedRows[gridId] = {};
        $("#" + gridId).on("click", "tbody tr td", function (e) {
            if (!$(e.target).is("input")) {
                var $checkbox = $("input.select-row", $(this).closest("tr"));
                if ($checkbox.length != 0) {
                    $checkbox.prop("checked", !$checkbox.prop("checked")).change();
                }
            }
        });
        
        $("#" + gridId).on("change", "input.select-row", function (e) {
            var rowId = $(this).data("id");
            if ($(this).is(":checked")) {
                $(this).closest("tr").addClass("row-selected");
                checkedRows[gridId][rowId] = "1";
            } else {
                $(this).closest("tr").removeClass("row-selected");
                delete checkedRows[gridId][rowId];
            }
            setMessageItemsSelected(gridId);
            e.stopPropagation();
            return false;
        });
        
        $("#" + gridId).on("click", "input.select-all-rows", function () {
            $("#" + gridId + " input.select-row").prop("checked", $(this).is(":checked")).change();
        });
    }

    function isRowChecked(gridId, rowId) {
        return checkedRows[gridId][rowId] == "1";
    }

    function getCheckedRows(gridId) {
        var result = [];
        for (var key in checkedRows[gridId]) {
            result.push(key);
        }
        return result;
    }

    function showSelection(popUpId, availableGridId, selectedGridId, url, masterId) {
        $("#" + popUpId).css({ display: "inherit" });
        checkedRows[availableGridId] = {};
        setMessageItemsSelected(availableGridId);
        var settings = {
            title: $.uiLocale.selectionDialog.title,
            popUpId: popUpId,
            openFunc: function () { gridAdapter.initialize(availableGridId); },
            funcOK: function () {
                var selectedIds = selectionGridUtils.getCheckedRows(availableGridId);
                if (selectedIds.length == 0) return;
                $.ajax({
                    url: url,
                    data: { ids: selectedIds, masterId: masterId },
                    type: 'post',
                    traditional: true,
                    success:
                        function (data, textStatus, XMLHttpRequest) {
                            gridAdapter.reload(selectedGridId);
                        },
                    error:
                        function (jqXHR, textStatus, errorThrown) {
                            alert($.uiLocale.errors.serverError);
                        }
                });
            }
        };
        showSelectionPopup(settings);
        return false;
    }
    
    function setupSelectionPopup(options) {
        $(".add-button", "#"+options.tabId).click(function () {
            showSelection(options.popUpId, options.availableGridId, options.selectedGridId, options.url, options.masterId);
        });
    }

    return {
        enableGridSelection: enableGridSelection,
        isRowChecked: isRowChecked,
        getCheckedRows: getCheckedRows,
        setupSelectionPopup: setupSelectionPopup
    };
})(dataTablesGridAdapter, formUtils);

var formUtils = (function (dialogUtils) {
    function showMessage(text, type) {
        $("#messages").html(text); // [Convention] there must be an element with id="messages" in the DOM
    }

    function setupFormActionButtons(options) {
        var formId = options.formId;
        var backUrl = options.indexPageUrl;
        var buttonsContainerSelector = options.buttonsContainerSelector;

        if (formId) {
            $(".save-button", buttonsContainerSelector).click(function() {
                $("#" + formId).submit();
            });
        }

        $(".back-button", buttonsContainerSelector).click(function () {
            var $form = $("#" + formId);
            var theFormIsDirty = $form.data("isDirty");
            if (theFormIsDirty) {
                dialogUtils.confirmDialog({
                    title: $.uiLocale.cancelChangesDialog.title,
                    message: $.uiLocale.cancelChangesDialog.message,
                    funcOK: function () {
                        location.href = backUrl;
                    }
                });
            } else {
                location.href = backUrl;
            }
            return false;
        });
    }
    
    function setupFormControls(formId) {

        var formSelector = "#" + formId;
        
        // Set buttons appearance
        $(".button").button();

        // Set number/decimal parsing method
        $.validator.methods.number = function (value, element) {
            $el = $(element);
            if ($el.hasClass("decimal-number")){
              if (value == "" || !isNaN(Globalize.parseFloat(value))) 
                 return true;
            }
            else if($el.hasClass("integer-number")){                
               if (value == "" || value == Globalize.parseInt(value))
                 return true;
            }
            return (value == "" || value == Globalize.parseInt(value));
        };

        var currentCulture = Globalize.culture().name;
        var locale = currentCulture.substr(0, 2).toLowerCase() || "en";
        var dateFormat = locale == "en" ? "mm/dd/yyyy" : "dd/mm/yyyy";
        var weekStartDay = locale == "en" ? 0 : 1;

        // Activate date pickers
        $(formSelector + ' .date').datepicker({
            autoclose: true,
            todayHighlight: true,
            language: locale,
            format: dateFormat,
            weekStartDay: weekStartDay
        });
       
        jQuery.validator.addMethod('date',
            function (value, element, params) {
                if (this.optional(element)) {
                    return true;
                };
                var ok = false;
                try {
                    ok = Globalize.parseDate(value) != null;
                } catch (err) {
                    ok = false;
                }
                return ok;
            },
            ''
        );
        
        // Numeric and special editors
        var groupSeparator = Globalize.cultures[currentCulture].numberFormat[","];
        var decimalSeparator = Globalize.cultures[currentCulture].numberFormat["."];

        $(formSelector + ' :input').change(function () {
            $(this).closest("form").data("isDirty", true);
        });

        // Set focus to first visible control
        $(formSelector + " :input:visible:first").focus().select();

        // Enable form submit on enter
        $(formSelector).keypress(function (e) {
            if (e.keyCode == 13) {
                $(formSelector).submit();
                return false;
            }
            return true;
        });
    }

    return {
        showMessage: showMessage,
        setupFormActionButtons: setupFormActionButtons,
        setupFormControls: setupFormControls
    };
})(dialogUtils);

var gridUtils = (function (gridAdapter, formUtils, dialogUtils) {

    function initializePopupForm(dialogId, settings) {
        var $dialog = $("#" + dialogId);
        var $form = $("form", $dialog);
        $.validator.unobtrusive.parse($form);
        formUtils.setupFormControls($form.prop("id"));

        $dialog.attr('title', settings.title);

        $(".button-ok", $dialog).unbind("click")
            .bind("click", function () {
                $form.submit();
            });

        $form.unbind("submit").bind("submit", function (e) {
            if (!$form.valid())
                return false;

            $dialog.modal("hide");
            if (settings.funcOK) {
                settings.funcOK();
            }
            return false;
        });
    }


    function showDetailPopupForm(detailName, data, settings, url, disableOpen) {
        var dialogId = detailName + "-dialog";
        var $dialog = $("#" + dialogId);
        $(".modal-body", $dialog).html(data);

        // Set fieldset legend as bootstrap modal's title
        var $legend = $(".modal-body legend", $dialog);
        var text = $legend.text();
        $legend.remove();
        $(".modal-title", $dialog).text(text);
        $(".modal-dialog", $dialog).css({ width: settings.width || '90%' });

        // Setting popup form action
        var $form = $dialog.find('form:first');
        $form.attr('action', url);

        // Renaming popup input IDs (to avoid duplicates in the page)
        $("input", $form).each(function () {
            var currentId = $(this).attr('id');
            $(this).attr('id', detailName + currentId);
        });

        // Show popup
        if (!disableOpen) {
            var popupId = settings.popUpId;
            initializePopupForm(dialogId, settings);
            $dialog.modal({ show: true, backdrop: 'static' });
            $dialog.on('hidden.bs.modal', function () {
                        $dialog.remove();
                    })
                    .on("shown.bs.modal", function () {
                        if (settings.openFunc) {
                            settings.openFunc();
                        }
                        $(":input:visible:first", $form).focus().select();
                    });
        }
    }

    function showAddOrEditPopup(detailName, gridId, url, mode) {
        var dialogId = detailName + "-dialog";
        if ($("#"+dialogId).length == 0) {
            $("body").append(dialogUtils.getModalHtml(dialogId));
        }

        var settings = {
            title: $.uiLocale.common.mode,
            popUpId: dialogId,
            okText: $.uiLocale.common.save,
            funcOK: function () {
                $.ajax({
                    url: url,
                    data: $("#" + dialogId+" form:first").serialize(),
                    type: 'post',
                    success: function (data, textStatus, XMLHttpRequest) {
                        gridAdapter.reload(gridId);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        //console.log(jqXHR);
                        //console.log(textStatus);
                        //console.log(errorThrown);
                        $("#" + dialogId).remove();
                        alert($.uiLocale.errors.serverError);
                    }
                });
            }
        };
        $.ajax({
            url: url,
            type: 'get',
            cache: false,
            success: function (data, textStatus, XMLHttpRequest) {
                    showDetailPopupForm(detailName, data, settings, url);
                },
            error: function (jqXHR, textStatus, errorThrown) {
                    alert($.uiLocale.errors.serverError);
                }
        });
    }

    function ajaxDelete(url, gridId) {
        return function () {
            $.ajax({
                url: url,
                type: 'post',
                success:
                    function (data, textStatus, XMLHttpRequest) {
                        gridAdapter.reload(gridId);
                    },
                error:
                    function (jqXHR, textStatus, errorThrown) {
                        formUtils.showMessage(jqXHR.responseText);
                    }
            });
        };
    }

    function setupGridRowButtons(gridId) {
        gridId = gridId.gridId || gridId;
        $("#" + gridId).on("click", "a.row-delete", function () {
            var url = $(this).prop("href");
            dialogUtils.confirmDialog({
                title: $.uiLocale.deleteDialog.title,
                message: $.uiLocale.deleteDialog.message,
                funcOK: ajaxDelete(url, gridId)
            });
            return false;
        });
        $("#" + gridId).on("click", "a.row-popup-edit", function () {
            var url = $(this).prop("href");
            var detailName = $(this).data("detailname");
            showAddOrEditPopup(detailName, gridId, url, 'edit');
            return false;
        });
    }

    function setupGridToolbarButtons(options) {
        
        var createItemUrl = options.addUrl;
        var generateReportUrl = options.reportUrl;
        var toolbarContainerSelector = options.toolbarContainerSelector;
        var gridId = options.gridId;

        $(".create-button", toolbarContainerSelector).click(function () {
            location.href = createItemUrl;
            return false;
        });
        $(".popup-create-button", toolbarContainerSelector).click(function () {
            var url = createItemUrl;
            var detailName = $(this).data("detailname");
            showAddOrEditPopup(detailName, gridId, url, 'add');
            return false;
        });
        $(".report-button", toolbarContainerSelector).click(function () {
            var currentSearch = gridAdapter.getCurrentFilter(gridId);
            generateReportUrl += (generateReportUrl.indexOf("?")>=0 ? "&" : "?");
            location.href = generateReportUrl + "search=" + encodeURIComponent(currentSearch);
            return false;
        });
    }
    function setupGridSearchBox(options) {
        var gridId = options.gridId;
        var searchContainerSelector = options.searchContainerSelector;
        $(searchContainerSelector + " .search-box").bind("keypress", function (e) {
            if (e.keyCode == 13) {
                $(searchContainerSelector + " .search-button").click();
                return false;
            }
            return true;
        });
        $(searchContainerSelector + " .search-button").click(function () {
            var filter = $(searchContainerSelector + " input.search-box").val();
            gridAdapter.setCurrentFilter(gridId, filter);
            return false;
        });
        $(searchContainerSelector + " .clean-button").click(function () {
            $(searchContainerSelector + " .search-box").val("");
            gridAdapter.setCurrentFilter(gridId, "");
            return false;
        });

        $(".search-Select").on("change", function () {
            gridAdapter.reload(gridId);
            return false;
        });
        
    }

    return {
        setupGridRowButtons: setupGridRowButtons,
        setupGridToolbarButtons: setupGridToolbarButtons,
        setupGridSearchBox: setupGridSearchBox
    };
})(dataTablesGridAdapter, formUtils, dialogUtils);
