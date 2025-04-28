import {
    DirectionalLight,
    DirectionalLightHelper
  } from "three";
 
   function createLights(color : any) {
    const light = new DirectionalLight(color, 4) as any;
    const lightHelper = new DirectionalLightHelper(light, 0);
    light.position.set(0, 0, 5);
     light.tick = (delta: any) => {
    
    };
     return { light, lightHelper };
  }
   export { createLights };