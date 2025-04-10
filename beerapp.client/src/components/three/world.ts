import { createCamera } from "./camera.ts";
import { createLights } from "./lights.ts";
import { createScene } from "./scene.ts";
import { createRenderer } from "./renderer.ts";
import { Loop } from "./loop.ts";
import { Resizer } from "./resizer.ts";
import { Clock, Camera, Scene, WebGLRenderer } from 'three';

// These variables are module-scoped: we cannot access them
// from outside the module.
let camera: Camera;
let renderer: WebGLRenderer;
let scene: Scene;
let loop: Loop;
 
class World {
   constructor(container: Element) {
     // Instances of camera, scene, and renderer
     camera = createCamera();
     scene = createScene("green");
     renderer = createRenderer();
      // Initialize Loop
     loop = new Loop(camera, scene, renderer);
      container.append(renderer.domElement);
      // Light Instance, with optional light helper
     const { light } = createLights("white");
      loop.updatables.push(light);
      scene.add(light);
 
     const resizer = new Resizer(container, camera, renderer);
      resizer.onResize = () => {
      this.render();
     };
 
    }
    render() {
     // Draw a single frame
     renderer.render(scene, camera);
   }
    // Animation handlers
   start() {
     loop.start();
   }
    stop() {
     loop.stop();
   }
 }
  export { World };