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
                    var reader = new FileReader();
                    reader.onload = function (event) {
                        $("#document-area").val(event.target.result);
                    }
                    name = e.target.files[0].name;
                    reader.readAsText(new Blob([e.target.files[0]], {
                        "type": "application/json"
                    }));

                    //fr.readAsText(file);
                }
            });
        });

    $("#save_file").on("click",
        function (e) {
            e.preventDefault();
            var blob = new Blob([$("#document-area").val()], {
                "type": "application/json"
            });

            var a = document.createElement("a");
            a.download = name;
            a.href = URL.createObjectURL(blob);
            document.body.appendChild(a);
            a.click();
            $("#document-area").val("");
            $("#upload-input").value = "";
            document.body.removeChild(a);
        }
    );

})