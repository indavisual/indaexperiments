/*
 * Canvas2Image.saveAsXXXX = function(oCanvasElement, bReturnImgElement, iWidth, iHeight) { ... }
 */
 
var oCanvas = document.getElementById("thecanvas");
 
Canvas2Image.saveAsPNG(oCanvas);  // will prompt the user to save the image as PNG.
 
Canvas2Image.saveAsJPEG(oCanvas); // will prompt the user to save the image as JPEG.
                                  // Only supported by Firefox.
 
Canvas2Image.saveAsBMP(oCanvas);  // will prompt the user to save the image as BMP.
 
 
// returns an <img /> element containing the converted PNG image
var oImgPNG = Canvas2Image.saveAsPNG(oCanvas, true);  
 
// returns an <img /> element containing the converted JPEG image (Only supported by Firefox)
var oImgJPEG = Canvas2Image.saveAsJPEG(oCanvas, true);
                                                       
// returns an <img /> element containing the converted BMP image
var oImgBMP = Canvas2Image.saveAsBMP(oCanvas, true);
 
 
// all the functions also takes width and height arguments.
// These can be used to scale the resulting image:
 
// saves a PNG image scaled to 100x100
Canvas2Image.saveAsPNG(oCanvas, false, 100, 100);