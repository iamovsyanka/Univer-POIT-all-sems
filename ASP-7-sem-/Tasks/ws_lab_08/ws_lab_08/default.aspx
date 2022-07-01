<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ws_lab_08._default" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<meta charset="utf-8" />
    <script src="jquery-1.10.2.js"></script>
</head>
<body>
    <input type="text" id="key" value="key" />
    <input type="number" id="value" value="0" />
    <select id="method" name = "method" >
        <option value = "SetM" selected>SetM(string key, int value)</option>
        <option value = "GetM" >GetM(string key)</option>
        <option value = "AddM" >AddM(string key, int value)</option>
        <option value = "SubM" >SubM(string key, int value)</option>
        <option value = "MulM" >MulM(string key, int value)</option>
        <option value = "DivM" >DivM(string key, int value)</option>
        <option value = "ErrorExit" >ErrorExit()</option>
    </select>

    <input type="button" onclick="send()" value="send" />
    <input type="text" id="result" />

    <script>
        function send() {
            let data = {
                id: "1",
                jsonrpc: "2.0",
                method: $("#method").val(),
                params: {
                    key: $("#key").val(),
                    value: $("#value").val()
                }
            };

            data = `[${JSON.stringify(data)}]`;

            $.ajax({
                type: "POST",
                url: "http://localhost:54509/api/RAA",
                contentType: "application/json",
                data: data,
                success: ([result]) => {
                    $("#result").val(result.Error ? result.Error : result.Result === null ? "Value is not Set" : `Result: ${result.Result}`);
                },
                error: error => {
                    console.log(error);
                }
            })
        }
    </script>
</body>
</html>
