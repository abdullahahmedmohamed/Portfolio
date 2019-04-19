/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


var myCanvas = document.getElementById("myCanvas");
var cntxt = myCanvas.getContext("2d");
var road = document.getElementById("road");
//var car1 = document.getElementById("player-car");
//var car2 = document.getElementById("enemy-car");


// Road For Cars
var roadImg = road;//new Image(480, 900);
//roadImg.src="images/Road.png";

// Blue Car For Player
var playerCar = new Image();
playerCar.src="images/car1.png";


// Yellow Car For Enemy 
var enemyCar = new Image();
enemyCar.src="images/car2.png";

// Enemy Car Movement Speed
var eCarSpeed=0; // lvl_1()=> to set first level of eCarSpeed

// boolean variabel To detect player Car has Crushed 
var crushed = false ;

var score=0;
var scoreElement = document.getElementById("score");

var puseGame= false;

// Initial Value of Cars Places
playerCar_X=myCanvas.width/2;
playerCar_Y=myCanvas.height-playerCar.height;

InitialEnemyCar_Y=enemyCar.height*-1;
// the gap between each enemy cars
var gapBetweenCar =300;
//Real Width of Game (The Road Between Right Edge and Left Edge)
var rightEdge=60; // Starting From The Left Of The Screen
var leftEdge=335; // Starting From The Left Of The Screen to The Right Edge of The Road

var cars=new Array();
var numberOfEnemyCars=3;

// fill Enemy Cars array with number of enemy cars 
for(var i=0 ;i<numberOfEnemyCars;i++)
{
    cars[i]=
        {
            // Get Random Place on THe Road Between  Right Edge and Left Edge
           x:Math.floor(Math.random() * (leftEdge - rightEdge  + 1)) + rightEdge,
           y:InitialEnemyCar_Y-(gapBetweenCar*i) 
        };
}


function draw()
{
    if (puseGame) return ;
    if (crushed)
    {alert("Sorry Crushed"); return ;}
    // Draw Road
    cntxt.drawImage(roadImg,0,0);
    // Draw Player Car
    cntxt.drawImage(playerCar,playerCar_X,playerCar_Y);
       
    // To Check For on my Rules for each enemy Car and my car =>(check if player car get crushed by any of enemy cars)
    for (var j = 0; j < cars.length; j++) 
    {
     
    var eCar_Height = (cars[j].y+enemyCar.height) ;
    var eCar_Width = (cars[j].x+enemyCar.width);
    rulles(playerCar_Y,playerCar_X,playerCar_X+playerCar.width,playerCar_Y+playerCar.height,cars[j].y,cars[j].x,eCar_Height,eCar_Width);
    
    }
    
    // Draw all of enemy cars with new positions 
   for(var z=0 ; z< cars.length ; z++)
   {
       cntxt.drawImage(enemyCar,cars[z].x,cars[z].y);
       cars[z].y+=eCarSpeed;
   }
   
    // Check on all of enemy cars if they reached the end of the road so i'll make the start from the beginning 
  for(var n=0 ; n< cars.length ; n++)
   {
      if(cars[n].y>=roadImg.height)
            {  cars[n].y=InitialEnemyCar_Y;  
               cars[n].x=Math.floor(Math.random() * (leftEdge - rightEdge  + 1)) + rightEdge;
            }
   }
   cntxt.drawImage(playerCar,playerCar_X,playerCar_Y);
    window.requestAnimationFrame(draw);
}

draw();
setInterval(setScore,1000);
			
function setScore(){
	if (puseGame || crushed) return ;
	score+=eCarSpeed;
	scoreElement.innerHTML="Score : "+score;
}	

function rulles(playerCar_Y,playerCar_X,playerCar_X_Plus_Width,playerCar_X_Plus_Height,eCarY,eCarX,eCarY_Plus_Height,eCarX_Plus_Width)
{
    
 pCar={startY:playerCar_Y , endY:playerCar_X_Plus_Height , startX:playerCar_X , endX:playerCar_X_Plus_Width};   
 eCar={startY:eCarY , endY:eCarY_Plus_Height , startX:eCarX , endX:eCarX_Plus_Width};   
    
    /*
     * The Rules 
     * Crush happened if the Start Edge Of pCar(X) fall between start edge(X) and end edge(X) of one of enemy Cars (eCar(X_firstEdge) <= pCar(X_firstEdge) <= eCar(X_lastEdge) )
     * Or
     * the End Edge of pCar(X) fall between start edge(X) and end edge(X) of one of enemy Cars (eCar(X_firstEdge) <= pCar(X_lastEdge) <= eCar(X_lastEdge) )
     * 
     * All of This must happened on the Same Line of Y 
     * and 
     * 
     * the Start Edge Of pCar{Y} fall between start edge{Y} and end edge{Y} of one of enemy Cars (eCar(Y_firstEdge) <= pCar(Y_firstEdge) <= eCar(Y_lastEdge) )
     * Or
     * the End Edge of pCar{Y} fall between start edge{Y} and end edge{Y} of one of enemy Cars (eCar(Y_firstEdge) <= pCar(Y_lastEdge) <= eCar(Y_lastEdge) )
     */
    
    if((pCar.startY >= eCar.startY && pCar.startY <= eCar.endY) || (pCar.endY >= eCar.startY && pCar.endY <= eCar.endY) )
    {
        /* in Case two car in the Same line (face to face) => pCar body in the Y area of eCar Body but maybe they didnt cushed 
         * maybe they not in the Same Area of X
        */
       
       // In Case the pCar(X_firstEdge) fall between the First and Last  X edges for one of enemy Cars
        if((pCar.startX >= eCar.startX && pCar.startX <=eCar.endX))
        {
              
              crushed=true;
        }
       // In Case the pCar(X_lastEdge) fall between the First and Last  X edges for one of enemy Cars
        if((pCar.endX >= eCar.startX && pCar.endX <=eCar.endX))
        {
            
            crushed=true;
        }
        
    }
    
    
}

// Player Car Movements Tools and Rules 
 var moveStep =30;
document.onkeydown =function ()
{
	if (puseGame) return ;
    if(window.event.keyCode===37) // Right 
    {
        if(playerCar_X>65)
        {
        playerCar_X-=moveStep;
        }
        
        
    }
    else if (window.event.keyCode===38)//UP
    {
        
        if(playerCar_Y>moveStep)
        {
        playerCar_Y-=moveStep;
        }
    }
    else if (window.event.keyCode===39)// LEFT
    {
     if(playerCar_X<340)
        {
        playerCar_X+=moveStep;
        
        }
    }
    else if (window.event.keyCode===40)// DOWN
    {
        
		if(playerCar_Y<myCanvas.height-playerCar.height)
        {
        playerCar_Y+=moveStep;
        }
    }
};



// Controllers Of Game  -->
		 
            lvl_1();
            var currentLVL=1;
            
            function lvl_1()
            {
               eCarSpeed=4;
                currentLVL=1;
            }
            function lvl_2()
            {
               eCarSpeed=6;
                currentLVL=2;
            }
            function lvl_3()
            {
                eCarSpeed=8;
                currentLVL=3;
            }
            function lvl_4()
            {
                eCarSpeed=10;
                currentLVL=4;
            }
            function Puse()
            {
                puseGame=true;
            }
             function ContinueGame()
            {
               puseGame=false;
			   draw();
            }
            function newGame()
            {
                location.reload();

            }