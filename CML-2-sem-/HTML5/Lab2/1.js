function drawgist() {
	const canvas = document.getElementById("draw1");
	const x = canvas.getContext("2d");

	x.beginPath(); 
	x.moveTo(100, 100); 
	x.lineTo(100, 400); 
	x.lineTo(400, 400); 
	x.moveTo(100, 110); 
	x.lineTo(95, 110); 
	x.moveTo(100, 250); 
	x.lineTo(95, 250);
	x.strokeStyle = "black";
	x.stroke();

	x.font='20px Verdana';
	x.fillStyle='#60016d'; 
	x.fillText("Количество сданных лаб", 150, 40);
		
	x.font='10px Verdana';
	x.fillStyle='black'; 
	x.fillText("КЯР", 150, 410);
	x.fillText("ОАиП", 250, 410);
	x.fillText("ЯП", 350, 410);

	x.fillText("22", 80, 110);
	x.fillText("10", 80, 250);

	let img = new Image();
	img.src = '1.jpg';
	img.onload = function() {
		x.fillStyle = x.createPattern(img, 'repeat');
  		x.fillRect(130, 120, 60, 280);
	};

	gradient = x.createLinearGradient(250, 30, 150, 50);
    gradient.addColorStop(0, "skyblue");
    gradient.addColorStop(1, "white");
    x.fillStyle = gradient;
  	x.fillRect(230, 250, 60, 150);

  	x.fillRect(330, 250, 60, 150);
}	

function drawdiagr() {
	const canvas = document.getElementById("draw2");
	const y = canvas.getContext("2d");
	y.beginPath();
	y.arc(150, 300, 90, 0, 2*Math.PI);
	y.lineWidth = 1;
	y.strokeStyle = 'grey';
	y.stroke();
	y.closePath();
			
	y.beginPath(); 
	y.fillStyle = "skyblue"; 
	y.arc(150, 300, 90, -Math.PI/180*90, 0); 
	y.lineTo(150,300); 
	y.fill();
	y.closePath();
			
	y.beginPath(); 
	y.fillStyle = "#00FF7F"; 
	y.arc(150, 300, 90, -Math.PI/180*150, -Math.PI/180*90); 
	y.lineTo(150,300); 
	y.fill();
	y.closePath();
			
	y.beginPath(); 
	y.fillStyle = "#EE82EE"; 
	y.arc(150, 300, 90, -Math.PI/180*280, -Math.PI/180*150); 
	y.lineTo(150,300); 
	y.fill();
	y.closePath();

	y.beginPath(); 
	y.fillStyle = "khaki"; 
	y.arc(150, 300, 90, -Math.PI/180*0, -Math.PI/180*280); 
	y.lineTo(150,300); 
	y.fill();
	y.closePath();

	y.font='20px Verdana';
	y.fillStyle='#60016d'; 
			
	y.shadowOffsetX=3;
	y.shadowOffsetY=5;
	y.shadowBlur=5;
	y.shadowColor='#DCDCDC';
	y.fillText("Распорядок дня", 150, 40);

	y.fillStyle = "skyblue";
  	y.fillRect(350, 250, 10, 10);
  	y.fillText("Нытьё", 365, 260);

  	y.fillStyle = "#00FF7F";
  	y.fillRect(350, 270, 10, 10);
  	y.fillText("Нытьё", 365, 280);

  	y.fillStyle = "#EE82EE";
  	y.fillRect(350, 290, 10,10);
  	y.fillText("Нытьё", 365,  300);

  	y.fillStyle = "khaki";
  	y.fillRect(350, 310, 10, 10);
  	y.fillText("Нытьё", 365, 320);
}