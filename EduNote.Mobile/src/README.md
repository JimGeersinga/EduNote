How to publish to the playstore

1. Generate release build:
    ionic cordova build android --prod --release
2. Sign the APK 
    "C:\Program Files\Java\jre1.8.0_211\bin\keytool.exe" -genkey -v -keystore edunote_mobile.keystore -alias edunote_mobile -keyalg RSA -keysize 2048 -validity 10000
    Wachtwoord = edunote

    "C:\Program Files\Java\jdk1.8.0_201\bin\jarsigner.exe" -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore edunote_mobile.keystore edunote-release-unsigned.apk edunote_mobile

    zipalign -v 4 edunote-release-unsigned.apk edunote.apk