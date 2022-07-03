function getClock(url)
{
  var request; 
  if(window.XMLHttpRequest)      request = new XMLHttpRequest(); 
  else if(window.ActiveXObject)  request = new ActiveXObject("Microsoft.XMLHTTP");  
  else  return; 

  request.onreadystatechange = function()
  {
    if(request.status === 200)
    {     
      document.getElementById("printResult").innerHTML = "<b>"+request.responseText+"</b>"; 
    }

    else if(request.status === 404)
    {
      alert("Ошибка: запрашиваемый скрипт не найден!");
    }
  } 
  request.open ('POST', url, true); 
  request.send ('');
}