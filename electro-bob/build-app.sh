set -e
set -x

npx nuxi generate # Create a web build
npx cap sync # update capacitor project directories
cd android
rm -f app/build/outputs/apk/realease/*
./gradlew --stop
./gradlew assembleDebug --no-daemon # Create apk

cp app/build/outputs/apk/debug/*.apk ../electroBOB.apk
