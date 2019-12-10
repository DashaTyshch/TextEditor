$(document).ready(function () {
    var queryGuid = null;
    var fileText = null;
    var fileName = null;

    $("#open-file").on("click",
        function (e) {
            e.preventDefault();
            $("#upload-input").click();
        });

    $("#upload-input").on("change",
        function (e) {
            e.preventDefault();
            var file = $(this)[0].files[0];
            
            $("#loader").show();
            $.ajax({
                url: "/Home/UploadFile?path=" + file.name,
                type: 'GET',
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.result) {
                        var reader = new FileReader();
                        reader.onload = function (event) {
                            $("#document-area").val(event.target.result);
                            fileText = $("#document-area").val();
                        }
                        fileName = e.target.files[0].name;
                        reader.readAsText(new Blob([e.target.files[0]], {
                            "type": "application/json"
                        }));

                        queryGuid = data.Guid;
                        $("#save_file").removeClass("disabled");
                    }
                    $("#loader").hide();

                }
            });
        });

    $("#save_file").on("click",
        function (e) {
            e.preventDefault();
            $("#loader").show();
            var newText = $("#document-area").val();

            var formData = new FormData();
            formData.append("guid", queryGuid);
            formData.append("isEdited", fileText !== newText);

            $.ajax({
                url: "/Home/SaveFile",
                type: "POST",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    if (!data.result) {
                        
                    }
                    $("#save_file").addClass("disabled");
                    $("#loader").hide();
                }
            });

            var blob = new Blob([newText], {
                "type": "application/json"
            });

            var a = document.createElement("a");
            a.download = fileName;
            a.href = URL.createObjectURL(blob);
            document.body.appendChild(a);
            a.click();
            $("#document-area").val("");
            $("#upload-input").val("");
            document.body.removeChild(a);
        }
    );

})