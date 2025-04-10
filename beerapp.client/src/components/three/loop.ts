import { Clock, Camera, Scene, WebGLRenderer } from 'three';

const clock = new Clock();

interface Updatable {
  tick: (delta: number) => void;
}

class Loop {
  private camera: Camera;
  private scene: Scene;
  private renderer: WebGLRenderer;
  public updatables: Updatable[];

  constructor(camera: Camera, scene: Scene, renderer: WebGLRenderer) {
    this.camera = camera;
    this.scene = scene;
    this.renderer = renderer;
    this.updatables = [];
  }

  start() {
    this.renderer.setAnimationLoop(() => {
      this.tick();
      this.renderer.render(this.scene, this.camera);
    });
  }

  stop() {
    this.renderer.setAnimationLoop(null);
  }

  tick() {
    const delta = clock.getDelta();
    for (const object of this.updatables) {
      object.tick(delta);
    }
  }
}

export { Loop };
