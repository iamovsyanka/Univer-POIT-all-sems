<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="jquery-3.4.1.js"></script>
    <script>
        function getSum_Ajax() {
            let x = parseInt($("#x").val()),
                y = parseInt($("#y").val());

            const data = `{"x":${x},"y":${y}}`;

            $.ajax({
                url: "Simplex.asmx/addS",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: data,
                success: result => {
                    $("#result").text(JSON.stringify(result));
                },
                error: error => {
                    console.log(error);
                }
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <input type="text" id="x"/>
                <input type="text" id="y"/>
                <input type="button" onclick="getSum_Ajax()" value="addS" />
            </div>
            <div id="result"></div>
        </div>
    </form>
</body>
</html>