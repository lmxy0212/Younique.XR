<div align="center">
  <a href="https://github.com/lmxy0212/VRGaussianSplat.git">
    <img src="Younique.png" alt="Logo" width="80" height="80">
  </a>
<h3 align="center">Younique: The Immersive Ikebana Experience</h3>
</div>



<div align="center">
  <img src="VR-IKEBANA.JPG" width="400" height="600">
</div>

## About The Project

We're currently developing our MVP, an immersive virtual experience centered around the art of ikebana. We believe that this XR project offers complex interactions that traditional media can't easily replicate. To bring this vision to life, we've digitized a physical space using 3D scanning technology, turning it into a virtual environment where users can interact with 3D scanned flowers. Participants use a VR headset to arrange these flowers, crafting their own ikebana creations. Afterwards, they can explore and interact with their floral designs in augmented reality, making the experience even more engaging.



<!-- CONTRIBUTORS -->

## Contributors 

**Mackenzie Li**, XR Generalist, Harvard 25'

**Grace Mai**, Technical Artist, Harvard 25'

**Vera Wu**, UX Prototyper, Harvard 25'



<!-- TABLE OF CONTENTS -->
<p><details>
  <summary><h3>Table of Contents</h3></summary>
  <ol>
    <li><a href="#build-with ">Build With</a></li>
    <li><a href="#Documentations ">Documentations</a>
      <ul>
        <li><a href="#folder-structure">Folder Structure</a></li>
        <li><a href="#key-features">Key Features</a></li>
        <li><a href="#Scripts">Scripts</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details></p>
<br>

## Build with

### **Unity 2022.3.21f1** | **StandardRP** | **GraphicAPI-DX12**

OpenXR + XR Interaction Toolkit 3.0.1



Assets and external resources used in this projects:

- [GaussianSplattingVRViewerUnity](https://github.com/clarte53/GaussianSplattingVRViewerUnity) by CLARTE-LAB

- Alembic

- Fbx Exporter for Unity

- Autodesk FBX SDK for Unity

- Tested on Quest2 and Quest Pro

<p align="right">(<a href="#readme-top">back to top</a>)</p>



## Documentations

Updated on Apr14/2024

### Folder Structure

* Current active Scene: Assets/Scenes/IkebanaWIP

* All Scripts can be fond in Assets/Scripts

* All prefabs in the scene are located in Assets/Flowers

* Gaussian Splat assets can be created from Tools/Gaussian Splat/Create GaussianSplatAsset



### Key Features

**Gaussian Splat Assets:**

* Convert Gaussian splat to the renderable assets -- using [GaussianSplattingVRViewerUnity](https://github.com/clarte53/GaussianSplattingVRViewerUnity) by CLARTE-LAB

**Plates:**

- Plates featuring kanzan can be picked up.
- Once pick up a plate for the first time, player will see a description of kanzan.

**Knife:**

- Player can pick up the knife.
- Use the knife to trim the branches and leaves of flowers.

**Flowers and Leaves:**

- These can also be picked up.
- Player can use the knife to cut them.
- The main branch can be snapped to the kanzan.

**Book/Manual:**

- Player can flip through the book in both directions, depending on which side is touched.

**Menu:**

* clickable hologram
* Save the selected ikebana to FBX when camera button is clicked



### **Scripts**

**Snapping**: snap to pos, preserving the rotation and toggle physics when snap/unsnapped

- AutoSnap.cs:  Attach to snap destination
- SnapObj.cs: Attach to the snaped object

**Hand Interactions**: interactions using hands (other than grab)

- FlipBook.cs: Control flip book forward and backward animation 
- HandMenuInteracter.cs: Control menu buttons
- MenuController.cs: Control menu item transform

**Object Manipulation:**

- Cutcutcut.cs: Unparent the gameobject that is nearest to the cut point.

**Tooltip**: 

- StayVertical.cs: Make info panel stay vertical and facing the camera
- TwoPoiintLine.cs: Render line between two point (run in editor)

**Save FBX file:**

* CustomFbxExporter.cs: Save the selected gameobject to FBX to the desired location (modified from Fbx Exporter for Unity)

**Overwrite XRI**:

* CheckOnGrab.cs: Enable tooltip on the first grab

* CustomSocketInteractor.cs: Flag the gameobject being snapped by socket interaction
* SetDynamicAttachPos.cs: Set dynamic attach pos when XRGrabIneractable is attached to the gameobject in runtime
* XRInstantiateGrabbableObject.cs:  Instantiate XRGrabInteractable to gameobject

**Audio**:

- PlayAudio.cs: Play audio on collision



<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->

## Getting Started

### Prerequisites

* Unity 2022.3.21f1

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/lmxy0212/VRGaussianSplat.git
   ```

2. Open with Unity Hub
   ```sh
   project path: /VRGaussianSplat/VRGaussianSplat-Younique
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->


<!-- LICENSE -->

## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->

## Acknowledgments

This project is developed in Harvard MDE Studio II in Spring 2024, adviced by Jonathan Grinham, Karen Reuther, Kipp Bradford, Mark Coughlin.

<p align="right">(<a href="#readme-top">back to top</a>)</p>
