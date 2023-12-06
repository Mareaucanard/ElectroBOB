set -e
set -x

npx nuxi generate # Create a web build
npx cap sync # update capacitor project directories
rm -f app/build/outputs/apk/realease/*
cd android
./gradlew --stop
./gradlew assembleRelease --no-daemon # Create apk

cp app/build/outputs/apk/release/*.apk ../electroBOB.apk
