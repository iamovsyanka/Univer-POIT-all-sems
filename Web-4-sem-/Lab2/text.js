function getText()
{
  var xmlhttp;
  if (window.XMLHttpRequest) xmlhttp=new XMLHttpRequest();
  else xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");

  xmlhttp.onreadystatechange=function()
  {
    if (xmlhttp.readyState === 4 && xmlhttp.status === 200)
    {
      document.getElementById("myDiv").innerHTML = xmlhttp.responseText;
    }
    else if(request.status === 404)
    {
      alert("Ошибка: запрашиваемый скрипт не найден!");
    }
  }

  xmlhttp.open("GET","ajax.txt", true); 
  xmlhttp.send();
}