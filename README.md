# Speedometer in Unity
Based on this repo: https://github.com/eelstork/Unity-Speedometer

Displays Altutude, location (longitude & latutude), location accuracy, and speed (kmh as all civilised people use) in real time (updates 1-2 times a second).
The speed measurement accuracy is slightly better than the one Google Maps use, roughly ± 1 kmh from the actual speed. Location accuracy is on average ± 6 meters (in Sweden on flagship an Android phone).

## Use Unity 2022 on Android 12 phones!!! 

Unity 2021 LTS won't work because of an Android 12 location service change in February which messed up Unity's input.location service. Unity haven't botherd fixing it in Unity 2021, so make sure to use Unity 2022 instead where they fixed the bug.

## To get going
- Clone or download the project and open it in Unity
- Open "Build Settings" and change the platform to Android.
- Open "Player Settings" and go to "Editor" and change "Device" to "Any Android Device" under "Unity Remote" heading so you can run the app directly on your Android phone via an USB cable in playmode without building. (Make sure you enable "Developer Mode" on your Android device and that you've downloaded the "Unity Remote 5" app)
- Go back to "Build Settings" and make sure your phone is plugged in and it is selected under the "Run Device" option, then hit "Build and Run" and enjoy the application. (Make sure you enable "Developer Mode" on your Android device)

This app works on Iphone as well but I haven't been able to try it yet so I cannot guide you through the installation process!
