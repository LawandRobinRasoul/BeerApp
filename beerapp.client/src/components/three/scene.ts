import { Color, Scene } from 'three';
 
function createScene(color:any) {
 const scene = new Scene();
 
 scene.background = new Color(color);
 
 return scene;
}
 
export { createScene };