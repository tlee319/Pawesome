# Pawesome Dog Emotion Reader
The purpose of this application is to provide the user with a dog's emotions given. Given a list of selected attributes, the application will return (within a certain degree of confidence) the dogs emotional state.

## Release Notes
__Version 1.0__

__Software Features__

* All software is up to date. The application was built in Unity 5.5.2

__Bug Fixes__

* Fixed inaccurate images, enlarged exit button for image preview.

__Known Bugs__

* Poor portrait view design for UI (this may depend on the device).
* Start Over option on Result Screen is grey in portrait view

## Prerequisites
__Software needed__

* Unity (version 5.5.2 or above)
* Xcode (for iOS building/application)

Unity Download

* [Unity](https://unity3d.com/) - Download/Account creation site for Unity

Xcode Download

* [Xcode](https://developer.apple.com/xcode/downloads/) - Download for Xcode

## Builds
The __/Builds__ subdirectory is not in the repository due to its large size. The user may follow the following link to download pre-built versions of the application
* [Pre-Built Applications](https://drive.google.com/file/d/0B4NfAiWAGHcrRHl4MHpFQ2ZVWGs/view?usp=sharing)

## Install Guide
The customer needs to have Unity installed to view the application.

We have already provided built versions of both the Unity and iOS versions, which you can find in the __Builds__ section above.

If the customer wishes to build the application themselves for either application, they can follow the instructions below.

### Unity Download Instructions 

1. After downloading Unity, the customer should then pull the files from the repository.
2. Open up the project in Unity by clicking "Open" on the top right of the Unity startup screen.
3. Select the folder containing the repository.
5. After the assets are imported, the application is loaded in Unity. Load the scene from
```
Assets/Scenes/Dog Emotion
```
6. Create a subfolder called "__Builds__" in the parent folder.
7. The customer may then build the application in Unity with
```
File > Build Settings > Select Open Scenes > Select PC/Mac > Build and Run
```
8. Save the build in the newly created __Builds__ folder.

### iOS Build

In order to give our customer full usage of the iOS application, please do the following...

* Follow steps 1-6 in the Unity Download section and then do the following:

1. After loading the scene, navigate to the Build Settings screen.
```
File > Build Settings
```
2. Make sure that Scene/Dog Emotion is located in "Scenes to Build"
3. Select iOS in the __Platform__ section.
4. Select the __Switch Platform__ option. 
5. After Unity has switched platforms, select __Build__.
6. Create a new folder called __"iOS"__ in your __/Builds__ subfolder.

The application is now built in the iOS folder located in the __\Builds__ subdirectory.

### Running with XCode
1. Double click the .xcodeproj file to open the project with Xcode.
  * This will open up Xcode with the application. 
2. Once Xcode project is built, locate the __Project Navigator__ icon indicated by an image of a folder.
3. Double click on the __"Unity-iPhone"__ icon (very first icon).
4. The user will then be brought to a separate screen titled _Unity-iPhone.xcodeproj_ in the __General__ section.
5. Locate the __Identity__ section at the top.
  * Change the __"Bundle Identifier"__ tag to:
    ```
    com.Pawesome
    ```
6. Locate the __Signing__ section
  * The user must select __"Team"__ and input their Xcode Developer ID.
7. Connect the desired iPhone to run the application on and click the "Play" button located in the top left of Xcode
  * If there is a "Build Fail", please refer to the __Troubleshooting__ section.

Once the iOS version is built, the customer can input their own Developer License in Xcode.
The customer will then have full license over the application. 

## Troubleshooting
__In case of a "Build Fail" during the iOS build process...__

Refer to [this guide](https://unity3d.com/learn/tutorials/topics/mobile-touch/building-your-unity-game-ios-device-testing) in order to fix any build errors.
* Begin at the "Adding your Apple ID to Xcode" section.
* If the Build Errors are due to __signing__, refer to steps 2-6 of the _Running with Xcode_ section
* If there are any other issues, please contact feel free to contact [us](mailto:jarrodblanton13@gmail.com).
