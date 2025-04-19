function init3D(modelUrl) {
    const scene = new THREE.Scene();
    const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    const renderer = new THREE.WebGLRenderer();
    renderer.setSize(window.innerWidth, 400);
    document.getElementById('3d-container').appendChild(renderer.domElement);

    // Tải mô hình 3D
    const loader = new THREE.GLTFLoader();
    loader.load(modelUrl, (gltf) => {
        scene.add(gltf.scene);
    });

    if (navigator.xr) {
        renderer.xr.enabled = true;
        document.body.appendChild(ARButton.createButton(renderer));
    }

    camera.position.z = 5;
    const animate = function () {
        requestAnimationFrame(animate);
        renderer.render(scene, camera);
    };
    animate();
}