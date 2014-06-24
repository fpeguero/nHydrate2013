(function ($) {

    $.fn.popupAddOrEdit = function (options) {
        //urlGet
        //urlPost
        //showTitle
        //buttons
        //rediretOrReload
        //functionCall

        var settings = $.extend({
            // These are the defaults.
            urlGet: "",
            urlPost: "",
            showTitle: true,
            buttons: [{
                label: 'Cerrar',
                action: function (dialog) {
                    $('.modal').removeClass('bounce');
                        $('.modal').addClass('rollOut');
                        setTimeout(function () {
                            dialog.close();
                        }, 1000);
                }
            },
                        {
                            id: 'btn-1',
                            label: 'Guardar',
                            cssClass: 'btn-success',
                            action: function (dialog) {
                                var $button = this; // 'this' here is a jQuery object that wrapping the <button> DOM element.
                                actionPost(dialog, $button);
                            }
                        }],
            rediretOrReload: "reload",
            urlAfterPost: "",
            //functionCall: null
        }, options);


        BootstrapDialog.show({
            message: $('<div></div>').load(settings.urlGet),
            showTitle: settings.showTitle,
            buttons: settings.buttons,
        });


        function onShow() {

            

        }

        //settings.functionCall();

        function actionPost($dialog, $button) {

            $button.disable();
            $button.spin();
            $dialog.setClosable(false);

            console.log($dialog.getModalContent());
            var $content = $dialog.getModalContent();

            var $form = $content.find("form");

            //Ajax Call
            $.ajax({
                url: settings.urlPost,
                data: $form.serialize(),
                type: 'post',
                success: function (data, textStatus, XMLHttpRequest) {
                    if (data.Result == "Ok") {

                        if (settings.rediretOrReload == "rediret") {
                            window.location.href = data.Url;
                        } else {

                            if (settings.functionCall == null) {
                                window.location.reload();
                            } else {
                                settings.functionCall();
                            }
                        }
                    } else {
                        $dialog.getModalBody().html(data);

                        $button.enable();
                        $button.stopSpin();
                        $dialog.setClosable(true);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    //console.log(jqXHR);
                    //console.log(textStatus);
                    //console.log(errorThrown);
                    // $("#" + dialogId).remove();
                    alert(errorThrown);
                }
            });
        }

    };

}(jQuery))