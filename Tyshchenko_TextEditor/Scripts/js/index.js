$(document).ready(function () {

    $("#open-file").on("click",
        function (e) {
            e.preventDefault();
            $("#upload-input").click();
        });

    $("#upload-input").on("change",
        function (e) {
            e.preventDefault();
            var file = $(this)[0].files[0];
            //TODO: check file extension

            //var formData = new FormData();
            //formData.append('file', file);

            $.ajax({
                url: "/Home/UploadFile?path=" + file.name,
                type: 'GET',
                processData: false,
                contentType: false,
                success: function (data) {
                    var fr = new FileReader();
                    fr.onload = function () {
                        $("#document-area").val(this.result);
                    };

                    fr.readAsText(file);
                }
            });
        });

})