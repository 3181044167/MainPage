
const loadingCss = () => {
	let style = document.createElement(`style`)
	style.type = `text/css`
	style.innerHTML = `
		 .dev {
		  width: 100%;
		  text-align: center;
		  background: #e7cd3800;
		  display: flex;
		  align-items: center;
		  justify-content: center;
		  position: fixed;
		}
		 .loadUI {
			  position: fixed;
			  width: 100%;
			  height: 100%;
			  align-items: center;
			  justify-content: center;
			  top:-10%;
			}
		.loadingDiv {
			background-color: ##404456;
			width: 100vw;
			height: 100vh;
			margin: 0;
			padding: 0;
		}
		.bg {
			position: absolute;
			width: 25vw;
			height: 25vw;
			left: calc(50% - 12.5vw);
			top: calc(50% - 12.5vw);
			color:black;
		}
		.line {
			position: absolute;
			width: 35vw;
			height: 1vw;
			top: 100%;
			background-color: black;
			transform: rotate(-45deg);
			transform-origin: 0 0;
		}
		.box {
			position: absolute;
			width: 5vw;
			height: 5vw;
			border-radius: 15%;
			left: 0;
			bottom: 0;
			border: 1vw solid black;
			animation: boxAni 2.5s cubic-bezier(.79, 0, .47, .97) infinite;
		}
		@keyframes boxAni {
			0% {transform: translate(0, -5vw) rotate(-45deg);}
			5% {transform: translate(0, -5vw) rotate(-50deg);}
			20% {transform: translate(5vw, -10vw) rotate(45deg);}
			25% {transform: translate(5vw, -10vw) rotate(40deg);}
			50% {transform: translate(10vw, -15vw) rotate(135deg);}
			50% {transform: translate(10vw, -15vw) rotate(130deg);}
			75% {transform: translate(15vw, -20vw) rotate(225deg);}
			100% {transform: translate(0, -5vw) rotate(-225deg);}
		}
		.textDiv {
			position: absolute;
			width: 50vw;
			height: 10vh;
			left: calc(50% - 25vw);
			top: 100%;
			color: black;
			text-align: center;
			line-height: 10vh;
			font-size: 5vh;
			font-weight: bold;
		}
		.textDiv span {
			position: relative;
			animation: textAni 1.75s linear infinite;
		}
		.textDiv span:nth-child(n+1) {
			animation-delay: 0.25s;
		}
		.textDiv span:nth-child(n+2) {
			animation-delay: 0.5s;
		}
		.textDiv span:nth-child(n+3) {
			animation-delay: 0.75s;
		}
		.textDiv span:nth-child(n+4) {
			animation-delay: 1s;
		}
		.textDiv span:nth-child(n+5) {
			animation-delay: 1.25s;
		}
		.textDiv span:nth-child(n+6) {
			animation-delay: 1.5s;
		}
		.textDiv span:nth-child(n+7) {
			animation-delay: 1.75s;
		}
		.textDiv span:nth-child(n+8) {
			animation-delay: 2s;
		}
		.textDiv span:nth-child(n+9) {
			animation-delay: 2.25s;
		}
		.textDiv span:nth-child(n+10) {
			animation-delay: 2.5s;
		}
		@keyframes textAni {
			0% {top: 0}
			50% {top: 2.5vh}
			100% {top: 0}
		}`
	document.getElementsByTagName(`head`)[0].appendChild(style)
}

const loadingHtml = () => {
	let loadingDiv = document.createElement(`div`)
	loadingDiv.id = `loadingDiv`
	loadingDiv.className = `loadingDiv`
	let bg = document.createElement(`div`)
	bg.className = `bg`
	let line = document.createElement(`div`)
	line.className = `line`
	let box = document.createElement(`div`)
	box.className = `box`
	let textDiv = document.createElement(`div`)
	textDiv.className = `textDiv`
	let str = `Loading...`.split(``)
	for (s of str) {
		let span = document.createElement(`span`)
		span.innerText = `${s} `
		textDiv.appendChild(span)
	}
	bg.appendChild(line)
	bg.appendChild(box)
	bg.appendChild(textDiv)
	loadingDiv.appendChild(bg)
	document.getElementById("loadUI").appendChild(loadingDiv)
	
	
	
}

loadingCss()
loadingHtml()