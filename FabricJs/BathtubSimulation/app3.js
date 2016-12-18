
		(function() {

		  var localHeight = 990;
		  var localWidth = 1860;

		  var canvas = this.__canvas = new fabric.Canvas('c');
		  canvas.backgroundColor = "#5555F5"; // background blue to help find it
		  //fabric.Object.prototype.transparentCorners = false;
		  canvas.renderAll();

		/*
		  canvas.on('mouse:over', function(e) {
		    console.log(e.target);
		    //canvas.renderAll();
		  });

		  canvas.on('mouse:out', function(e) {
		    console.log(e.target);
		    //canvas.renderAll();
		  });
		*/
		////////////////////////////WALLS//////////////////////////
			var backWall = new fabric.Rect({
			  left: 0,
			  top: 0,
			  fill: 'white',
			  stroke: 'black',
			  width: 450,
			  height: localHeight,
			  angle: 0
			});
			backWall.hasControls = backWall.hasBorders = false;
			backWall.lockMovementX = backWall.lockMovementY = true;

			var sideWall = new fabric.Rect({
			  left: 450,
			  top: 0,
			  fill: 'white',
			  stroke: 'black',
			  width: 960,
			  height: localHeight,
			  angle: 0
			});
			sideWall.hasControls = sideWall.hasBorders = false;
			sideWall.lockMovementX = sideWall.lockMovementY = true;

			var frontWall = new fabric.Rect({
			  left: 1410,
			  top: 0,
			  fill: 'white',
			  stroke: 'black',
			  width: 450,
			  height: localHeight,
			  angle: 0
			});
			frontWall.hasControls = frontWall.hasBorders = false;
			frontWall.lockMovementX = frontWall.lockMovementY = true;

			var bathSpout = new fabric.Rect({
			  left: 1635,
			  top: 950,
			  originX: 'center',
			  originY: 'center',
			  fill: 'grey',
			  stroke: 'black',
			  width: 60,
			  height: 30,
			  angle: 0
			});


			bathSpout.hasControls = bathSpout.hasBorders = false;
			bathSpout.lockMovementX = bathSpout.lockMovementY = true;
		////////////////////ShowerHead -Prune Test/////////////////
				var showerHead = new fabric.Circle({
				  radius: 20, fill: 'black', left: 1635, top: 100,   originX: 'center', originY: 'center'
				});
				var showerHead2 = new fabric.Circle({
				  radius: 25, fill: 'red', left: 1635, top: 100,   originX: 'center', originY: 'center'
				});
				var waterUse = 0;
				function updateWaterUse() {
				if (waterUse > 0.5) {
				  	showerHead2.visible = true;
				  } 
				else {
				  	showerHead2.visible = false;
				}}

				updateWaterUse();

				showerHead.on('selected', function() {
				  //console.log('selected a rectangle');
				  waterUse = 1 - waterUse;
				  updateWaterUse();
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});
// 		/////////////////TIME, TIMER, WEATHER//////////////
				var seperator = new fabric.Rect({
			left: 1425,
			top: 535,
			fill: 'black',
			width: 195,
			height: 5,
			angle: 0,
			opacity: 0.9
		});

		var seperator2 = new fabric.Rect({
			left: 1425,
			top: 400,
			fill: 'black',
			width: 195,
			height: 5,
			angle: 0,
			opacity: 0.9
		});


				var showTimeRight = new fabric.Text('default', { left: 1520, top: 200, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
		  originY: 'center',});
			showTimeRight.text = "7:32 am";
		showTimeRight.hasControls = showTimeRight.hasBorders = false;
		showTimeRight.lockMovementX = showTimeRight.lockMovementY = true;
		showTimeRight.selectable = false
		showTimeRight.evented = false

		var imgElement = document.getElementById('weather_image');
		var imgInstance = new fabric.Image(imgElement, {
		  left: 1680,
		  top: 150,
		  angle: 0,
		  opacity: 0.9
		});
		imgInstance.scale(0.4);

		var showTimeLeft= new fabric.Text('default', { left: 100, top: 200, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
		  originY: 'center',});
			showTimeLeft.text = "7:32 am";
		showTimeLeft.hasControls = showTimeLeft.hasBorders = false;
		showTimeLeft.lockMovementX = showTimeLeft.lockMovementY = true;
		showTimeLeft.selectable = false
		showTimeLeft.evented = false

		var Timer= new fabric.Text('default', { left: 280, top: 200, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
		  originY: 'center',});
			Timer.text = "00:30";
		Timer.hasControls = Timer.hasBorders = false;
		Timer.lockMovementX = Timer.lockMovementY = true;
		Timer.selectable = false
		Timer.evented = false

		var imgTimer = document.getElementById('timer');
		var imgTimerInt = new fabric.Image(imgTimer, {
		  left: 1450,
		  top: 400,
		  angle: 0,
		  opacity: 0.9
		});
		imgTimerInt.scale(0.7);
// 		//////////////////////TEMPERATURE CONTROLS ////////////////
		
		//tempDisplay.text 
		var temperature = 0;
				var tempDisplay= new fabric.Text('default', { left: 1500, top: 320, fontFamily: 'Arial', fontSize: 30, fontWeight: 'italic', originX: 'center',
				  originY: 'center',});
				tempDisplay.text = "100'F/37'C";
				tempDisplay.hasControls = tempDisplay.hasBorders = false;
				tempDisplay.lockMovementX = tempDisplay.lockMovementY = true;
				tempDisplay.selectable = false
				tempDisplay.evented = false

				var imgUp = document.getElementById('up_arrow');
				var imgUPInt = new fabric.Image(imgUp, {
				  left: 1450,
				  top: 200,
				  angle: 0,
				  opacity: 0.9
				});
				imgUPInt.scale(0.5);
				imgUPInt.evented =true;

				var imgUpBox = new fabric.Rect({
				  left: 1475,
				  top: 200,
				  width: 100,
				  height: 100,
				  angle: 0,
				  opacity: 0.0
				});
				imgUpBox.lockMovementX = imgUpBox.lockMovementY = true;

				var imgDown = document.getElementById('down_arrow');
				var imgDownInt = new fabric.Image(imgDown, {
				  left: 1485,
				  top: 350,
				  angle: 0,
				  opacity: 0.9
				});
				imgDownInt.scale(0.5);


				var tempDisplay2= new fabric.Text('default', { left: 900, top: 920, fontFamily: 'Arial', fontSize: 30, fontWeight: 'italic', originX: 'center',
				  originY: 'center',});
				tempDisplay2.text = "100'F/37'C";
				tempDisplay2.visible =false;
				tempDisplay2.hasControls = tempDisplay2.hasBorders = false;
				tempDisplay2.lockMovementX = tempDisplay2.lockMovementY = true;
				tempDisplay2.selectable = false
				tempDisplay2.evented = false

				var imgUp = document.getElementById('up_arrow');
				var imgUPInt2 = new fabric.Image(imgUp, {
				  left:  835,
				  top: 800,
				  angle: 0,
				  opacity: 0.0
				});
				imgUPInt2.scale(0.5);
				imgUPInt2.evented =true;

				var imgUpBox2 = new fabric.Rect({
				  left: 840,
				  top: 800,
				  width: 100,
				  height: 100,
				  angle: 0,
				  opacity: 0.0
				});
				imgUpBox2.lockMovementX = imgUpBox2.lockMovementY = true;

				var imgDown = document.getElementById('down_arrow');
				var imgDownInt2 = new fabric.Image(imgDown, {
				  left: 875,
				  top: 925,
				  angle: 0,
				  opacity: 0.0
				});
				imgDownInt2.scale(0.5);

		////////////////TUB FULL//////////////////////////////////
		var imgTubFull = document.getElementById('full_tub');
				var imgFullTub = new fabric.Image(imgTubFull, {
				  left: 1000,
				  top: 850,
				  angle: 0,
				  opacity: 0.9
				});
				imgFullTub.scale(0.4);
		var TubFullSelect = new fabric.Rect({
				  left: 1050,
				  top: 850,
				  width: 90,
				  height: 75,
				  fill: 'cyan', 
				  angle: 0,
				  opacity: 0.0
			});
				TubFullSelect.lockMovementX = TubFullSelect.lockMovementY = true;
				var tubFull = 0;

		function updateFullTub() {
		if (tubFull > 0.5) {
		  imgFullTub.opacity= 0.8;
		  } 
		else {
		  imgFullTub.opacity=0.0;
		}
		}

		updateFullTub();

		TubFullSelect.on('selected', function() {
		  //console.log('selected a rectangle');
		  tubFull = 1 - tubFull;
		  updateFullTub();
		 canvas.deactivateAll(); // deselect everything - so can click again 
		});



 		///// //////////////////////TV/////////////////////////////
						//imgTVInt.opacity = 1.0; //house of cards
						//imgMediaBox.opacity= 0.9; //rect
						//imgMediaInt.opacity //media icon
						var imgTV = document.getElementById('tv');
						var imgTVInt = new fabric.Image(imgTV, {
						  left: 20,
						  top: 300,
						  angle: 0,
						  opacity: 0.9
						});
						imgTVInt.scale(0.3);

						var imgTVInt2 = new fabric.Image(imgTV, {
						  left: 1450,
						  top: 650,
						  angle: 0,
						  opacity: 0.9
						});
						imgTVInt2.scale(0.3);

						var imgMedia = document.getElementById('media_icon');
						var imgMediaInt = new fabric.Image(imgMedia, {
						  left: 1775,
						  top: 450,
						  angle: 0,
						  opacity: 1.0
						});
						imgMediaInt.scale(0.4);

						var imgMediaBox = new fabric.Rect({
						  left: 1775,
						  top: 450,
						  width: 90,
						  height: 75,
						  fill: 'cyan', 
						  angle: 0,
						  opacity: 0.0
						});
						imgMediaBox.lockMovementX = imgMediaBox.lockMovementY = true;

						var imgMediaInt2 = new fabric.Image(imgMedia, {
						  left: 750,
						  top: 875,
						  angle: 0,
						  opacity: 0.0
						});
						imgMediaInt2.scale(0.4);

						var imgMediaBox2 = new fabric.Rect({
						  left: 750,
						  top: 875,
						  width: 90,
						  height: 75,
						  fill: 'cyan', 
						  angle: 0,
						  opacity: 0.0
						});
						imgMediaBox2.lockMovementX = imgMediaBox2.lockMovementY = true;

				//var mediaChooser = new fabric.Group([imgMediaInt, imgMediaInt2, imgTVInt, imgTVInt2], {originX: 'center', originY: 'center'});
		
		////////////////////////////////MUSIC//////////////////////
					//imgMusicBox.opacity=0.7; //rect 
				//imgMusicInt.opacity=0.7;	//fall out boy
				//imgMIconInt.opacity //icon 
				var imgMusic = document.getElementById('music');
				var imgMusicInt = new fabric.Image(imgMusic, {
				  left: 50,
				  top: 225,
				  angle: 0,
				  opacity: 0.0
				});
				imgMusicInt.scale(0.4);

				var imgMIcon = document.getElementById('music_icon');
				var imgMIconInt = new fabric.Image(imgMIcon, {
				  left: 1700,
				  top: 450,
				  angle: 0,
				  opacity: 0.9
				});
				imgMIconInt.scale(0.15);


				var imgMusicBox = new fabric.Rect({
				  left: 1700,
				  top: 450,
				  width: 90,
				  height: 75,
				  fill: 'cyan', 
				  angle: 0,
				  opacity: 0.0
				});
				imgMusicBox.lockMovementX = imgMusicBox.lockMovementY = true;

			
				var imgMusicInt2 = new fabric.Image(imgMusic, {
				  left: 500,
				  top: 725,
				  angle: 0,
				  opacity: 0.0
				});
				imgMusicInt2.scale(0.4);


				var imgMIconInt2 = new fabric.Image(imgMIcon, {
				  left: 675,
				  top: 875,
				  angle: 0,
				  opacity: 0.0
				});
				imgMIconInt2.scale(0.15);


				var imgMusicBox2 = new fabric.Rect({
				  left: 675,
				  top: 875,
				  width: 90,
				  height: 75,
				  fill: 'cyan', 
				  angle: 0,
				  opacity: 0.0
				});
				imgMusicBox2.lockMovementX = imgMusicBox2.lockMovementY = true;
				//var musicChooser = new fabric.Group([imgMusicInt, imgMusicInt2, imgMIconInt, imgMIconInt2], {originX: 'center', originY: 'center'});
// 		///////////BACKGROUND IMAGE/////////////////////////////
			var imgbackgrd = document.getElementById('backgrd');
			var imgbackgrdInt = new fabric.Image(imgbackgrd, {
				left: 0,
				top: 0,
			   angle: 0,
			   opacity: 0.6
			 });
			imgbackgrdInt.scale(1.38);

			var turnBgd = new fabric.Text('default', { left: 300, top: 250, fontFamily: 'Arial', fontSize: 19, fontWeight: 'italic', originX: 'center',
					originY: 'center',});
			turnBgd.hasControls = turnBgd.hasBorders = false;
			turnBgd.lockMovementX = turnBgd.lockMovementY = false;
			turnBgd.selectable = false
			turnBgd.evented = false

			var onBgd = new fabric.Rect({
			left: 200,
			top: 225,
			fill: '#c0c0c0',
			width: 200,
			height: 50,
			angle: 0,
			opacity: 0.0
			});
			onBgd.lockMovementX = onBgd.lockMovementY = true;

			var turnBgd2 = new fabric.Text('default', { left: 350, top: 950, fontFamily: 'Arial', fontSize: 19, fontWeight: 'italic', originX: 'center',
					originY: 'center',});
			turnBgd2.hasControls = turnBgd2.hasBorders = false;
			turnBgd2.lockMovementX = turnBgd2.lockMovementY = false;
			turnBgd2.selectable = false
			turnBgd2.evented = false

			var onBgd2 = new fabric.Rect({
			left: 250,
			top: 925,
			fill: '#c0c0c0',
			width: 200,
			height: 50,
			angle: 0,
			opacity: 0.0
			});
			onBgd2.lockMovementX = onBgd2.lockMovementY = true;
// 		////////////////LIGHTS/////////////////////////////////////
				var imgBulb = document.getElementById('light_bulb');
			var imgBulbInt = new fabric.Image(imgBulb, {
			  left: 1625,
			  top: 450,
			  angle: 0,
			  opacity: 0.9
			});
			imgBulbInt.scale(0.3);

			var imgBulbBox = new fabric.Rect({
			  left: 1625,
			  top: 450,
			  width: 73,
			  height: 75,
			  fill: 'yellow', 
			  angle: 0,
			  opacity: 0.6
			});
			imgBulbBox.hasBorders =true;
			imgBulbBox.lockMovementX = imgBulbBox.lockMovementY = true;
// 		/////////////////Turn ON and OFF////////////////
		var turnOnOff = new fabric.Text('default', { left: 1750, top: 575, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
				  originY: 'center',});
				turnOnOff.hasControls = turnOnOff.hasBorders = false;
				turnOnOff.lockMovementX = turnOnOff.lockMovementY = false;
				turnOnOff.selectable = false
				turnOnOff.evented = false

				var turnOn = new fabric.Rect({
				  left: 1650,
				  top: 550,
				  fill: '#00ff99',
				  width: 200,
				  height: 50,
				  angle: 0
				});
				turnOn.lockMovementX = turnOn.lockMovementY = true;
				var control = 0;

				function updateTurnOn() {
				if (control > 0.5) {
				  turnOn.fill = 'red';
				  if (langSwitch > 0.5) {
						turnOnOff.text = "DE";
		  				}
		  			else 
		  			{
		  				turnOnOff.text="OFF";
		  			}
				  } 
				else {
				  turnOn.fill = '#00ff99';
				  if (langSwitch > 0.5) {
						turnOnOff.text = "SUR";
		  				}
		  			else 
		  			{
		  				turnOnOff.text="ON";
		  			}
				}
				}

				updateTurnOn();

				turnOn.on('selected', function() {
				  //console.log('selected a rectangle');
				  control = 1 - control;
				  updateTurnOn();
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});

// 		/////////////////////DIFFERENT SHOWERHEAD/Tub CONTROLS ////////////
				var imgLow = document.getElementById('low_tub');
				var imgLowInt = new fabric.Image(imgLow, {
				  left: 1650,
				  top: 350,
				  angle: 0,
				  opacity: 0.0
				});
				imgLowInt.scale(0.4);

				var imgLow2 = document.getElementById('low_press');
				var imgLow2Int = new fabric.Image(imgLow2, {
				  left: 1650,
				  top: 350,
				  angle: 0,
				  opacity: 0.9
				});
				imgLow2Int.scale(0.7);

				var imgLowBox = new fabric.Rect({
				  left: 1650,
				  top: 350,
				  width: 90,
				  height: 75,
				  fill: 'cyan', 
				  angle: 0,
				  opacity: 0.0
				});
				imgLowBox.lockMovementX = imgLowBox.lockMovementY = true;

				var imgHigh = document.getElementById('high_tub');
				var imgHighInt = new fabric.Image(imgHigh, {
				  left: 1750,
				  top: 350,
				  angle: 0,
				  opacity: 0.0
				});
				imgHighInt.scale(0.4);
				var imgHigh2 = document.getElementById('high_press');
				var imgHigh2Int = new fabric.Image(imgHigh2, {
				  left: 1750,
				  top: 350,
				  angle: 0,
				  opacity: 0.9
				});
				imgHigh2Int.scale(0.2);

				var imgHighBox = new fabric.Rect({
				  left: 1750,
				  top: 350,
				  width: 75,
				  height: 75,
				  fill: 'cyan', 
				  angle: 0,
				  opacity: 0.99
				});
				imgHighBox.lockMovementX = imgHighBox.lockMovementY = true;
				var pressureChooser = new fabric.Group([imgLowInt, imgLow2Int, imgHighInt, imgHigh2Int], {originX: 'center', originY: 'center'});

				//Low Pressure ////////////////
				var  press= 0;

				function updateLowPressure(){
				if (press> 0.5) {
				  imgLowBox.opacity= 0.6;
				  imgHighBox.opacity= 0.0;
				  } 
				else {
				  imgLowBox.opacity= 0.0;
				  imgHighBox.opacity= 0.0;
				}}

				updateLowPressure();

				imgLowBox.on('selected', function() {
				  //console.log('selected a rectangle');
				  press = 1 - press;
				  updateLowPressure();
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});
				////Tub///////

				var  press2 = 0;

				function updateHighPressure(){
				if (press2 > 0.5) {
				  imgHighBox.opacity= 0.6;
				  imgLowBox.opacity= 0.0;
				  } 
				else {
				  imgLowBox.opacity= 0.0;
				  imgHighBox.opacity= 0.0;
				}}

				updateHighPressure();

				imgHighBox.on('selected', function() {
				  //console.log('selected a rectangle');
				  press2 = 1 - press2;
				  updateHighPressure();
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});


// 		///////////////////LANGUAGES////////////////////////////////////
		//onLangFrench.opacity=0.7;
		// showTimeLeft.text = "07:32"
		 //  showTimeRight.text ="07:32"
		 //  if (control > 0.5) {
			// turnOnOff.text = "DE";
		 //  }
		 //  else 
		 //  {
		 //  	turnOnOff.text="SUR";
		 //  }


		var imglangSelect = document.getElementById('langChoose');
		var imgLangSelInt = new fabric.Image(imglangSelect, {
		  left: 1425,
		  top: 540,
		  angle: 0,
		  opacity: 0.9
		});
		imgLangSelInt.scale(0.95);

		var imglangSelect2 = document.getElementById('other_lang');
		var imgLangSelInt2 = new fabric.Image(imglangSelect2, {
		  left: 1425,
		  top: 540,
		  angle: 0,
		  opacity: 0.9
		});
		imgLangSelInt2.scale(0.8);
		imgLangSelInt2.lockMovementX = imgLangSelInt2.lockMovementY = false;

		var onLangEnglish = new fabric.Rect({
		left: 1430,
		top: 570,
		fill: 'cyan',
		width: 100,
		height: 20,
		angle: 0,
		opacity: 0.4
		});
		onLangEnglish.lockMovementX = onLangEnglish.lockMovementY = true;
		var onLangFrench = new fabric.Rect({
		left: 1430,
		top: 590,
		fill: 'cyan',
		width: 100,
		height: 20,
		angle: 0,
		opacity: 0.4
		});
		onLangFrench.lockMovementX = onLangFrench.lockMovementY = true;

		var langSwitch= 0;

		function updateLang() {
		if (langSwitch > 0.5) {
		  onLangFrench.opacity =0.4;
		  onLangEnglish.opacity =0.0;
		  } 
		else {
		  onLangFrench.opacity = 0.0;
		  onLangEnglish.opacity=0.4;
		}
		}

		updateLang();

		onLangFrench.on('selected', function() {
		  //console.log('selected a rectangle');
		  ///add other changes here 
		  langSwitch = 1 - langSwitch;
		  updateLang();
		  //Time and on and off 
		  showTimeLeft.text = "07:32"
		  showTimeRight.text ="07:32"
		  //background
		  turnBgd.fontSize=12;
		  turnBgd.text ="Choisir l'arrière-plan V";
		  turnBgd2.fontSize=12;
		  turnBgd2.text ="Choisir l'arrière-plan V";

		  //on off 
		  turnOnOff.text="SUR";
		 canvas.deactivateAll(); // deselect everything - so can click again 
		});

		onLangEnglish.on('selected', function() {
		  //console.log('selected a rectangle');
		  ///add other changes here 
		  langSwitch = 1 - langSwitch;
		  updateLang();
		  //Time and on and off 
		  showTimeLeft.text = "7:32 am"
		  showTimeRight.text ="7:32 am"
		  
		  turnBgd.fontSize=19;
		  turnBgd.text ="Choose Language V";
		  turnBgd2.fontSize=19;
		  turnBgd2.text ="Choose Language V";

		  turnOnOff.text="ON";

		 canvas.deactivateAll(); // deselect everything - so can click again 
		});
		 ///////////////////////SAMPLE//////////////////
		var tempText = new fabric.Text('default', { left: 900, top: 600, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
		  originY: 'center',});
		tempText.hasControls = tempText.hasBorders = false;
		tempText.lockMovementX = tempText.lockMovementY = false;
		tempText.selectable = false
		tempText.evented = false

		var waterControl = new fabric.Rect({
		  left: 900,
		  top: 600,
		  fill: 'grey',
		  width: 50,
		  height: 50,
		  angle: 0
		});

		var waterTemp = 0;

		function updateWaterTemp() {
		if (waterTemp > 0.5) {
		  waterControl.fill = 'red';
		  tempText.text = "hot";
		  } 
		else {
		  waterControl.fill = 'aqua';
		  tempText.text = "cold";
		}
		}

		updateWaterTemp();

		waterControl.on('selected', function() {
		  //console.log('selected a rectangle');
		  waterTemp = 1 - waterTemp;
		  updateWaterTemp();
		 canvas.deactivateAll(); // deselect everything - so can click again 
		});


// 		//////////////////////USER PREFERENCES///////////////////////////////
				var profileChooser = 0;
					//profile 1//////
				var pfl1 = document.getElementById('profiles');
				var profile1 = new fabric.Image(pfl1, {
				  left: 500,
				  top: 550,
				  angle: 0,
				  opacity: 0.9
				});
				profile1.scale(0.4);

				var p1txt = new fabric.Text('default', { left: 550, top: 700, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
				  originY: 'center',});
				p1txt.text ="Mike";
				p1txt.hasControls = p1txt.hasBorders = false;
				p1txt.lockMovementX = p1txt.lockMovementY = false;
				p1txt.selectable = false
				p1txt.evented = false

				var p1Sp = new fabric.Rect({
				  left: 500,
				  top: 550,
				  width: 100,
				  height: 200,
				  angle: 0,
				  opacity: 0.0
				});
				p1Sp.lockMovementX = p1Sp.lockMovementY = true;
				function updateProfile1() {
				if (profileChooser > 0.5) {
				  tempDisplay.text = "102'F/38.8'C";
				  imgLowBox.opacity = 0.7;
				  imgTubBox.opacity= 0.7;
				  imgMusicBox.opacity = 0.7;

				  }
				}
				updateProfile1();

				p1Sp.on('selected', function() {
				  //console.log('selected a rectangle');
				  profileChooser= 1 - profileChooser;
				  updateProfile1();
				 canvas.deactivateAll(); // deselect everything - so can click again 
				 profilesImg.visible=false;
				profilesTxt.visible=false;
				});
				//profile 2//////
				var pfl2 = document.getElementById('profiles');
				var profile2 = new fabric.Image(pfl1, {
				  left: 700,
				  top: 550,
				  angle: 0,
				  opacity: 0.9
				});
				profile2.scale(0.4);

				var p2txt = new fabric.Text('default', { left: 750, top: 700, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
				  originY: 'center',});
				p2txt.text ="Anne";
				p2txt.hasControls = p2txt.hasBorders = false;
				p2txt.lockMovementX = p2txt.lockMovementY = false;
				p2txt.selectable = false
				p2txt.evented = false

				var p2Sp = new fabric.Rect({
				  left: 700,
				  top: 550,
				  width: 100,
				  height: 200,
				  angle: 0,
				  opacity: 0.0
				});
				p2Sp.lockMovementX = p2Sp.lockMovementY = true;
				function updateProfile2() {
				if (profileChooser > 0.5) {
				  tempDisplay.text = "98'F/36'C";
				  imgHighBox.opacity = 0.7;
				  imgTubBox.opacity= 0.7;
				  imgMusicBox.opacity = 0.7;
				  imgMusicInt.opacity=0.7;

				  }
				}
				updateProfile2();

				p2Sp.on('selected', function() {
				  profileChooser= 1 - profileChooser;
				  updateProfile2();
				   profilesImg.visible=false;
				profilesTxt.visible=false;
				 canvas.deactivateAll(); // deselect everything - so can click again
				});

				//Profile 3 

				var profile3 = new fabric.Image(pfl1, {
				  left: 900,
				  top: 550,
				  angle: 0,
				  opacity: 0.9
				});
				profile3.scale(0.4);

				var p3txt = new fabric.Text('default', { left: 950, top: 700, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
				  originY: 'center',});
				p3txt.text ="Katie";
				p3txt.hasControls = p3txt.hasBorders = false;
				p3txt.lockMovementX = p3txt.lockMovementY = false;
				p3txt.selectable = false
				p3txt.evented = false

				var p3Sp = new fabric.Rect({
				  left: 900,
				  top: 550,
				  fill: 'grey',
				  width: 100,
				  height: 200,
				  angle: 0,
				  opacity: 0.0
				});
				p3Sp.lockMovementX = p3Sp.lockMovementY = true;
				function updateProfile3() {
				if (profileChooser > 0.5) {
				  tempDisplay.text = "102'F/38.8'C";
				  imgLowBox.opacity = 0.7;
				  imgTubBox.opacity= 0.7;
				  imgMediaBox.opacity=0.7;
				  imgTVInt.opacity=0.7;

				  }
				}
				updateProfile3();

				p3Sp.on('selected', function() {
				  profileChooser= 1 - profileChooser;
				  updateProfile3();
				   profilesImg.visible=false;
				profilesTxt.visible=false;
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});

				//Profile 4
					var profile4 = new fabric.Image(pfl1, {
					  left: 1100,
					  top: 550,
					  angle: 0,
					  opacity: 0.9
					});
					profile4.scale(0.4);

					var p4txt = new fabric.Text('default', { left: 1150, top: 700, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
					  originY: 'center',});
					p4txt.text ="Zach";
					p4txt.hasControls = p4txt.hasBorders = false;
					p4txt.lockMovementX = p4txt.lockMovementY = false;
					p4txt.selectable = false
					p4txt.evented = false

					var p4Sp = new fabric.Rect({
					  left: 1100,
					  top: 550,
					  fill: 'grey',
					  width: 100,
					  height: 200,
					  angle: 0,
					  opacity: 0.0
					});
					p4Sp.lockMovementX = p4Sp.lockMovementY = true;
					function updateProfile4() {
					if (profileChooser > 0.5) {
					  tempDisplay.text = "105'F/38.8'C";
					  imgHighBox.opacity = 0.7;
					  imgTubBox.opacity= 0.7;
					  onLangFrench.opacity=0.4;
					  onLangEnglish.opacity=0.0;
					  showTimeLeft.text = "07:32"
					  showTimeRight.text ="07:32"
					  turnOnOff.text="SUR";
					  }
					}
					updateProfile4();

					p4Sp.on('selected', function() {
					  profileChooser= 1 - profileChooser;
					  updateProfile4();
					   profilesImg.visible=false;
				profilesTxt.visible=false;
					 canvas.deactivateAll(); // deselect everything - so can click again 
					});
				//Profile 5
					var profile5 = new fabric.Image(pfl1, {
				  left: 850,
				  top: 350,
				  angle: 0,
				  opacity: 0.9
				});
				profile5.scale(0.4);

				var p5txt = new fabric.Text('default', { left: 900, top: 475, fontFamily: 'Arial', fontSize: 40, fontWeight: 'italic', originX: 'center',
				  originY: 'center',});
				p5txt.text ="Guest";
				p5txt.hasControls = p5txt.hasBorders = false;
				p5txt.lockMovementX = p5txt.lockMovementY = false;
				p5txt.selectable = false
				p5txt.evented = false

				var p5Sp = new fabric.Rect({
				  left: 850,
				  top: 350,
				  fill: 'grey',
				  width: 100,
				  height: 200,
				  angle: 0,
				  opacity: 0.0
				});
				p5Sp.lockMovementX = p5Sp.lockMovementY = true;
				function updateProfile5() {
				if (profileChooser > 0.5) {
				  	p5Sp.opacity = 0.0;
				  }
				}
				updateProfile5();
				p5Sp.on('selected', function() {
				  profileChooser= 1 - profileChooser;
				  updateProfile5();
				   profilesImg.visible=false;
					profilesTxt.visible=false;
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});

				var profilesImg = new fabric.Group([profile1, profile2, profile3, profile4, profile5], {originX: 'center', originY: 'center'});
				var profilesTxt = new fabric.Group([p1txt, p2txt, p3txt, p4txt, p5txt], {originX: 'center', originY: 'center'});
		//var profilesShape = new fabric.Group([p1Sp, p2Sp, p3Sp, p4Sp, p5Sp], {originX: 'center', originY: 'center'});
// 		/////////////////////////////SHOWER OR TUB ////////////////
				// imgLowBox.opacity= 0.6;
				//  imgHighBox.opacity= 0.0;
				var imgShower = document.getElementById('showerChoose');
				var imgShowerInt = new fabric.Image(imgShower, {
				  left: 1650,
				  top: 250,
				  angle: 0,
				  opacity: 0.9
				});
				imgShowerInt.scale(0.3);

				var imgShowerBox = new fabric.Rect({
				  left: 1650,
				  top: 250,
				  width: 90,
				  height: 75,
				  fill: 'cyan', 
				  angle: 0,
				  opacity: 0.0
				});
				imgShowerBox.lockMovementX = imgShowerBox.lockMovementY = true;

				var imgTub = document.getElementById('tubChoose');
				var imgTubInt = new fabric.Image(imgTub, {
				  left: 1750,
				  top: 250,
				  angle: 0,
				  opacity: 0.9
				});
				imgTubInt.scale(0.3);

				var imgTubBox = new fabric.Rect({
				  left: 1750,
				  top: 250,
				  width: 105,
				  height: 50,
				  fill: 'cyan', 
				  angle: 0,
				  opacity: 0.0
				});
				imgTubBox.lockMovementX = imgTubBox.lockMovementY = true;
				
				var modeChooser = new fabric.Group([imgShowerInt, imgTubInt], {originX: 'center', originY: 'center'});

				//Shower ////////////////
				var  shower= 0;

				function updateShower(){
				if (shower > 0.5) {
				  imgShowerBox.opacity= 0.6;
				  imgTubBox.opacity= 0.0;
				  } 
				else {
				  imgShowerBox.opacity= 0.0;
				  imgTubBox.opacity= 0.0;
				}}

				updateShower();

		imgShowerBox.on('selected', function() {
		  //console.log('selected a rectangle');
		  shower = 1 - shower;
		  updateShower();
		 canvas.deactivateAll(); // deselect everything - so can click again imgLow2Int.opacity=0.0;
		 //change shower/tub pressure images 
		  imgLow2Int.opacity=0.9;
		  imgHigh2Int.opacity=0.9;
		  imgLowInt.opacity=0.0;
		  imgHighInt.opacity=0.0;

		  //background 
		  turnBgd.visible=true;
		  onBgd.visible=true;
		  turnBgd2.visible =false;
		  onBgd2.visible=false;

		  //timer
		  Timer.left = 600;
		  Timer.top = 450;

		  //tv
		   imgMediaBox2.visible= false;
		   imgMediaInt2.visible=false;
		   imgMediaBox.visible =true;
		   imgMediaInt.visible =true;

		   //music

		  imgMusicBox2.visible =false;
		  imgMIconInt2.visible =false;
		  imgMusicBox.visible =true;
		  imgMusicBox2.visible=true;

		  //temperature
		  tempDisplay2.visible=false;
		  imgUPInt2.visible=false;
		  imgUpBox2.visible =false;
		  imgDownInt2.visible=false;


		 });

		////Tub///////

		var  tub = 0;

		function updateTub(){
		if (tub > 0.5) {
		  imgTubBox.opacity= 0.6;
		  imgShowerBox.opacity= 0.0;
		  } 
		else {
		  imgShowerBox.opacity= 0.0;
		  imgTubBox.opacity= 0.0;
		}}

		updateTub();

		imgTubBox.on('selected', function() {
		  //console.log('selected a rectangle');
		  tub = 1 - tub;
		  updateTub();
		 canvas.deactivateAll(); // deselect everything - so can click again 
		 //Shower/Tub pressure images
		 imgLow2Int.opacity=0.0;
		  imgHigh2Int.opacity=0.0;
		  imgLowInt.opacity=0.9;
		  imgHighInt.opacity=0.9;

		  //Background 
		  turnBgd.visible=false;
		  onBgd.visible=false;
		  turnBgd2.visible =true;
		  onBgd2.visible=true;

		  //timer
		  Timer.left = 1700;
		  Timer.top = 1950;

		  //temperature 
		  tempDisplay2.visible = true;
		  imgUPInt2.opacity =0.9;
		  imgUpBox2.visible = true;
		  imgDownInt2.opacity=0.9;

		  //tv 
		   imgMediaBox2.visible= true;
		   imgMediaInt2.opacity=0.9;
		   imgMediaBox.visible =true;
		   imgMediaInt.visible =true;

		  // imgMediaBox2.visible= true;
		  // imgMediaInt2.visible=true;
		  imgMusicBox2.visible =true;
		  imgMIconInt2.opacity = 0.9;
		  //imgMusicBox.visible =false;
		  // imgMusicBox.visible=false;
		  // imgMediaBox.visible =false;

		});
// 		//////////temperature updates ////////////
				function updateTemp() {
				if (temperature > 0.5) {
				  tempDisplay.backgroundColor="#ff1a1a";
				  tempDisplay.text = "120'F/48'C";
				  turnOn.text="ON";
				  turnOn.fill="#00ff99";
				  } 
				else {
				  tempDisplay.backgroundColor="white";
				  tempDisplay.text = "100'F/48'C";
				}
				}

				updateTemp();
				imgUpBox.on('selected', function() {
				  //console.log('selected a rectangle');
				  temperature = 1 - temperature;
				  updateTemp();
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});

				function updateTemp2() {
				if (temperature > 0.5) {
				  tempDisplay2.backgroundColor="#ff1a1a";
				  tempDisplay2.text = "120'F/48'C";
				  turnOn2.text="ON";
				  turnOn2.fill="#00ff99";
				  } 
				else {
				  tempDisplay2.backgroundColor="white";
				  tempDisplay2.text = "100'F/48'C";
				}
				}

				updateTemp2();
				imgUpBox2.on('selected', function() {
				  //console.log('selected a rectangle');
				  temperature = 1 - temperature;
				  updateTemp2();
				 canvas.deactivateAll(); // deselect everything - so can click again 
				});
// 		////////TV and Music Updates///////////// 
			var  media = 0;

	function updateMedia() {
	if (media > 0.5) {
	  imgTVInt.opacity = 1.0;
	  imgMediaBox.opacity= 0.9;
	  imgMusicInt.opacity=0.0;
	  imgMusicBox.opacity=0.0;
	  } 
	else {
	  imgTVInt.opacity= 0.0;
	  imgMediaBox.opacity= 0.0;
	  imgMusicInt.opacity=0.0;
	  imgMusicBox.opacity=0.0;
	}}

	updateMedia();
	imgMediaBox.on('selected', function() {
	  //console.log('selected a rectangle');
	  media = 1 - media;
	  updateMedia();
	 canvas.deactivateAll(); // deselect everything - so can click again 
	});
	function updateMedia2() {
	if (media > 0.5) {
	  imgTVInt2.opacity = 1.0;
	  imgMediaBox2.opacity= 0.9;
	  imgMusicInt2.opacity=0.0;
	  imgMusicBox2.opacity=0.0;
	  } 
	else {
	  imgTVInt2.opacity= 0.0;
	  imgMediaBox2.opacity= 0.0;
	  imgMusicInt2.opacity=0.0;
	  imgMusicBox2.opacity=0.0;
	}}

	updateMedia2();
	imgMediaBox2.on('selected', function() {
	  //console.log('selected a rectangle');
	  media = 1 - media;
	  updateMedia2();
	 canvas.deactivateAll(); // deselect everything - so can click again 
	});
		/////////////MUSIC INTERACTIVITY//////
		
		var  music = 0;

		function updateMusic(){
		if (music > 0.5) {
		  imgMusicInt.opacity = 1.0;
		  imgMusicBox.opacity= 0.9;
		  imgTVInt.opacity= 0.0;
		  imgMediaBox.opacity= 0.0;
		  } 
		else {
		  imgMusicInt.opacity=0.0;
		  imgMusicBox.opacity=0.0;
		  imgTVInt.opacity= 0.0;
		  imgMediaBox.opacity= 0.0;
		}}

		updateMusic();

		imgMusicBox.on('selected', function() {
		  //console.log('selected a rectangle');
		  music = 1 - music;
		  updateMusic();
		 canvas.deactivateAll(); // deselect everything - so can click again 
		});	

		function updateMusic2(){
		if (music > 0.5) {
		  imgMusicInt2.opacity = 1.0;
		  imgMusicBox2.opacity= 0.9;
		  imgTVInt2.opacity= 0.0;
		  imgMediaBox2.opacity= 0.0;
		  } 
		else {
		  imgMusicInt2.opacity=0.0;
		  imgMusicBox2.opacity=0.0;
		  imgTVInt2.opacity= 0.0;
		  imgMediaBox2.opacity= 0.0;
		}}

		updateMusic2();

		imgMusicBox2.on('selected', function() {
		  //console.log('selected a rectangle');
		  music = 1 - music;
		  updateMusic2();
		 canvas.deactivateAll(); // deselect everything - so can click again 
		});	

// 		/////Background Image Updates/////////////
		var backgrd = 0;

		function updateBgd() {
			if (backgrd > 0.5) {
					  if(langSwitch > 0.5) //it is french 
		  				{
		  					turnBgd.fontSize=10;
		  					turnBgd.text ="Cascade";
		  				}
		  				else
		  				{
		  					turnBgd.fontSize =19;
		  					turnBgd.text ="Waterfall";
		  				}
					  	imgbackgrdInt.opacity = 0.7;
					  	onBgd.opacity= 0.6;
					  } 
					else 
					{
						if(langSwitch > 0.5) //it is french 
		  				{
		  					turnBgd.fontSize=10;
		  					turnBgd.text ="Choisir l'arrière-plan V";

		  				}
		  				else
		  				{
		  					turnBgd.fontSize =19;
		  						turnBgd.text = "Choose Background  V";

		  				}
						
					  	imgbackgrdInt.opacity = 0.0;
					   	onBgd.opacity=0.4;

					}
				} 
					updateBgd();

					onBgd.on('selected', function() {
					  //console.log('selected a rectangle');
					  backgrd = 1 - backgrd;
					  updateBgd();
					 canvas.deactivateAll(); // deselect everything - so can click again 
					});

			function updateBgd2() {
			if (backgrd > 0.5) {
					  if(langSwitch > 0.5) //it is french 
		  				{
		  					turnBgd2.fontSize=12;
		  					turnBgd2.text ="Cascade";
		  				}
		  				else
		  				{
		  					turnBgd2.fontSize =19;
		  					turnBgd2.text ="Waterfall";
		  				}
					  imgbackgrdInt.opacity = 0.7;
					  onBgd2.opacity= 0.6;

					  } 
					else {

					  	if(langSwitch > 0.5) //it is french 
		  				{
		  					turnBgd2.fontSize=10;
		  					turnBgd2.text ="Choisir l'arrière-plan V";

		  				}
		  				else
		  				{
		  					turnBgd2.fontSize =19;
		  						turnBgd2.text = "Choose Background  V";

		  				}
					   imgbackgrdInt.opacity = 0.0;
					   onBgd2.opacity=0.4;

					}
					}

					updateBgd2();

					onBgd2.on('selected', function() {
					  //console.log('selected a rectangle');
					  backgrd = 1 - backgrd;
					  updateBgd2();
					 canvas.deactivateAll(); // deselect everything - so can click again 
					});
// 		////////////////LIGHT UPDATES//////
		var brightness =0;

			function updateBulb() {
			if (brightness > 0.5) {
			  imgBulbBox.fill="yellow";
			  imgBulbBox.opacity= 0.5;
			  } 
			else {
			  imgBulbBox.fill="white";
			  imgBulbBox.opacity=0.0;
			}
			}

			updateBulb();
			imgBulbBox.on('selected', function() {
			  //console.log('selected a rectangle');
			  brightness = 1 - brightness;
			  updateBulb();
			 canvas.deactivateAll(); // deselect everything - so can click again 
			});

		canvas.add(backWall);
		canvas.add(sideWall);
		canvas.add(frontWall);
		canvas.add(showerHead2);
		canvas.add(showerHead);
		canvas.add(bathSpout);

		//Background Image 1
		canvas.add(imgbackgrdInt);

	
		//Music
		canvas.add(imgMusicInt);
		canvas.add(imgMusicInt2);
		canvas.add(imgMIconInt);
		canvas.add(imgMIconInt2);
		canvas.add(imgMusicBox);
		canvas.add(imgMusicBox2);

		//TV
		canvas.add(imgMediaInt);
		canvas.add(imgMediaInt2);
		canvas.add(imgTVInt);
		canvas.add(imgMediaBox);
		canvas.add(imgMediaBox2);
		

		//profiles
		canvas.add(profilesImg);
		canvas.add(profilesTxt);
			//canvas.add(profilesShape);
		canvas.add(p1Sp);
		canvas.add(p2Sp);
		canvas.add(p3Sp);
		canvas.add(p4Sp);
		canvas.add(p5Sp);

	
		// //canvas.add(waterControl);
		// //canvas.add(tempText);


		//Time and Weather 
		canvas.add(showTimeRight);
		canvas.add(imgInstance);
		canvas.add(showTimeLeft);
		canvas.add(imgTimerInt);


		//Light
		canvas.add(imgBulbInt);
		canvas.add(imgBulbBox);

		//Low or High Shower Pressure 
		canvas.add(pressureChooser);
		canvas.add(imgLowBox);
		canvas.add(imgHighBox);

		//Turn on or off
		canvas.add(turnOn);
		canvas.add(turnOnOff);

		//Tub or Shower
		canvas.add(modeChooser);
		canvas.add(imgShowerBox);
		canvas.add(imgTubBox);
		
		//Temperature Control 
		canvas.add(imgUPInt);
		canvas.add(imgUpBox);
		canvas.add(tempDisplay);
		canvas.add(imgDownInt);
		canvas.add(imgUPInt2);
		canvas.add(imgUpBox2);
		canvas.add(tempDisplay2);
		canvas.add(imgDownInt2);

		//Timer
		canvas.add(Timer);
		canvas.add(seperator2);
		canvas.add(seperator);

		//Background Image 2
		canvas.add(onBgd);
		canvas.add(turnBgd);
		canvas.add(onBgd2);
		canvas.add(turnBgd2);

		//Language Change
		//canvas.add(imgLangIconInt);
		canvas.add(imgLangSelInt2);
		canvas.add(imgLangSelInt);
		canvas.add(onLangEnglish);
		canvas.add(onLangFrench);

		//TV Part 2
		canvas.add(imgTVInt2);
		
		///tub full
		canvas.add(imgFullTub);
		canvas.add(TubFullSelect);

		
		
		

		// code adapted from http://jsfiddle.net/tornado1979/39up3jcm/
		function zoomAll(SCALE_FACTOR) {

	      var objects = canvas.getObjects();
	      for (var i in objects) {
	          var scaleX = objects[i].scaleX;
	          var scaleY = objects[i].scaleY;
	          var left = objects[i].left;
	          var top = objects[i].top;

	          var tempScaleX = scaleX * SCALE_FACTOR;
	          var tempScaleY = scaleY * SCALE_FACTOR;
	          var tempLeft = left * SCALE_FACTOR;
	          var tempTop = top * SCALE_FACTOR;

	          objects[i].scaleX = tempScaleX;
	          objects[i].scaleY = tempScaleY;
	          objects[i].left = tempLeft;
	          objects[i].top = tempTop;

	          objects[i].setCoords();
	      }
	  
	     
	      canvas.renderAll();
	  		}	


		zoomAll(canvas.height / localHeight);

		})();
